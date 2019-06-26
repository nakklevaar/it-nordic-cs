using System.Collections.Generic;

namespace ConsoleApp38.Domain
{
    public class PostalItem
    {
        public int Id { get; set; }

        public string Name { get; set; } //varchar 250

        public int NumberOfPages { get; set; }

        public List<SendingStatus> PostalItems { get; set; } = new List<SendingStatus>();
    }
}