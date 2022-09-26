using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        
        [Required]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,50,ErrorMessage ="Display Order Must in between 1 to 50")]
        public int DiplayOrder { get; set; }    
        public DateTime date { get; set; } =DateTime.Now;
        public string city { get; set; }


    }
}
