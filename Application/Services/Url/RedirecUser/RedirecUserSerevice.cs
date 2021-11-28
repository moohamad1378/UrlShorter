using Application.Interface.DBInterface;
using Common;
using System.Linq;

namespace Application.Services.Url.RedirecUser
{
    public class RedirecUserSerevice: IRedirecUserSerevice
    {
        private readonly IDataBaseContext _context;
        public RedirecUserSerevice(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<redirectDto> Execute(string sended)
        {

            var data = _context.ShortUrls.Select(p => new { p.SendUrl,p.TakenUrl}).SingleOrDefault(p=>p.SendUrl== sended);
            if (data == null)
            {
                return new ResultDto<redirectDto>
                {
                    Success = false,
                    Message = "این آدرس اشتباه است"
                };
            }
            else
            {
                return new ResultDto<redirectDto>
                {
                    Success = true,
                    Data = new redirectDto
                    {
                        Url = data.TakenUrl
                    }
                };
            }
            
        }
    }
}
