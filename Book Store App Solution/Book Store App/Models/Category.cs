using System.ComponentModel.DataAnnotations;

namespace Book_Store_App.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
