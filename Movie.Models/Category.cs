using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{ 
    public class Category
    {

        public int CategoryId { get; set; }

        [StringLength(50)]
        [Display(Name ="Thể loại")]
        public string Name { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        public virtual ICollection<Film> Films { get; set; }
    }
}
