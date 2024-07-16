namespace DesafioContratacao.Models
{
    public class Report
    {
        public DateTime Date { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; }
    }


}
