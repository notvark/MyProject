using Microsoft.EntityFrameworkCore;
using MyProject.Model;

namespace MyProject.Context
{
    public class NoteProvider
    {

        private readonly DatabaseContext _context;

        public NoteProvider(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Note>> GetAllNotesAsync()
        {
            return await _context.Notes.ToListAsync();
        }

        public async Task AddNoteAsync(Note note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
        }

    }
}
