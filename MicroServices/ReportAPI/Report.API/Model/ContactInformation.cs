using Report.API.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Report.API.Model
{
    public class ContactInformation : BaseEntity
    {
        public InformationType Type { get; set; }
        public string Value { get; set; }
    }
}
