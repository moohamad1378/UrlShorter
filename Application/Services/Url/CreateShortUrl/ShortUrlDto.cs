using System.ComponentModel.DataAnnotations;


namespace Application.Services.Url.CreateShortUrl
{
    public class ShortUrlDto
    {
        [Required(ErrorMessage = "PLease put your link")]
        public string TakenUrl { get; set; }
        public string SendUrl { get; set; }
    }
}
