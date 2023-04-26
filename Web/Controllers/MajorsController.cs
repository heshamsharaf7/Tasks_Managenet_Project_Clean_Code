using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UrTask.Application.DTOs.MajorDto;
using UrTask.Application.IUC;

namespace Web.Controllers
{
    public class MajorsController : Controller
    {
        //private readonly IUnitOfWork UnitOfWork;
        private readonly IMajor usecase;
        IList<MajorGetDto> lstData;
        public MajorsController(IMajor usecase)
        {
            
            this.usecase = usecase;
        }
        public IActionResult Index(bool isSuccess = false)
        {
            ViewBag.message = "تم الحذف بنجاح";
            ViewBag.isSuccess = isSuccess;
            ViewBag.alertType = "alert alert-danger";

            lstData = usecase.GetAll();

            return View(lstData);
        }
        public IActionResult AddMajor(bool isSuccess = false)
        {
            
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = "تمت الاضافة بنجاح";
            ViewBag.alertType = "alert alert-primary";
            return View();
        }
        [HttpPost]
        public IActionResult AddMajor(MajorAddDto major)
        {
           
            if (ModelState.IsValid)
            {

                try
                {
                    usecase.Add(major);

                    return RedirectToAction(nameof(AddMajor), new { isSuccess = true });
                }catch(Exception e)
                {

                }

                //return RedirectToAction(nameof(Index)); 
            }
           

            return View();
        }
        public IActionResult DeleteMajor(int id)
        {
            try
            {
                usecase.Delete(id);
                return RedirectToAction(nameof(Index), new { isSuccess = true });
            }catch(Exception e)
            {

            }
            return RedirectToAction(nameof(Index), new { isSuccess = false });
        }

        public IActionResult UpdateMajor(int id)
        {
            return View(usecase.GetByIdUpdate(id));
        }
        [HttpPost]
        public IActionResult UpdateMajor(int id, MajorUpdateDto major )
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    usecase.Edit(id, major);
                    return RedirectToAction(nameof(Index));
                }catch(Exception e)
                {

                }
            }
            return View();

        }
    }
}
