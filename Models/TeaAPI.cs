using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeaMVC.Models
{
    [Bind(Exclude = "TeaId")]
    public class TeaAPI
    {
        [ScaffoldColumn(false)]
        public int TeaId { get; set; }
        [DisplayName("Mã trà")]
        public int TypeId { get; set; }
        [DisplayName("Mã thể loại")]
        public int SupId { get; set; }
        [Required(ErrorMessage = "Tên sản phẩm không được dể trống ")]
        [StringLength(160)]
        [DisplayName("Tên sản phẩm:")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Đơn giá:  không được để trống！")]
        [Range(0.01, 100000.00,
            ErrorMessage = "Giá trị từ 0.01 đến 100000.00 ")]
        [DisplayName("Đơn giá: ")]
        public decimal Price { get; set; }
        [DisplayName("Đường dẫn hình ảnh: ")]
        [StringLength(1024)]
        public string TeaArtUrl { get; set; }
        public virtual Type Type { get; set; }
        public virtual Sup Sup { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }  
    }
}