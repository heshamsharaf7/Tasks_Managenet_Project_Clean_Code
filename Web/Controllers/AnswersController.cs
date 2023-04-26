
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UrTask.Application.DTOs.AnswersDto;
using UrTask.Application.IUC;

namespace Web.Controllers
{
    public class AnswersController : Controller
    {
        private readonly IAnswerUc _usecase;

        public AnswersController(IAnswerUc usecase)
        {
            _usecase = usecase;
        }
      

        public IActionResult AddAnswer(int id,bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = "تمت الارسال بنجاح";
            ViewBag.alertType = "alert alert-primary";
            var entity = new AnswerAddDto() { TaskId = id };
            return View(entity);
        }
        [HttpPost]
        public IActionResult AddAnswer(AnswerAddDto answer)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    _usecase.Add(answer);
                    return RedirectToAction(nameof(AddAnswer), new {id= answer.TaskId, isSuccess = true });
                }
                catch (Exception e)
                {

                }
                //return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}