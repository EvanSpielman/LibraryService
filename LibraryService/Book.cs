using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Library
{
    [DataContract]
    public class Book
    {
        public Book()
        {
            Reviews = new List<Review>();
        }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string LibraryCode { get; set; }

        [DataMember]
        public string Author { get; set; }

        [DataMember]
        public Publisher Publisher { get; set; }

        [DataMember]
        public BookStatus BookStatus { get; set; }

        [DataMember]
        public DateTime? DueDate { get; set; } 

        [DataMember]
        public Genre Genre { get; set; }

        [DataMember]
        public List<Review> Reviews { get; set; }
    }
}