using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UrTask.Application.DTOs.AnswersDto;
using UrTask.Application.DTOs.TaskDto;
using UrTask.Application.Enums.ResultsTypes;
using UrTask.Application.IUC;
using UrTask.Application.Utils.FinalResults;
using UrTask.Domain.Entities;
using UrTask.Domain.IRepositires;
using IronOcr;

namespace UrTask.Application.UC
{
    public class TaskUC : ITaskUC
    {
        private readonly ITaskRepo _rep;
        private readonly ITaskFileRepo _fileRep;
        private readonly IHostingEnvironment _environment;
        private readonly IAnswerRepo _answerRep;
        private readonly IAnswerFileRepo _answerFileRep;

        public TaskUC(ITaskRepo rep, ITaskFileRepo fileRep, 
            IHostingEnvironment environment, IAnswerRepo answerRep,
            IAnswerFileRepo answerFileRep)
        {
            _rep = rep;
            _fileRep = fileRep;
            _environment = environment;
            _answerRep = answerRep;
            _answerFileRep = answerFileRep;
        }
        public string title => "صفحة المهام";

        public ServicesResultsDto Add(TaskAddDto entity)
        {

            try
            {
                entity.TaskStatues = 1;
                TaskMdl mdl = entity.toModel(entity);

                var tupleAdd = _rep.Add(mdl);
                
                var isDone = tupleAdd.Item1;
                if (entity.Files != null)
                {
                    string wwwPath = _environment.WebRootPath;
                    string contentPath = _environment.ContentRootPath;
                    string fileDirectory = "tasks/task" + tupleAdd.Item2.ToString();
                    string path = Path.Combine(_environment.WebRootPath, fileDirectory);
                    string textFile;
                    string filePathDirectory;
                    var ocr = new IronTesseract();
                    ocr.Language = OcrLanguage.English;

                    // Add as many secondary languages as you like
                    ocr.AddSecondaryLanguage(OcrLanguage.Arabic);
                   // ocr.AddSecondaryLanguage(OcrLanguage.ChineseSimplified);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    List<string> uploadedFiles = new List<string>();
                    foreach (IFormFile postedFile in entity.Files)
                    {
                        string fileName = Path.GetFileName(postedFile.FileName);
                        using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                        {
                           filePathDirectory=  stream.Name;
                            postedFile.CopyTo(stream);
                            uploadedFiles.Add(fileName);
                          
                        }
                        using (var input = new OcrInput((filePathDirectory).Trim()))
                        {
                            var result = ocr.Read(input);
                            textFile = result.Text;
                        }
                        _fileRep.Add(new TaskFilesMdl() { Path = fileName, FileText = textFile, TaskId = Convert.ToInt32(tupleAdd.Item2), EnterdDate = DateTime.Now });
                    }
                }
                
               
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

        public IList<TaskGetDto> GetAll()
        {
            try
            {
                var items = _rep.GetAll().ToList();
                IList<TaskGetDto> entities = new TaskGetDto().fromModel(items);
                return entities;
            }
            catch (Exception e)
            {
                var x = e;
                ServicesResultsDRY.GetException();
                return new List<TaskGetDto>();
            }
        }

        public IList<AnswerGetDto> GetAllAnswers(int taskId)
        {
            try
            {
                var item = _answerRep.GetByTaskId(taskId).ToList();
                IList< AnswerGetDto> entities = new AnswerGetDto().fromModel(item);


                var files = new List<DeliveryFilesMdl>();
                var filesPath = new List<string>();
                foreach (var answers in entities)
                {
                    files.Clear();
                    filesPath.Clear();
                    files = _answerFileRep.GetByAnswerId(answers.Id).ToList();
                    if (files.Count() != 0)
                    {
                        foreach (DeliveryFilesMdl path in files)
                        {
                            filesPath.Add(path.Path);
                        }
                        answers.FilesPath = filesPath;
                    }
                    else
                    {
                        answers.FilesPath = null;
                    }
                    
                }
                return entities;
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public IList<TaskGetDto> GetAllBySearchString(string searchString)
        {
            try
            {
                var items = _rep.GetAllBySearch(searchString).ToList();
                IList<TaskGetDto> entities = new TaskGetDto().fromModel(items);
                List<string> list = new List<string>();
                if (entities.Count!=0)
                foreach(var entity in entities)
                {
                    var files = _fileRep.GetByTaskId(entity.Id).ToList();
                        list.Clear();
                        foreach (var textFiles in files)
                    {
                            
                        if(textFiles.FileText!=null)
                         list.Add(textFiles.FileText.ToString());
                    }
                        entity.FilesTexts = list;
                        
                }
                return entities;
            }
            catch (Exception e)
            {
                var x = e;
                ServicesResultsDRY.GetException();
                return new List<TaskGetDto>();
            }
        }

        public IList<TaskGetDto> GetAllByUserId(int userId)
        {
            try
            {
                var items = _rep.GetAllByUserId(userId).ToList();
                IList<TaskGetDto> entities = new TaskGetDto().fromModel(items);
                return entities;
            }
            catch (Exception e)
            {
                var x = e;
                ServicesResultsDRY.GetException();
                return new List<TaskGetDto>();
            }
        }

        public TaskDetailsDto GetById(int id)
        {
            try
            {
                var item = _rep.GetById(id);
                IList<TaskFilesMdl> files = _fileRep.GetByTaskId(id).ToList();
                TaskDetailsDto entity = new TaskDetailsDto().fromModel(item);
                var filesPath = new List<string>();
                foreach (TaskFilesMdl path in files)
                {
                    filesPath.Add(path.Path);
                }
                entity.FilesPath = filesPath;
                entity.Answers = GetAllAnswers(id);
                return entity;
            }
            catch(Exception e)
            {

            }
            return null;
        }

        public ServicesResultsDto SetStatues(int id, int statues)
        {
            try
            {

                var isDone = _rep.SetStatues(id, statues);
                if (isDone)
                    return ServicesResultsDRY.GetSuccess();
                else return ServicesResultsDRY.GetError(ResultsTypes.None);
            }
            catch (Exception)
            {
                return ServicesResultsDRY.GetException();
            }
        }

        public ServicesResultsDto UpdatePrice(int id, double price)
        {
            try
            {



                var isDone = _rep.UpdatePrice(id,price);
                if (isDone)
                    return ServicesResultsDRY.GetSuccess();
                else return ServicesResultsDRY.GetError(ResultsTypes.None);
            }
            catch (Exception)
            {
                return ServicesResultsDRY.GetException();
            }
        }

        //public IList<taskindexdto> getindex()
        //{
        //    try
        //    {
        //        var items = _rep.GetAllIndex().ToList();
        //        return items;
        //    }
        //    catch (Exception e)
        //    {
        //        var x = e;
        //        ServicesResultsDRY.GetException();
        //        return new List<taskindexdto>();
        //    }
        //}
    }
}
