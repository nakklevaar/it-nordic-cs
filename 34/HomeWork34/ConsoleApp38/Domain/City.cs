using System.Collections.Generic;

namespace ConsoleApp38.Domain
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; } //varchar 250

        public List<Address> Addresses { get; set; } = new List<Address>();
    }
}