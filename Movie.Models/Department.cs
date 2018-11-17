using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Movie.Models
{
    
    public class Department
    {

        public int DepartmentId { get; set; }

        [StringLength(50)]
        [Display(Name="Chức vụ")]
        public string Name { get; set; }

        public int CinemaId { get; set; }

        public virtual Cinema Cinema { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
