using System.Collections.Generic;

namespace Report.API.Model
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Firm { get; set; }
        public virtual ICollection<ContactInformation> ContactInformations { get; set; }
    }
}
