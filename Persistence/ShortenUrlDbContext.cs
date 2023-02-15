using shorten_url.Entities;

namespace shorten_url.Persistence
{
    public class ShortenUrlDbContext
    {
        public IList<ShortenedCustomLink> Links { get; private set; }

        public ShortenUrlDbContext()
        {
            Links = new List<ShortenedCustomLink>();
        }

        public void Add(ShortenedCustomLink link)
        {
            Links.Add(link);
        }
    }
}