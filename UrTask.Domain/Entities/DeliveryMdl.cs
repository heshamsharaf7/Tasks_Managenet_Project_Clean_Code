using System;
using System.Collections.Generic;
using System.Text;

namespace UrTask.Domain.Entities
{
   public class DeliveryMdl
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public DateTime EnterdDate { get; set; }
        public string Notes { get; set; }
    }
}
