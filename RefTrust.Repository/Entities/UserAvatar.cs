using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace RefTrust.Repository.Entities
{
    [Table("UserAvatar")]
    public partial class UserAvatar
    {
        public string Id { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] Avatar { get; set; }

        public DateTime? DateEntered { get; set; }

        public DateTime? DateModified { get; set; }

        public virtual UserProfile UserProfile { get; set; }
    }
}
