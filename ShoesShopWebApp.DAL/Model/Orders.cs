using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoesShopWebApp.DAL.Model
{
    public class Orders
    {
        #region --Mã đơn hàng--
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        #endregion


        #region --Tên đơn hàng--
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public String Name { get; set; }
        #endregion


        #region --Ngày tạo--
        [Column(TypeName = "datetime")]
        [Required]
        public DateTime CreatedDate { get; set; }
        #endregion


        #region --Số điện thoại--
        [MaxLength(10)]
        [Column(TypeName = "nvarchar(11)")]
        [Required]
        public String PhoneNumberOfOrder { get; set; }
        #endregion


        #region --Địa chỉ--
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public String Address { get; set; }
        #endregion


        #region --Tổng tiền--
        [Column(TypeName = "int")]
        [Required]
        public int TotalPrice { get; set; }
        #endregion


        #region --Tình trạng--
        [MaxLength(25)]
        [Column(TypeName = "nvarchar(25)")]
        [Required]
        public String Status { get; set; }
        #endregion


        #region --Ghi chú--
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public String Note { get; set; }
        #endregion


        public String EmpId { get; set; }
        public virtual Employee Employee { get; set; }


        public String CusId { get; set; }
        public virtual Customer Customer { get; set; }


        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
