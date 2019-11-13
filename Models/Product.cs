using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace productCateg.Models
{
    public class Product
    {
        // auto-implemented properties need to match the columns in your table
        // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
        [Key]
        public int ProductId { get; set; }
        [Required (ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Price is required")]
        public double? Price { get; set; }

       [Required (ErrorMessage = "Description is required")]
       [MinLength(20, ErrorMessage = "Description must be atleast 20 characters")]
        public string Description { get; set; }
        
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
        
        public List<Association> AllCategories {get;set;}
    }
}
    