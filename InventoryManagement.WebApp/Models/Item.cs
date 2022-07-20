using InventoryManagement.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ClassDemo.Models
{
    public class Item
    {
        public int Id { get; set; }

        public Item()
        {
            QuoteItems = new List<QuoteItem>();
        }

        [Required]
        [Display(Name ="ITEM")]
        public string Name { get; set; }


        [Display(Name = "RETAIL PRICE")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal RetailPrice { get;  set; }

        public bool IsDeleted { get; set; } = false;

        [Display(Name = "CREATED DATE")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        [Display(Name = "UPDATED DATE")]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        [Display(Name = "COST")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Cost { get; set; } = 0;

        [HiddenInput(DisplayValue = false)]
        public List<QuoteItem> QuoteItems { get; set; }

    }
}
