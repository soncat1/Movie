using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace Movie.Models
{
    

    public class Film
    {

        public int FilmId { get; set; }

        [StringLength(500)]
        [Display(Name = "Tên phim")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Đạo diễn")]
        public string Director { get; set; }

        [StringLength(500)]
        [Display(Name = "Diễn viên")]
        public string Actor { get; set; }
        [Display(Name = "Năm sản xuất")]
        public int? Year { get; set; }

        [StringLength(500)]
        [Display(Name = "Nội dung")]
        public string Summary { get; set; }

        [StringLength(500)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        [StringLength(500)]
        [Display(Name = "Trailer")]
        public string TrailerUrl { get; set; }

        [Display(Name = "Thời lượng")]
        public int? Duration { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }

        [Range(1,5)]
        [Display(Name = "Đánh giá")]
        public double Rating { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Showtime> ShowTimes { get; set; }
    }
}
