using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Value_Video.Models;

namespace Value_Video.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribed { get; set; }
        
        public byte MembershipTypeId { get; set; }
        public MembershipTypeDto MembershipType { get; set; }

        [Min18YearsIfMemberDto]
        public DateTime? BirthDate { get; set; }
    }
}