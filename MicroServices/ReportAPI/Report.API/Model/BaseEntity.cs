using System;
using System.ComponentModel.DataAnnotations;

namespace Report.API.Model
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
