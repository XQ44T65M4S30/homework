using System;
using System.Runtime.Serialization;

namespace EventsApp.Models
{
    [DataContract]
    public class Event
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Descripton { get; set; }
        [DataMember]
        public string Location { get; set; }
        [DataMember]
        public DateTime StartTime { get; set; }
        [DataMember]
        public DateTime EndTime { get; set; }
    }
}