namespace BookStoreTask.Data.Models
{
    public class Book
    {
        public string ISBN  { get; private set; }
        public string Title { get; private set ; }

        public string ImageName { get; private set; }
        public BookCopies BookCopies { get; private set; }
        public Book (string ISBN ,string title , BookCopies bookCopies ,string imageName )
        {
            this.ISBN = ISBN ;
            Title = title ;
            BookCopies = bookCopies ;
            ImageName = imageName;
        }

        //ef core requires a paramterless constructor 
        //do not modify
        private Book() { }

    }
}
