using System;


namespace UrTask.Domain.Entities
{
   public class UserMdl
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegisterdDate { get; set; }
        public bool Gender { get; set; }
        public string Photo { get; set; }
        public int TypeId { get; set; }
        public DateTime AccadimicYear { get; set; }
        public int MajorId { get; set; }
        public string Password { get; set; }
        public int AccountNoId { get; set; }
        public bool Closed { get; set; }
        public int PhoneNumber { get; set; }


    }
}
