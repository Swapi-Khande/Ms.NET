using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Book_Store_App__Razor_.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display order should be between 1-50")]
        public int DisplayOrder { get; set; }
    }
}
