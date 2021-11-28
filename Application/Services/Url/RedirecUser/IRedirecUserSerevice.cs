using Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Url.RedirecUser
{
    public interface IRedirecUserSerevice
    {
        ResultDto<redirectDto> Execute(string sended);
    }
}
