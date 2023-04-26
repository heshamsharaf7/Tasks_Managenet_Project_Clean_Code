using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrTask.Application.DTOs.TaskDto;

namespace Web.Hubs
{
    public class TaskHub :Hub
    {
        public async Task NewCallRecived(TaskAddDto task)
        {
            await Clients.All.SendAsync("NewTaskRecived", task);
        }
    }
}
