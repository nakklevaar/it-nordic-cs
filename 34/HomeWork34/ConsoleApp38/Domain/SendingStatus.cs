using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp38.Domain
{
    public class SendingStatus
    {
        public int Id { get; set; }

        public PostalItem PostalItem { get; set; }

        public DateTimeOffset UpdateStatuse { get; set; }

        public Status Status { get; set; }

        public Contractor SendingContractor { get; set; }

        public Address SendingAddress { get; set; }

        public Contractor ReceivingContractor { get; set; }

        public Address ReceivingAddress { get; set; }
    }
}
