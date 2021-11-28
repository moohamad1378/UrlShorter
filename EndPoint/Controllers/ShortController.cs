using Application.Services.Url.CreateShortUrl;
using Application.Services.Url.RedirecUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortController : ControllerBase
    {
        private readonly ICreateShortUrlService _createShortUrlService;
        private readonly IRedirecUserSerevice _redirecUserSerevice;
        private readonly NLog.Logger nlog=NLog.LogManager.GetCurrentClassLogger();
        public ShortController(ICreateShortUrlService createShortUrlService
            ,IRedirecUserSerevice redirecUserSerevice)
        {
            _createShortUrlService = createShortUrlService;
            _redirecUserSerevice = redirecUserSerevice;
        }
        [HttpPost]
        [Route("/")]
        public IActionResult Post([FromForm] string TakenUrl)
        {

            
            nlog.Info(TakenUrl);
            try
            {
                if (string.IsNullOrEmpty(TakenUrl))
                {
                    return BadRequest("لطفا لینک خود را قرار دهید");
                }
                var data = _createShortUrlService.Execute(TakenUrl).Data;
                string host = Request.Host.Value.ToString();
                var final = "https://" + host + "/" + data.SendUrl;
                string foruser = Url.Action(nameof(Get), "Short", new { sended =data.SendUrl}, Request.Scheme);
                return Created(foruser, final);
            }
            catch (System.Exception Ex)
            {

                nlog.Error("error", Ex);
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("/{sended}")]
        public IActionResult Get( string sended)
        {
            if (string.IsNullOrWhiteSpace(sended))
            {
                return BadRequest();
            }
            else
            {
                nlog.Info("salam");
                var data = _redirecUserSerevice.Execute(sended);
                if (data.Success == false)
                {
                    return BadRequest("لینک اشتباه است");
                }
                else
                {
                    var d = data.Data.Url;
                     return Redirect(d);
                }

            }

        }
    }
}
