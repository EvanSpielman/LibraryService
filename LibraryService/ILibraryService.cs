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
        void SaveBook();

        [OperationContract]
        void DeleteBook(string title, string author);
    }
}
