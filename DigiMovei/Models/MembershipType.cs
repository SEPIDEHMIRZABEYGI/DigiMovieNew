using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigiMovei.Models
{
    public class MembershipType
    {

        public byte ID { get; set; }
        public String Name { get; set; }
        public byte DurationInMonth { get; set; }
        public short SignupFee { get; set; }
        public byte DiscountRent { get; set; }
    }
}