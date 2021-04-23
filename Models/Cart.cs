using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeaMVC.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int TeaId { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessage = " ")]  //Không dược để trống
        [Range(0, 100, ErrorMessage = "Số lượng phải từ 0 ~ 100")]
        [DisplayName("Số lượng")]
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual Tea Tea { get; set; }
    }


    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int TeaId { get; set; }
        [DisplayName("Số lượng")]
        public int Quantity { get; set; }
        [DisplayName("Đơn giá: ")]
        public decimal UnitPrice { get; set; }
        public virtual Tea Tea { get; set; }
        public virtual Order Order { get; set; }
    }
}