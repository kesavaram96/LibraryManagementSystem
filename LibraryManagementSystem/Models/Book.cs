using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LibraryManagementSystem.Validations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }

        [Required(ErrorMessage = "The field cannot be empty.")]
        public string BookName { get; set; }



        [Required(ErrorMessage = "The field cannot be empty.")]
        public string BookGenre { get; set; }


        [Required(ErrorMessage = "The field cannot be empty.")]
        [ASPNAttribute(ErrorMessage = "Please Enter valid ISBN Number")]
        public string BookISBN { get; set; }


        [Required(ErrorMessage = "The field cannot be empty.")]
        [Range(1, int.MaxValue, ErrorMessage = "Value should be greater than or equal to 1")]
        public int BookCopies { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Value should be greater than or equal to 1")]
        [Required(ErrorMessage = "The field cannot be empty.")]
        
        public int AvailableCopies { get; set; }

        public int AuthorID { get; set; }

        [ForeignKey("AuthorID")]
        [ValidateNever]
        public Author Author { get; set; }
    }
}
