using DesafioContratacao.Models;

namespace DesafioContratacao.Services
{
    public interface ICashFlowService
    {
        void AddTransaction(Transaction transaction);
        CashFlow GetCashFlow(DateTime date);
        Report GetDailyReport(DateTime date);
    }

}
