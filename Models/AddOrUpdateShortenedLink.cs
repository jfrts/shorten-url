namespace shorten_url.Models
{
    public class AddOrUpdateShortenedLink
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string DestinationLink { get; set; }

        public AddOrUpdateShortenedLink(string title, string destinationLink)
        {
            Id = Guid.NewGuid();
            Title = title;
            DestinationLink = destinationLink;
        }

        public void Edit(string title, string destinationLink)
        {
            Title = title;
            DestinationLink = destinationLink;
        }
    }
}