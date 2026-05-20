using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace va.functions;

public class DniWolne
{
    private class TickerDailyValue
    {
        public string Ticker { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
    }

    private readonly ILogger<DniWolne> _logger;

    public DniWolne(ILogger<DniWolne> logger)
    {
        _logger = logger;
    }

    [Function("DniWolne")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        var tickerDailyValues = new List<TickerDailyValue>
        {
            new TickerDailyValue { Ticker = "AAPL", Date = DateTime.UtcNow.Date, Value = 150.25m },
            new TickerDailyValue { Ticker = "MSFT", Date = DateTime.UtcNow.Date, Value = 250.75m },
            new TickerDailyValue { Ticker = "GOOGL", Date = DateTime.UtcNow.Date, Value = 2750.50m }
        };
        
        return new OkObjectResult(tickerDailyValues);
    }
}