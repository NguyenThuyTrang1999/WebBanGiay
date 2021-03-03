using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoesShopWebApp.DAL.Model
{
    public class Category
    {
        #region --Mã danh mục--
        [Key]
        [MaxLength(10)]
        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public String CategoryID { get; set; }
        #endregion


        #region --Tên danh mục--
        [MaxLength(10)]
        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public String CategoryName { get; set; }
        #endregion


        #region --Ngày tạo--
        [Column(TypeName = "datetime")]
        [Required]
        public DateTime CreateDay { get; set; }
        #endregion


        #region --Mô tả--
        [Column(TypeName = "nvarchar(max)")]
        public String Description { get; set; }
        #endregion


        #region --Ghi chú--
        [Column(TypeName = "nvarchar(max)")]
        public String Note { get; set; }
        #endregion


        public ICollection <Product> Product { get; set; }
    }
}
