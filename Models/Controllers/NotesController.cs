using Microsoft.AspNetCore.Mvc;
using NotesApp.Models;

namespace NotesApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private static List<Note> notes = new List<Note>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(notes);
        }

        [HttpPost]
        public IActionResult Create(Note note)
        {
            note.Id = notes.Count + 1;
            notes.Add(note);
            return Ok(note);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Note updated)
        {
            var note = notes.FirstOrDefault(n => n.Id == id);
            if (note == null) return NotFound();

            note.Title = updated.Title;
            note.Content = updated.Content;
            return Ok(note);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var note = notes.FirstOrDefault(n => n.Id == id);
            if (note == null) return NotFound();

            notes.Remove(note);
            return Ok();
        }
    }
}