using System.Net;
using System.Threading.Tasks;
using MailChimp;
using MailChimp.Models;
using Microsoft.AspNetCore.Mvc;

namespace TestWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MailController : ControllerBase
    {
        private readonly MailService _service;
        
        public MailController(MailService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<HttpStatusCode> SendMail(MailRequest request)
        {
            await _service.SendMailAsync(request);
            
            return HttpStatusCode.OK;
        }
    }
}