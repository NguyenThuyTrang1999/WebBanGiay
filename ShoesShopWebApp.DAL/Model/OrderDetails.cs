using ShoesShopWebApp.DAL.Rep;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoesShopWebApp.DAL.Model
{
    public class OrderDetails
    {
        #region --Mã đơn hàng--
        [Required]
        [Column(TypeName = "int")]
        public int OrderID { get; set; }
        public Orders Orders { get; set; }
        #endregion


        #region --Mã sản phẩm--
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public String ProductID { get; set; }
        public Product Product { get; set; }
        #endregion


        #region --Số lượng--
        [Required]
        [Column(TypeName = "int ")]
        public int Amounts { get; set; }
        #endregion


        #region --Ghi chú--
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public String Note { get; set; }
        #endregion
    }
}
