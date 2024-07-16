using DesafioContratacao.Data;
using DesafioContratacao.Models;

namespace DesafioContratacao.Services
{
    public class CashFlowService : ICashFlowService
    {
        private readonly JsonDatabase _database;

        // Constructor injection aplicando Dependency Inversion Principle
        public CashFlowService(JsonDatabase database)
        {
            _database = database;
        }

        // Método para adicionar transação, responsabilidade única (Single Responsibility Principle)
        public void AddTransaction(Transaction transaction)
        {
            var cashFlow = GetCashFlow(transaction.Date);
            cashFlow.Transactions.Add(transaction);
            _database.SaveCashFlow(cashFlow);
        }

        // Método para obter fluxo de caixa por data
        public CashFlow GetCashFlow(DateTime date)
        {
            return _database.LoadCashFlow(date) ?? new CashFlow { Date = date };
        }

        // Método para gerar relatório diário, responsabilidade única (Single Responsibility Principle)
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
