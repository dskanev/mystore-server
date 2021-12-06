using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Messages
{
    public class SlotMachineWasSpunMessage
    {
        public string UserId { get; set; }
        public bool Won { get; set; }
        public double BetAmmount { get; set; }
        public double Winnings { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
