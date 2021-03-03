using ShoesShopWebApp.DAL.Rep;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace ShoesShopWebApp.DAL.Model
{
    public class Product
    {
        #region --Mã sản phẩm--
        [Key]
        [MaxLength(10)]
        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public String ProductID { get; set; }
        #endregion


        #region --Tên sản phẩm--
        [Column(TypeName = "nvarchar(max)")]
        [Required]
        public String ProductName { get; set; }
        #endregion

   
        #region --Giá tiền--
        [MaxLength(30)]
        [Column(TypeName = "int")]
        [Required]
        public int Price { get; set; }
        #endregion


        #region --Thương hiệu--
        [Column("Brand")]
        [ForeignKey("Brand")]
        public String BrandID { get; set; }
        public Brand Brand { get; set; }
        #endregion


        #region --Danh mục--
        [Column("Category")]
        [ForeignKey("Category")]
        public String CategoryID { get; set; }
        public Category Category { get; set; }
        #endregion


        #region --Ngày tạo sản phẩm--
        [Column(TypeName = "datetime")]
        [Required]
        public DateTime CreateDate { get; set; }
        #endregion


        #region --Đơn vị--
        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public String Unit { get; set; }
        #endregion


        #region --Tồn kho--
        [Column(TypeName = "int")]
        [Required]
        public int UnitsInStock { get; set; }
        #endregion


        #region --Giảm giá--
        [Column(TypeName = "float")]
        public float Discount { get; set; }
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


        public ICollection<OrderDetails> OrderDetails { get; set; }
        public ICollection<Cart> Cart { get; set; }
    }
}
