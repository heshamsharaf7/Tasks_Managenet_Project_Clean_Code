using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrTask.Application.DTOs.TaskDto;
using UrTask.Application.IUC;
using Web.Hubs;
using Web.Shared;

namespace Web.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskUC _usecase;
        IList<TaskGetDto> lstData;
        private readonly IHubContext<TaskHub> _hubContext;

        public TasksController(ITaskUC usecase,  IHubContext<TaskHub> hubContext)
        {
            _usecase = usecase;
            _hubContext = hubContext;
        }
        public IActionResult Index()
        {
            lstData = _usecase.GetAll() ;
            List<TaskGetDto> data = lstData as List<TaskGetDto>;
            data.Reverse();
            return View(data);
        }

        public IActionResult AddTask(bool isSuccess = false)
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.message = "تمت الارسال بنجاح";
            ViewBag.alertType = "alert alert-primary";
            return View();
        }
        
        public IActionResult UpdatePrice(int id ,string  price)
        {
            try
            {
                _usecase.UpdatePrice(id, Convert.ToDouble(price));
                return RedirectToAction("Index");

            }catch(Exception e)
            {

            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public async Task<IActionResult> AddTask(TaskAddDto task)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    _usecase.Add(task);
                    await _hubContext.Clients.All.SendAsync("NewTaskRecived", "تمت اضافة مهمة جديدة");
                    return RedirectToAction(nameof(AddTask), new { isSuccess = true });
                }catch(Exception e)
                {

                }
                //return RedirectToAction(nameof(Index));
            }
            return View();
        }


        
        public IActionResult setStatues(int id, int statues)
        {
            _usecase.SetStatues(id, statues);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult TaskDetails(int id)
        {
            return View(_usecase.GetById(id));
        }

        public IActionResult StudentTasks()
        {
            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "UserId").Value);

            lstData = _usecase.GetAllByUserId(userId);
            List<TaskGetDto> data = lstData as List<TaskGetDto>;
            data.Reverse();
            return RedirectToAction("Student","Home",new { tasks = data });
        }

        
    }
}
