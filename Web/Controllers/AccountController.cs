using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UrTask.Application.DTOs.StatuesDto;
using UrTask.Application.DTOs.UserDto;
using UrTask.Application.IUC;

using Web.Shared;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserUC _usecase;
        IList<UserGetDto> lstData;

        public AccountController(IUserUC usecase)
        {
            _usecase = usecase;
        }
        public IActionResult Index()
        {
            lstData = _usecase.GetAll();

            return View(lstData);
        }

        public IActionResult Login()
        {
            return View("Login",new UserGetDto());
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync( string email, string password, bool remberMe=true, bool isFail = false)
        {
            ViewBag.isFail = isFail;
            ViewBag.alertType = "alert alert-danger";
            if (email!=null && password!=null)
            {
                
                var user=  _usecase.GetByEmail(email);
                try
                {
                    if(user!=null)
                    {
                        if(email==user.Email && password==user.Password)
                        {
                            var claims = new List<Claim>
                            {
                               new Claim(ClaimTypes.Name, user.Name),
                               new Claim("UserId",user.Id.ToString()),
                               new Claim("UserType",user.TypeId.ToString()),
                               new Claim("UserPhotoPath", user.Photo.ToString() ?? "0"),

                                new Claim(ClaimTypes.GivenName,user.Id.ToString() )
                                //new Claim("Department", "HR"),
                                //new Claim("Admin","true"),
                                //new Claim("Manager","true")
                            };
                            var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                            ClaimsPrincipal claimsPrinciple = new ClaimsPrincipal(identity);

                            var authPropreity = new AuthenticationProperties
                            {
                                IsPersistent = true
                            };
                            await HttpContext.SignInAsync("MyCookieAuth", claimsPrinciple);
                            return RedirectToAction("Index","Home");
                        }
                        else
                        {
                            ViewBag.message = "كلمة المرور غير صحيحة";
                            ViewBag.isFail = true;
                            return View("Login", new UserGetDto());

                        }
                    }
                    else
                    {
                        ViewBag.message  = "الايميل غير موجود";
                        ViewBag.isFail = true;

                        return View("Login", new UserGetDto());
                    }

                }
                catch (Exception e)
                {

                }

            }else
            {
                ViewBag.message = "يرجى كتابة الايميل وكلمة المرور";
                ViewBag.isFail = true;
                return View(new UserGetDto());
            }

            return View(new UserGetDto());
        }


        public IActionResult SignUp()
        {

            var majors = new SelectList(new MajorValueDto().GetAll(), "id", "name");
            ViewBag.majors = majors;
            return View("SignUp");
        }

        [HttpPost]
        public  IActionResult SignUp(UserAddDto user, bool isFail = false)
        {
            var majors = new SelectList(new MajorValueDto().GetAll(), "id", "name");
            ViewBag.majors = majors;
            ViewBag.isFail = isFail;
            ViewBag.alertType = "alert alert-danger";
            var userCheck = _usecase.GetByEmail(user.Email);
            if(userCheck == null)
            {
                try
                {
                    _usecase.Add(user);
                    ViewBag.message = "تم تسجيل حسابك بنجاح";
                    ViewBag.isFail = true;
                    ViewBag.alertType = "alert alert-primary";

                    return View("Login" , new UserGetDto() {Email=user.Email, Password=user.Password });
                }
                catch (Exception e)
                {

                }
            }
            else
            {
                ViewBag.message = "الايميل  موجود مسبقا";
                ViewBag.isFail = true;
                return View("SignUp");
            }
            
            return View("SignUp");
        }
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Profile(bool isSuccess = false)
        {

            ViewBag.isSuccess = isSuccess;
            ViewBag.message = "تمت التعديل بنجاح";
            ViewBag.alertType = "alert alert-primary";
            return View(_usecase.GetByIdUpdate(Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserId").Value)));
        }
        [HttpPost]
        public IActionResult UpdateProfile( UserUpdateDto user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _usecase.Edit(user.Id, user);
                    return RedirectToAction(nameof(Profile),new { isSuccess=true });
                }
                catch (Exception e)
                {

                }
            }
            return RedirectToAction(nameof(Profile), new { isSuccess = false });
        }


    }


}