using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{ 
    public class Category
    {

        public int CategoryId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Film> Films { get; set; }
    }
}
