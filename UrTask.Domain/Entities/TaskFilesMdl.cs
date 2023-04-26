using System;


namespace UrTask.Domain.Entities
{
   public class TaskFilesMdl
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public DateTime EnterdDate { get; set; }
        public int TaskId { get; set; }
        public string FileText { get; set; }
    }
}
