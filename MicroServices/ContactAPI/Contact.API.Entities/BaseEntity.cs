using System;
using System.ComponentModel.DataAnnotations;

namespace Contact.API.Entities
{
    public class BaseEntity
    {
        [Key]
        public string UUID { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
