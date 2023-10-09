using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
       
        public string AuthorName { get; set; }
        public string AuthorAddress { get; set; }
        public string AuthorPhone { get; set; }
    }
}
