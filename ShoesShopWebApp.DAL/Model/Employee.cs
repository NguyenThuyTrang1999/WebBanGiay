using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoesShopWebApp.DAL.Model
{
    public class Employee
    {
        #region --Tài khoản--
        [Key]
        [MinLength(6)]
        [MaxLength(15)]
        [Column(TypeName = "nvarchar(15)")]
        [Required]
        public String Account { get; set; }
        #endregion


        #region --Mật khẩu--
        [MinLength(6)]
        [MaxLength(30)]
        [Column(TypeName = "nvarchar(30)")]
        [Required]
        public String Pass { get; set; }
        #endregion


        #region --Họ--
        [MaxLength(25)]
        [Column(TypeName = "nvarchar(25)")]
        [Required]
        public String LastName { get; set; }
        #endregion


        #region --Tên--
        [MaxLength(15)]
        [Column(TypeName = "nvarchar(15)")]
        [Required]
        public String FirstName { get; set; }
        #endregion


        #region --Ngày sinh--
        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public String DateOfBirth { get; set; }
        #endregion


        #region --Giới tính--
        [MaxLength(10)]
        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public String Gender { get; set; }
        #endregion


        #region --Căn cước công dân--
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public String CitizenIdentification { get; set; }
        #endregion


        #region --Địa chỉ--
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public String Address { get; set; }
        #endregion


        #region --SĐT--
        [MaxLength(10)]
        [Column(TypeName = "nvarchar(10)")]
        [Required]
        public String PhoneNumberOfEmployee { get; set; }
        #endregion


        #region --Email--
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public String Email { get; set; }
        #endregion


        #region --Ngày tạo--
        [Column(TypeName = "datetime")]
        [Required]
        public DateTime CreatedDate { get; set; }
        #endregion


        #region --Tình trạng tài khoản--
        [MaxLength(15)]
        [Column(TypeName = "nvarchar(15)")]
        [Required]
        public String AccountStatus { get; set; }
        #endregion


        #region --Ghi chú--
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public String Note { get; set; }
        #endregion


        public virtual ICollection<Orders> OrdersByEmp { get; set; }
    }
}
