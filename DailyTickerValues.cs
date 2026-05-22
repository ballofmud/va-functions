using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Dapper;

namespace va.functions;

public class DailyTickerValues
{
    private class TickerDailyValue
    {
        public string Ticker { get; set; }
        public DateTime TickerDate { get; set; }
        public decimal TickerValue { get; set; }
    }

    private readonly ILogger<DailyTickerValues> _logger;
    private readonly string _connectionString;

    public DailyTickerValues(ILogger<DailyTickerValues> logger)
    {
        _connectionString = Environment.GetEnvironmentVariable("SQLCONNSTR_SQLConnectionString") ?? throw new InvalidOperationException("SQLConnectionString environment variable is not set.");
        _logger = logger;
    }

    [Function("DailyTickerValues")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {

        using (var conn = new SqlConnection(_connectionString))
        {
            var data = conn.QueryAsync<TickerDailyValue>("SELECT Ticker, TickerDate, TickerValue FROM va_tst.TickerDailyValue").Result;
            return new OkObjectResult(data);
        }
    }
}