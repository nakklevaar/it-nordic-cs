using System.Collections.Generic;

namespace ConsoleApp38.Domain
{
    public class Address
    {
        public int Id { get; set; }

        public City City { get; set; }

        public string Name { get; set; } //varchar 250

        public List<SendingStatus> SendingAddresses { get; set; } = new List<SendingStatus>();

        public List<SendingStatus> ReceivingAddresses { get; set; } = new List<SendingStatus>();
    }
}