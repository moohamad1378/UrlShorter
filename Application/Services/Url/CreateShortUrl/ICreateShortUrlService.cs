using Common;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Application.Services.Url.CreateShortUrl
{
    public interface ICreateShortUrlService
    {
        ResultDto<ShortUrlDto> Execute(string TakenUrl);
    }
}
