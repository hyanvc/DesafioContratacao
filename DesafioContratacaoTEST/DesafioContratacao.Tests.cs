using DesafioContratacao.Data;
using DesafioContratacao.Models;
using DesafioContratacao.Services;

namespace DesafioContratacaoTEST
{
    public class CashFlowServiceTests
    {
        private readonly ICashFlowService _cashFlowService;

        public CashFlowServiceTests()
        {
            // Inicialização do serviço com dependências necessárias
            _cashFlowService = new CashFlowService(new JsonDatabase());
        }

        [Fact]
        public void TestAddTransaction()
        {
            // Arrange
            var transaction = new Transaction
            {
                Date = DateTime.Today,
                ProductName = "Produto Teste",
                Amount = 100.00m,
                Type = TransactionType.Credit
            };

            // Act
            _cashFlowService.AddTransaction(transaction);

            // Assert
            var cashFlow = _cashFlowService.GetCashFlow(DateTime.Today);
            Assert.True(cashFlow.Transactions.Count > 0);
        }


        [Fact]
        public void TestAddTransactionDEBIT()
        {
            // Arrange
            var transaction = new Transaction
            {
                Date = DateTime.Today,
                ProductName = "Produto Teste",
                Amount = 100.00m,
                Type = TransactionType.Debit
            };

            // Act
            _cashFlowService.AddTransaction(transaction);

            // Assert
            var cashFlow = _cashFlowService.GetCashFlow(DateTime.Today);
            Assert.True(cashFlow.Transactions.Count > 0);
        }

        [Fact]
        public void TestGetDailyReport()
        {
            // Arrange
            var date = DateTime.Today;

            // Act
            var report = _cashFlowService.GetDailyReport(date);

            // Assert
            Assert.NotNull(report);
            Assert.Equal(date, report.Date);
        }
    }
}