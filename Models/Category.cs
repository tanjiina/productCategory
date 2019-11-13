using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace productCateg.Models
{
    public class Category
    {
        // auto-implemented properties need to match the columns in your table
        // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}

        public List<Association> AllProducts {get;set;}
    }
}
    