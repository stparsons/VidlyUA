using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace VidlyUA.Models
{
    public class MembershipType
    {
        public static readonly byte UnKnown = 0;
        public static readonly byte PayAsYouGo = 1;

        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
    }
}