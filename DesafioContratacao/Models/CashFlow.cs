namespace DesafioContratacao.Models
{

    public class CashFlow
    {
        public DateTime Date { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public decimal GetBalance()
        {
            return Transactions.Sum(t => t.Type == TransactionType.Credit ? t.Amount : -t.Amount);
        }
    }


}
