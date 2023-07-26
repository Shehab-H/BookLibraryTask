using System.ComponentModel.DataAnnotations;

namespace BookStoreTask.ViewModels
{
    public record  BookViewModel
        (
        [Required]
        string ISBN ,
        [Required]
        string Title,
        [Required]
        int NoOfAvailableCopies,
        string ImageName
        );
}
