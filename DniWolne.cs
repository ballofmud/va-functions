using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace va.functions;

public class DniWolne
{
    private readonly ILogger<DniWolne> _logger;

    public DniWolne(ILogger<DniWolne> logger)
    {
        _logger = logger;
    }

    [Function("DniWolne")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}