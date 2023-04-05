using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfiSys.Models
{
    
    public class DocumentItem
    {
      
        public int Id { get; set; }

        public int Ordinal { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int TaxRate { get; set; }
     




    }
}