using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace RefTrust.Repository.Entities
{
    [Table("UserProfile")]
    public partial class UserProfile
    {
        public string Id { get; set; }

        [StringLength(250)]
        public string FirstName { get; set; }

        [StringLength(250)]
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(250)]
        public string City { get; set; }

        [StringLength(250)]
        public string ZipCode { get; set; }

        [StringLength(250)]
        public string Country { get; set; }

        public bool EMailVerified { get; set; }

        [StringLength(500)]
        public string MyStatus { get; set; }

        public Guid? MyStatusPrivacyLevelId { get; set; }

        public Guid? TermsAndConditionsId { get; set; }

        public DateTime? TermsAndConditionsAgreedDate { get; set; }

        public DateTime? DateEntered { get; set; }

        public DateTime? DateModified { get; set; }

        [StringLength(250)]
        public string TimeZoneId { get; set; }

        public bool IsProfessional { get; set; }

        public virtual UserAvatar UserAvatar { get; set; }

        public virtual UserCover UserCover { get; set; }
    }
}
