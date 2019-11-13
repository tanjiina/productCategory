using System.ComponentModel.DataAnnotations;
using System;

namespace productCateg.Models
{
    public class Association
    {
        // auto-implemented properties need to match the columns in your table
        // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
        [Key]
        public int AssocationId { get; set; }
        public Product Product {get; set;}
        public Category Category {get; set;}
        public int ProductId {get; set;}
        public int CategoryId {get; set;}
    }
}
    