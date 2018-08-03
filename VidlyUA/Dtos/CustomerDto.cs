using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyUA.Models;

namespace VidlyUA.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required( ErrorMessage = "Please enter a valid Name" )]
        [StringLength( 255 )]
        public string Name { get; set; }

        public bool IsSubscribedToNew { get; set; }

        public byte MembershipTypeId { get; set; }

        //[Min18YearsIfAMember]
        public DateTime? BirthDateTime { get; set; }
    }
}