using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BookApplication1.Models.Models
{
    public class Category
    {
        //[Key]
        public int Id { get; set; }
        [NotNull, Required, MaxLength(30), DisplayName("Category Name")]
        public string Name { get; set; } = null!;
        [Range(1, 100), DisplayName("Display Order")]
        public int DisplayOrder { get; set; }

    }
}
