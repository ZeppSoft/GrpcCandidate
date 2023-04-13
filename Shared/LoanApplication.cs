using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    [ProtoContract]
    public class LoanApplication
    {
        [ProtoMember(1)]
        public string LoanApplicationID { get; set; }
        [ProtoMember(2)]
        public List<Payment> Payments { get; set; }
    }

    [DataContract]
    public class Payment
    {
        [ProtoMember(1)]
        public DateTime PaymentDate { get; set; }

        [ProtoMember(2)]
        public decimal Amount { get; set; }

    }
}
