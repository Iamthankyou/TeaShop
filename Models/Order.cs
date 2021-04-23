using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeaMVC.Models
{
    [Bind(Exclude = "OrderId")]
    public partial class Order
    {
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }

        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }

        [ScaffoldColumn(false)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Tên người nhận là bát buộc")]
        [DisplayName("Tên：")]
        [StringLength(160)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Họ đệm người nhận ")]
        [DisplayName("Họ：")]
        [StringLength(160)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Địa chỉ là bắt buộc")]
        [StringLength(70)]
        [DisplayName("Địa chỉ ：")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Thành phố là bắt buộc")]
        [StringLength(40)]
        [DisplayName("Thành phố ：")]
        public string City { get; set; }

        //[Required(ErrorMessage = "*")]
        //[StringLength(40)]
      
        //public string State { get; set; }

        [Required(ErrorMessage = "Mã bưu chính là bắt buộc")]
        [DisplayName("Mã bưu chính：")]
        [StringLength(10)]        
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Khu vực nhận hàng là bắt buộc")]
        [StringLength(40)]
        [DisplayName("Khu vực：")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Điện thoại liên lạc là bắt buộc")]
        [StringLength(24)]
        [DisplayName("Điện thoại liên hệ：")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc")]
        [DisplayName("Email：")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email không đúng định dạng")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public decimal Total { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}