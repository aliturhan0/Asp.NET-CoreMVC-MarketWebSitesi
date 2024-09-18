using System.ComponentModel.DataAnnotations;

namespace CoreAndFood.Models
{
	public class Category
	{
        public int CategoryID { get; set; }

        [Required(ErrorMessage ="Category name not empty!")]
        [StringLength (20,ErrorMessage ="Please enter only 4-20 characters",MinimumLength = 4)]
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public bool Status { get; set; }
        public List<Food> Foods { get; set; }
    }
}
