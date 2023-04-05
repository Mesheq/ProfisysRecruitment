using System.ComponentModel.DataAnnotations;

namespace ProfiSys.Models
{
    public class Document
    {
       
        public int Id { get; set; }
        public string Type { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

       
     
    }
}