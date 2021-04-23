using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TeaMVC.Models
{
    public class Sup
    {
        [DisplayName("Mã nhà cung cấp")]
        public int SupId { get; set; }
        [DisplayName("Tên nhà cung cấp:")]
        public string Name { get; set; }
    }
}