using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigiMovei.Models;
namespace DigiMovei.ViewModels
{
    public class CustomrForViewModl
    {
        public Customer Customer { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}