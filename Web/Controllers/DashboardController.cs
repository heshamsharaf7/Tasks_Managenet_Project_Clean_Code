using Microsoft.AspNetCore.Mvc;
using UrTask.Application.DTOs.UserDto;
using UrTask.Application.IUC;

namespace Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUserUC usecase;
        UserGetDto data;

        public DashboardController(IUserUC usecase)
        {
            this.usecase = usecase;
          
        }
        public IActionResult Index()
        {
            data = usecase.GetById(1);
            return View(data);
        }
    }
}
