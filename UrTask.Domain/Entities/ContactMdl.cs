using System;
using System.Collections.Generic;
using System.Text;

namespace UrTask.Domain.Entities
{
   public class ContactMdl
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EnnterdDate { get; set; }
        public string Message { get; set; }
        public int PhoneNumber { get; set; }
    }
}
