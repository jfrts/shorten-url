using Microsoft.AspNetCore.Mvc;
using shorten_url.Entities;
using shorten_url.Models;
using shorten_url.Persistence;

namespace shorten_url.Controllers
{
    [ApiController]
    [Route("api/shortenedLinks")]
    public class ShortenedLinksController : ControllerBase
    {
        private readonly ShortenUrlDbContext _context;

        public ShortenedLinksController(ShortenUrlDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Read()
        {
            return Ok(_context.Links);
        }

        [HttpGet("{id}")]
        public IActionResult ReadById(Guid id)
        {
            var link = GetLinkById(id);
            if (link == null) return NotFound();
            return Ok(link);
        }

        [HttpPost]
        public IActionResult Create(AddOrUpdateShortenedLink model)
        {
            var link = new ShortenedCustomLink(model.Title, model.DestinationLink);
            _context.Add(link);
            return CreatedAtAction("GetById", new { id = link.Id }, link);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, AddOrUpdateShortenedLink model)
        {
            var link = GetLinkById(id);
            if (link == null) return NotFound();
            link.Edit(model.Title, model.DestinationLink);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var link = GetLinkById(id);
            if (link == null) return NotFound();
            _context.Links.Remove(link);
            return Ok();
        }

        [HttpGet("/{code}")]
        public IActionResult RedirectLink(string code)
        {
            var link = _context.Links.SingleOrDefault(link => link.Code == code);
            if (link == null) return NotFound();
            return Redirect(link.DestinationLink);
        }

        private ShortenedCustomLink? GetLinkById(Guid id)
        {
            var link = _context.Links.SingleOrDefault(link => link.Id == id);
            return link;
        }
    }
}