using System.ServiceModel;

namespace Shared
{
    [ServiceContract]
    public interface ICwnetService
    {

        [OperationContract]
        int Add(int x, int y);
        [OperationContract]
        decimal GetNextPaymentAmount(string loanApplicationId, DateTime date);
    }
}