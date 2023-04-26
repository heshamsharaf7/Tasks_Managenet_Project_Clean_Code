using System;
using System.Collections.Generic;
using System.Text;
using UrTask.Application.DTOs.TaskFileDto;
using UrTask.Application.Enums.ResultsTypes;
using UrTask.Application.IUC;
using UrTask.Application.Utils.FinalResults;
using UrTask.Domain.Entities;
using UrTask.Domain.IRepositires;

namespace UrTask.Application.UC
{
   public class TaskFileUC:ITaskFileUC
    {
        private readonly ITaskFileRepo _rep;
        public TaskFileUC(ITaskFileRepo rep)
        {
            _rep = rep;
        }
        public string title => "صفحة التخصصات";

        public ServicesResultsDto Add(TaskFileAddDto entity)
        {
            try
            {
                TaskFilesMdl mdl = entity.toModel(entity);

                var tupleAdd = _rep.Add(mdl);
                var isDone = tupleAdd.Item1;
                if (isDone)
                    return ServicesResultsDRY.GetSuccess();
                else return ServicesResultsDRY.GetError(ResultsTypes.None);
            }
            catch (Exception e)
            {
                var x = e;
                return ServicesResultsDRY.GetException();
            }
        }

        //public TaskFileGetDto GetByTaskId(int taskId)
        //{
        //    try
        //    {
        //        var item = _rep.GetByTaskId(taskId);
        //        TaskFileGetDto entity = new TaskFileGetDto().fromModel(item);
        //        return entity;
        //    }
        //    catch (Exception e)
        //    {
        //        var x = e;
        //        ServicesResultsDRY.GetException();
        //        return new TaskFileGetDto();
        //    }
        //}
    }
}
