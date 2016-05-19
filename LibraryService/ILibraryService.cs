using System.Collections.Generic;
using System.ServiceModel;

namespace Library
{
    [ServiceContract]
    public interface ILibraryService
    {

        [OperationContract]
        List<Book> GetAllBooks();

        [OperationContract]
        void SaveBook(Book book);

        [OperationContract]
        void DeleteBook(string title, string author);
    }
}
