using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DigiMovei.CustomAttribute;

namespace DigiMovei.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeID { get; set; }
        public DateTime? BirthDate { get; set; }

        public MembershipType MembershipType { get; set; }
        [Required]
        //[RegularExpression(@"^/d{10}$",ErrorMessage = "کد ملی خود رابه درستی وارد نمایید ")]
      //[NationalCodeAttribute("کد ملی خود رابادقت وارد نمایید ")]
        public int NationalCode { get; set; }
    }
}