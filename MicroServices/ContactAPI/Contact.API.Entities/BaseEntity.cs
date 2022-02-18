using System;
using System.ComponentModel.DataAnnotations;

namespace Contact.API.Entities
{
    public class BaseEntity
    {
        [Key]
        public string UUID { get; set; } = Guid.NewGuid().ToString();
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
