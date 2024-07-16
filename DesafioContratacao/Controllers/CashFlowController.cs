using ClosedXML.Excel;
using DesafioContratacao.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioContratacao.Controllers
{
    public class CashFlowController : Controller
    {
        private readonly ICashFlowService _cashFlowService;

        public CashFlowController(ICashFlowService cashFlowService)
        {
            _cashFlowService = cashFlowService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddTransaction()
        {
            var transaction = new Transaction { Date = DateTime.Today };
            return View(transaction);
        }

        [HttpPost]
        public IActionResult AddTransaction(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _cashFlowService.AddTransaction(transaction);
                return RedirectToAction("Index");
            }
            return View(transaction);
        }

        public IActionResult Report(DateTime date)
        {
            var report = _cashFlowService.GetDailyReport(date);
            return View(report);
        }


        public IActionResult DownloadReport(DateTime date)
        {
            var report = _cashFlowService.GetDailyReport(date);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Daily Report");

                worksheet.Column(1).Width = 12; // Largura da coluna 1 (Data)
                worksheet.Column(2).Width = 30; // Largura da coluna 2 (Produto)
                worksheet.Column(3).Width = 15; // Largura da coluna 3 (Valor)
                worksheet.Column(4).Width = 15; // Largura da coluna 4 (Tipo)

                worksheet.Cell(1, 1).Value = "Data";
                worksheet.Cell(1, 2).Value = "Produto";
                worksheet.Cell(1, 3).Value = "Valor";
                worksheet.Cell(1, 4).Value = "Tipo";

                for (int i = 0; i < report.Transactions.Count; i++)
                {
                    var transaction = report.Transactions[i];
                    worksheet.Cell(i + 2, 1).Value = transaction.Date.ToString("yyyy-MM-dd");
                    worksheet.Cell(i + 2, 2).Value = transaction.ProductName;
                    worksheet.Cell(i + 2, 3).Value = transaction.Amount;
                    worksheet.Cell(i + 2, 4).Value = transaction.Type.ToString();
                }

                worksheet.Cell(report.Transactions.Count + 2, 1).Value = "Balanço Total";
                worksheet.Cell(report.Transactions.Count + 2, 2).Value = report.Balance;

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"DailyReport_{date:yyyyMMdd}.xlsx");
                }
            }
        }
    }
}
