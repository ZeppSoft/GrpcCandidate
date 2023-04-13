using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModelServer
{
    public class CwnetService : ICwnetService
    {
        private Dictionary<string, LoanApplication> _loanApplicationsTable;
        public CwnetService()
        {
            FakeInit();
        }

        private void FakeInit()
        {
            _loanApplicationsTable = new Dictionary<string, LoanApplication>();

            LoanApplication la1 = new LoanApplication();
            la1.LoanApplicationID = "1.23";
            la1.Payments = new List<Payment>();
            la1.Payments.Add(new Payment { Amount = 100, PaymentDate = new DateTime(2023, 1, 1) });
            la1.Payments.Add(new Payment { Amount = 200, PaymentDate = new DateTime(2023, 2, 1) });
            la1.Payments.Add(new Payment { Amount = 300, PaymentDate = new DateTime(2023, 3, 1) });
            la1.Payments.Add(new Payment { Amount = 400, PaymentDate = new DateTime(2023, 4, 1) });

            _loanApplicationsTable.Add(la1.LoanApplicationID,la1);
        }

        public int Add(int x, int y)
        {
            return x + y;
        }

        public decimal GetNextPaymentAmount(string loanApplicationId, DateTime date)
        {
            var la = _loanApplicationsTable[loanApplicationId];

            if (la != null)
            {
                foreach (var payment in la.Payments)
                {
                    if (payment.PaymentDate == date)
                    {
                        return payment.Amount;
                    }
                }

                return -1;
            }
            else
                return -1;
        }
    }
}
