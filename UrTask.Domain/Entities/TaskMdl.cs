using System;


namespace UrTask.Domain.Entities
{
  public  class TaskMdl
    {
        public int Id { get; set; }
        public  string title { get; set; }
        public DateTime EnterdDate { get; set; }
        public string Notes { get; set; }
        public DateTime DueDate { get; set; }
        public int TaskStatues { get; set; }
        public int UserId { get; set; }
        public DateTime endDate { get; set; }
        public float Price { get; set; }
    }
}
