using System.ComponentModel.DataAnnotations;

namespace ClassDemo.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="ITEM")]
        public string Name { get; set; }


        [Display(Name = "RETAIL PRICE")]
        public decimal RetailPrice { get; set; }

        public bool IsDeleted { get; set; } = false;

        [Display(Name = "CREATED DATE")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Display(Name = "UPDATED DATE")]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        [Display(Name = "COST")]
        public decimal Cost { get; set; } = 0;

    }
}
