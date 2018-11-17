using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace Movie.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [StringLength(50)]
        [Display(Name="Họ tên")]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        [Display(Name="Ngày sinh")]
        public DateTime? DateOfBirth { get; set; }
        public int DepartmentId { get; set; }

        [StringLength(50)]
        [Display(Name="Địa chỉ")]
        public string Address { get; set; }
        [Display(Name="Chứng minh thư")]
        public int? CMT { get; set; }

        [StringLength(50)]
        [Display(Name="Tài khoản")]
        public string UserName { get; set; }

        [StringLength(50)]
        [Display(Name="Mật khẩu")]
        public string Password { get; set; }

        public virtual Department Department { get; set; }
    }
}
