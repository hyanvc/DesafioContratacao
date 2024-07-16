using DesafioContratacao.Models;
using Newtonsoft.Json;
using System.Xml;

namespace DesafioContratacao.Data
{
    public sealed class JsonDatabase
    {
        public string GetFilePath(DateTime date)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"CashFlow_{date:yyyyMMdd}.json");
        }

        public CashFlow LoadCashFlow(DateTime date)
        {
            var filePath = GetFilePath(date);
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<CashFlow>(json);
            }
            return null;
        }

        public void SaveCashFlow(CashFlow cashFlow)
        {
            var filePath = GetFilePath(cashFlow.Date);
            var json = JsonConvert.SerializeObject(cashFlow, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}
