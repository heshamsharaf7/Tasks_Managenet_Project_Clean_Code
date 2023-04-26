using System;


namespace UrTask.Domain.Entities
{
   public class DeliveryFilesMdl
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public DateTime EnterdDate { get; set; }
        public int DeliveryId { get; set; }
    }
}
