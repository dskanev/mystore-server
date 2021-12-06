using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Messages
{
    public class BalanceUpdatedMessage : CorrelatedBy<Guid>
    {
        public string UserId { get; set; }
        public double AddBalance { get; set; }
        public Guid CorrelationId { get; set; }
    }
}
