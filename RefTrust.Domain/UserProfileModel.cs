using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefTrust.Domain
{
    public class UserProfileModel
    {
        public string Id { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }


        public string Address { get; set; }


        public string City { get; set; }


        public string ZipCode { get; set; }


        public string Country { get; set; }

        public bool EMailVerified { get; set; }


        public string MyStatus { get; set; }

        public Guid? MyStatusPrivacyLevelId { get; set; }

        public Guid? TermsAndConditionsId { get; set; }

        public DateTime? TermsAndConditionsAgreedDate { get; set; }

        public DateTime? DateEntered { get; set; }

        public DateTime? DateModified { get; set; }


        public string TimeZoneId { get; set; }

        public bool IsProfessional { get; set; }

    }
}
