using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoesShopWebApp.DAL.Model
{
    public class Cart
    {
        #region--Mã khách hàng--
        [Required]
        [Column(TypeName = "nvarchar(15)")]
        public String Account { get; set; }
        public Customer Customer { get; set; }
        #endregion


        #region--Mã sản phẩm--
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public String ProductID { get; set; }
        public Product Product { get; set; }
        #endregion


        #region--Số lượng--
        [Column(TypeName = "int")]
        [Required]
        public int Amounts { get; set; }
        #endregion


        #region--Ghi chú--
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public String Note { get; set; }
        #endregion
    }
}
