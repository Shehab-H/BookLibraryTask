using BookStoreTask.Exceptions;

namespace BookStoreTask.Data.Models
{
    public class BookCopies
    {
        public string BookISBN { get;}
        //number of borrowed and non borrowd copies
        public int NoOfCopies { get; private set; }

        //no of availble copies to borrow not including the borrowed copies 
        public int NoOfAvailableCopies { get; private set; }

        public BookCopies(int noOfCopies)
        {
            NoOfCopies = noOfCopies;
            NoOfAvailableCopies=NoOfCopies;
        }

        public BookCopies(string bookISBN, int noOfCopies) : this(noOfCopies)
        {
            BookISBN= bookISBN;
        }

        private BookCopies() {}


        /// <summary>
        /// borrows one book copy from the library
        /// </summary>
        /// <exception cref="NoAvailableCopiesException"></exception>
        public void Borrow()
        {
            if(NoOfAvailableCopies > 0)
            {
                NoOfAvailableCopies--;
            }
            else
            {
                throw new NoAvailableCopiesException();
            }
        }

        /// <summary>
        /// returns one book copy to the library
        /// </summary>
        /// <exception cref="AllCopiesReturnedException"></exception>
        public void Return()
        {
            if(NoOfAvailableCopies < NoOfCopies)
            {
                NoOfAvailableCopies++;
            }
            else
            {
                throw new AllCopiesReturnedException();
            }
        }
    }
}
