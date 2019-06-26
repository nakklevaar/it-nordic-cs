using System.Collections.Generic;

namespace ConsoleApp38.Domain
{
    public class Contractor
    {
        public int Id { get; set; }

        public string Name { get; set; } //varchar 250

        public Position Position { get; set; }

        public List<SendingStatus> SendingContractors { get; set; } = new List<SendingStatus>();

        public List<SendingStatus> ReceivingContractors { get; set; } = new List<SendingStatus>();

    }
}