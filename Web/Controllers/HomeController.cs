using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrTask.Application.DTOs.TaskDto;
using UrTask.Application.IUC;
using Web.Shared;
using Microsoft.AspNetCore.Authentication;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskUC _usecase;
        IList<TaskGetDto> lstData;

        public HomeController(ITaskUC usecase)
        {
            _usecase = usecase;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
           
            return View();
        }
        public IActionResult OurValues()
        {
           
            return View();
        }

        public IActionResult Student()
        {
            int userId =Convert.ToInt32( User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);
            lstData = _usecase.GetAllByUserId(userId);
            return  View(lstData);
        }

        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Search(SearchTaskDto entity)
        {

            lstData = _usecase.GetAllBySearchString(entity.SearchStatement);
            return View( new SearchTaskDto() { tasks = lstData,SearchStatement="t" });
        }
    }
}
