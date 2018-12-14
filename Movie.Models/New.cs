using System;
using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{
    public class New
    {
        public int NewId { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        public string Description { get; set; }

        [StringLength(50)]
        public string TypeNew { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool IsDelete { get; set; }
    }
}
