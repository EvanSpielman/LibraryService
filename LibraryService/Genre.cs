using System.Runtime.Serialization;

namespace Library
{
    [DataContract]
    public enum Genre
    {
        [EnumMember]
        Fantasy,
        [EnumMember]
        SciFi,
        [EnumMember]
        Mystery,
        [EnumMember]
        Romance,
        [EnumMember]
        Children,
        [EnumMember]
        NonFiction
    }
}