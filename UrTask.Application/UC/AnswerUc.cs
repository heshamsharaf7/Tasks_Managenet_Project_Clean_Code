using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UrTask.Application.DTOs.AnswersDto;
using UrTask.Application.Enums.ResultsTypes;
using UrTask.Application.IUC;
using UrTask.Application.Utils.FinalResults;
using UrTask.Domain.Entities;
using UrTask.Domain.IRepositires;

namespace UrTask.Application.UC
{
    public class AnswerUc : IAnswerUc
    {
        private readonly IAnswerRepo _rep;
        private readonly IAnswerFileRepo _fileRep;
        private readonly IHostingEnvironment _environment;
        public AnswerUc(IAnswerRepo rep, IAnswerFileRepo fileRep, IHostingEnvironment environment)
        {
            _rep = rep;
            _fileRep = fileRep;
            _environment = environment;
        }
        public string title => "صفحة الاجوبة";

        public ServicesResultsDto Add(AnswerAddDto entity)
        {
            try
            {
                DeliveryMdl mdl = entity.toModel(entity);

                var tupleAdd = _rep.Add(mdl);

                var isDone = tupleAdd.Item1;
                if (entity.Files != null)
                {
                    string wwwPath = _environment.WebRootPath;
                    string contentPath = _environment.ContentRootPath;

                    string path = Path.Combine(_environment.WebRootPath, "Uploads");
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
                            postedFile.CopyTo(stream);
                            uploadedFiles.Add(fileName);

                            _fileRep.Add(new DeliveryFilesMdl() { Path = fileName, DeliveryId = Convert.ToInt32(tupleAdd.Item2), EnterdDate = DateTime.Now });
                        }
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
    }
}
