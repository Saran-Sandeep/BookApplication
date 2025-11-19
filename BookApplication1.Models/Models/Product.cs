using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BookApplication1.Models.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        [DisplayName("Book Name")]
        public string Name { get; set; } = null!;

        [MaxLength(1000)]
        [DisplayName("Book Description")]
        public string Description { get; set; } = null!;

        [Required, MaxLength(60)]
        [DisplayName("Author Name")]
        public string Author { get; set; } = null!;

        [Required]
        [Range(1, 100000)]
        [DisplayName("Price (₹)")]
        public float Price { get; set; }

        [Required]
        [Range(0, 10000)]
        [DisplayName("Stock Quantity")]
        public int Quantity { get; set; }

        [Required]
        [DisplayName("Published Date")]
        public DateOnly PublishedDate { get; set; }

        [Required]
        [Range(1, 50)]
        [DisplayName("Edition Number")]
        public int EditionNum { get; set; }

        [Range(1, 5)]
        [DisplayName("Rating (1–5)")]
        public int Rating { get; set; }

        [Required, MaxLength(20)]
        [RegularExpression(@"^\d{3}-\d{1,5}-\d{1,7}-\d{1,7}-\d{1}$",
            ErrorMessage = "Invalid ISBN format. Example: 978-1-23456-789-7")]
        [DisplayName("ISBN")]
        public string ISBN { get; set; } = null!;

        [Required]
        [DisplayName("Created On")]
        public DateOnly CreatedAt { get; set; }

        [Required]
        [DisplayName("Updated On")]
        public DateOnly UpdatedAt { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId"), ValidateNever]
        public Category Category { get; set; } = null!;
        public String ImageURL { get; set; } = "";
    }
}
