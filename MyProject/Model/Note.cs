﻿namespace MyProject.Model
{
    public class Note
    {
        public int Id { get; set; }  // Primary Key
        public string NoteContent { get; set; }

        // Navigation Property (User who created the note)
        public User User { get; set; }
    }
}
