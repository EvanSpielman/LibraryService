using System.Runtime.Serialization;

namespace Library
{
    [DataContract]
    public class Review
    {
        [DataMember]
        public string ReviewerName { get; set; }

        [DataMember]
        public int PercentScore { get; set; }

        [DataMember]
        public string Comments { get; set; }
    }
}