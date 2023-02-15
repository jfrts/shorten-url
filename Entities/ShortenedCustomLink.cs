using shorten_url.Config;

namespace shorten_url.Entities
{
    public class ShortenedCustomLink
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string DestinationLink { get; private set; }
        public string Code { get; private set; }
        public string ShortnedLink { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public ShortenedCustomLink(string title, string destinationLink)
        {
            Id = Guid.NewGuid();
            Title = title;
            DestinationLink = destinationLink;
            Code = GenerateCode();
            ShortnedLink = ShortenLink();
            CreatedAt = DateTime.Now;
        }

        public void Edit(string title, string destinationLink)
        {
            Title = title;
            DestinationLink = destinationLink;
        }

        private string GenerateCode()
        {
            return Title.Split(" ")[0];
        }

        private string ShortenLink()
        {
            return $"{Url.URL_BASE}/{Code}";
        }
    }
}