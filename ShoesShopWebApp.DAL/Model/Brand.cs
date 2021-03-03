using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoesShopWebApp.DAL.Model
{
    public class Brand
    {
        #region --Mã thương hiệu--
        [Key]
        [MaxLength(10)]
        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public String BrandID { get; set; }
        #endregion


        #region --Tên thương hiệu--
        [MaxLength(10)]
        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public String BrandName { get; set; }
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


        #region --Hình ảnh--
        [Column(TypeName = "nvarchar(max)")]
        public String Picture { get; set; }
        #endregion


        #region --Ghi chú--
        [Column(TypeName = "nvarchar(max)")]
        public String Note { get; set; }
        #endregion


        public ICollection <Product> Product { get; set; }
    }
}
