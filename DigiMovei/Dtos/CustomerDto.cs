using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigiMovei.Dtos
{
    public class CustomerDto
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "لطفاً نام را وارد نمایید.")]
        [StringLength(50, ErrorMessage = "نام حداکثر می تواند 50 کاراکتر باشد.")]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public DateTime? BirthDate { get; set; }

        #region RelationBetweenCustomerAndMembershipType
        //Forign Key
        [Required(ErrorMessage = "لطفاً نوع عضویت را وارد نمایید.")]
        public byte MembershipTypeId { get; set; }
        #endregion

    }
}