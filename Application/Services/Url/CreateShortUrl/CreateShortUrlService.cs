using Application.Interface.DBInterface;
using Common;
using Domain.Url;
using System;
using System.Linq;


namespace Application.Services.Url.CreateShortUrl
{
    public class CreateShortUrlService : ICreateShortUrlService
    {
        private readonly IDataBaseContext _context;
        public CreateShortUrlService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ShortUrlDto> Execute(string TakenUrl)
        {
            

            var token = RandomGenerator();
            ShortUrl shortUrl = new ShortUrl()
            {
                TakenUrl = TakenUrl,
                SendUrl = token,
            };
            _context.ShortUrls.Add(shortUrl);
            _context.SaveChanges();
            return new ResultDto<ShortUrlDto>
            {
                Success = true,
                Data = new ShortUrlDto
                {
                    SendUrl = shortUrl.SendUrl
                }
            };
        }
        private string RandomGenerator()
        {
            Random rand = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars,6)
              .Select(s => s[rand.Next(s.Length)]).ToArray());
        }
    }
}
