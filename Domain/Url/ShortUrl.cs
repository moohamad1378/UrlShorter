using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Url
{
    public class ShortUrl
    {
        public Guid Id { get; set; }
        public string TakenUrl { get; set; }
        public string SendUrl { get; set; }
    }
}
