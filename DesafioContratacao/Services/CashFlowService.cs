using DesafioContratacao.Data;
using DesafioContratacao.Models;

namespace DesafioContratacao.Services
{
    public class CashFlowService : ICashFlowService
    {
        private readonly JsonDatabase _database;

        public CashFlowService()
        {
            _database = JsonDatabase.Instance;
        }

        public void AddTransaction(Transaction transaction)
        {
            var cashFlow = GetCashFlow(transaction.Date);
            cashFlow.Transactions.Add(transaction);
            _database.SaveCashFlow(cashFlow);
        }

        public CashFlow GetCashFlow(DateTime date)
        {
            return _database.LoadCashFlow(date) ?? new CashFlow { Date = date };
        }

        public Report GetDailyReport(DateTime date)
        {
            var cashFlow = GetCashFlow(date);
            return new Report
            {
                Date = date,
                Balance = cashFlow.GetBalance(),
                Transactions = cashFlow.Transactions
            };
        }
    }


}
