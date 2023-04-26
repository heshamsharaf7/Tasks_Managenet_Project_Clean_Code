using System;


namespace UrTask.Domain.Entities
{
   public class EmployeTasksMdl
    {
        public int Id { get; set; }
        public DateTime EnterdDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool Reminder { get; set; }
        public int TaskStatuesId { get; set; }
        public DateTime EndDate { get; set; }
        public int TaskId { get; set; }
        public int EmployeeId { get; set; }
        public string Notes { get; set; }

    }
}
