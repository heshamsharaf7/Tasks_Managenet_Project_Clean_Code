using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrTask.Application.DTOs.ContactDto;
using UrTask.Application.IUC;

namespace Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactUC _usecase;
        IList<ContactGetDto> lstData;

        public ContactController(IContactUC usecase)
        {
            _usecase = usecase;
        }
        public IActionResult Index()
        {
            lstData = _usecase.GetAll();

            return View(lstData);
        }

        public IActionResult AddContact(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = "تم الارسال بنجاح سيتم التواصل بك في اقرب وقت";
            ViewBag.alertType = "alert alert-primary";

            return View("Contact");
        }
        [HttpPost]
        public IActionResult AddContact(ContactAddDto contact)
        {

            if (ModelState.IsValid)
            {

                try
                {
                    _usecase.Add(contact);
                 
                    return RedirectToAction(nameof(AddContact), new { isSuccess = true });
                }
                catch (Exception e)
                {
                    ViewBag.isSuccess = true;
                    ViewBag.message = "يرجى كتابة البيانات بشكل صحيح";
                    ViewBag.alertType = "alert alert-primary";
                    return View("Contact");
                }

                //return RedirectToAction(nameof(Index)); 
            }


            return RedirectToAction(nameof(AddContact), new { isSuccess = false });
        }
    }
}