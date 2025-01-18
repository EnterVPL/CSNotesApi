using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    private readonly AppDbContext _context;

    public NotesController(AppDbContext context)
    {
        _context = context;
    }

    // Get all notes
    [HttpGet]
    public ActionResult<IEnumerable<Note>> GetAll()
    {
        return Ok(_context.Notes.ToList());
    }

    // Get a note by id
    [HttpGet("{id}")]
    public ActionResult<Note> GetById(Guid id)
    {
        var note = _context.Notes.Find(id);
        if (note == null) return NotFound();
        return Ok(note);
    }

    // Create a new note
    [HttpPost]
    public ActionResult<Note> Create(Note note)
    {
        note.Id = Guid.NewGuid(); // Ensure new UUID for created note
        _context.Notes.Add(note);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = note.Id }, note);
    }

    // Update a note
    [HttpPut("{id}")]
    public IActionResult Update(Guid id, Note note)
    {
        if (id != note.Id) return BadRequest();

        var existingNote = _context.Notes.Find(id);
        if (existingNote == null) return NotFound();

        existingNote.Title = note.Title;
        existingNote.Content = note.Content;

        _context.SaveChanges();
        return NoContent();
    }

    // Delete a note
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var note = _context.Notes.Find(id);
        if (note == null) return NotFound();

        _context.Notes.Remove(note);
        _context.SaveChanges();
        return NoContent();
    }
}