using System.Collections.Generic;

namespace Contact.API.Entities
{
    public class Contact : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Firm { get; set; }
        public virtual ICollection<ContactInformation> ContactInformations { get; set; }
    }
}
