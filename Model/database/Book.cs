namespace Model.database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        public int id { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Book Title")]
        public string title { get; set; }

        [Display(Name = "Author")]
        public int author_id { get; set; }

        [Display(Name = "Price")]
        public decimal? price { get; set; }

        [StringLength(200)]
        [Display(Name = "Images")]
        public string images { get; set; }

        [Display(Name = "Category")]
        public int category_id { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Descriptions")]
        public string descriptions { get; set; }

        [Display(Name = "Published")]
        public DateTime? published { get; set; }

        [Display(Name = "View Count")]
        public int? view_count { get; set; } = 0;

        //[Display(Name = "Created At")]
        //public DateTime? created_at { get; set; }

        //[Display(Name = "Updated At")]  
        //public DateTime? updated_at { get; set; }

        public virtual Author Author { get; set; }

        public virtual Category Category { get; set; }
    }
}
