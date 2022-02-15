using Contact.API.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contact.API.Entities
{
    public class ContactInformation : BaseEntity
    {
        public InformationType Type { get; set; }
        public string Value { get; set; }
    }
}
