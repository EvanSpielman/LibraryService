using System.Runtime.Serialization;

namespace Library
{
    [DataContract]
    public class Publisher
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Address { get; set; }
    }
}