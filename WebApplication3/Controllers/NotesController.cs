using Microsoft.AspNetCore.Mvc;

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
    [HttpGet("{id:guid}")]
    public ActionResult<Note> GetById(Guid id)
    {
        var note = _context.Notes.Find(id);
        if (note == null) return NotFound();
        return Ok(note);
    }

    // Create a new note
    [HttpPost]
    public ActionResult<Note> Create(NoteRequestDto noteDto)
    {
        var note = new Note
        {
            Id = Guid.NewGuid(),
            Title = noteDto.Title,
            Content = noteDto.Content
        };
        _context.Notes.Add(note);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = note.Id }, note);
    }

    // Update a note
    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id, NoteRequestDto noteDto)
    {
        var existingNote = _context.Notes.Find(id);
        if (existingNote == null) return NotFound();

        existingNote.Title = noteDto.Title;
        existingNote.Content = noteDto.Content;

        _context.SaveChanges();
        return NoContent();
    }

    // Delete a note
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        var note = _context.Notes.Find(id);
        if (note == null) return NotFound();

        _context.Notes.Remove(note);
        _context.SaveChanges();
        return NoContent();
    }
}