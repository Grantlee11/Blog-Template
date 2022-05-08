using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class MyBlog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public string Author { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
