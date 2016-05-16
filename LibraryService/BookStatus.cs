using System.Runtime.Serialization;

namespace Library
{
    [DataContract]
    public enum BookStatus
    {
        [EnumMember]
        Available,
        [EnumMember]
        Borrowed,
        [EnumMember]
        OnHold
    }
}