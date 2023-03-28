using FlashcardsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlashcardsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlashcardController : Controller
    {
        private readonly FlashContext _context;

        public FlashcardController(FlashContext context) 
        {
            this._context = context;
        }

        //Get all flashcards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> GetAllFlashCards()
        {
            return await _context.Flashcards.ToListAsync();
        }

        //Get flashcard by id
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Card>>> GetFlashCard(Guid id)
        {
            return await _context.Flashcards.Where(x => x.Id == id).ToListAsync();
        }

        //post flashcard
        [HttpPost]
        public async Task<ActionResult<Card>> PostFlashcard(Card c)
        {
            c.Id = Guid.Empty;
            _context.Flashcards.Add(c);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostFlashcard", new { id = c.Id }, c);
        }

        //delete flashcard
        [HttpDelete("{id}")]
        public async Task<ActionResult<Card>> DeleteFlashcard(Guid id)
        {
            var card = await _context.Flashcards.FindAsync(id);


            if (card is null)
                return NotFound();

            _context.Flashcards.Remove(card);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //update flashcard
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlashcard(Guid id, Card card)
        {
            _context.Entry(card).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Flashcards.Any(e => e.Id == id))
                    return NotFound();
                else throw;
            }

            return NoContent();
        }
    }
}
