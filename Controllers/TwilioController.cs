using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestSimultaneousTexts.Classes;
using Microsoft.Extensions.Logging;


[Route("api/[controller]")]
[ApiController]
public class TwilioController : ControllerBase
{
    private readonly ILogger<TwilioController> _logger;

    public TwilioController(ILogger<TwilioController> logger)
    {
        _logger = logger;
    }
    [HttpPost]
    public async Task<IActionResult> ReceiveMessage()
    {
        // Log the incoming request
        _logger.LogInformation("Received Twilio webhook request.");

        // Log request content
        using (StreamReader reader = new StreamReader(Request.Body))
        {
            string requestBody = await reader.ReadToEndAsync();
            _logger.LogInformation($"Request body: {requestBody}");
        }

        // Assuming the Twilio webhook will call this endpoint
        await Task.Run(() => TestApp.ReceiveInboundText());
        return Ok();

    }
}
