using System.ComponentModel.DataAnnotations;

namespace BookStoreTask.ViewModels
{
    public class AddBookViewModel
    {
        [MinLength(13)]
        [MaxLength(13)]
        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Title { get; set; }

        [Range(1,double.MaxValue)]
        [Required]
        public int NumberOFCopies { get; set; }
    }
}
