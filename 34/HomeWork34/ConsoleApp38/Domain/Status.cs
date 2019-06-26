using System.Collections.Generic;

namespace ConsoleApp38.Domain
{
    public class Status
    {
        public int Id { get; set; }

        public string Name { get; set; } //varchar 20

        public List<SendingStatus> Statuses { get; set; }
    }
}