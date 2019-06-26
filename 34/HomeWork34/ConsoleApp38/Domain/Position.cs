using System.Collections.Generic;

namespace ConsoleApp38.Domain
{
    public class Position
    {
        public int Id { get; set; }

        public string Name { get; set; } //varchar 250

        public List<Contractor> Contractors { get; set; } = new List<Contractor>();
    }
}