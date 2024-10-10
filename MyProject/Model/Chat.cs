namespace MyProject.Model
{
    public class Chat
    {
        public int ChatId { get; set; }  // Primary Key
        public string Message { get; set; }
        public DateTime SentDateTime { get; set; }  // Renamed to match diagram

        // Navigation Properties
        public User FromUser { get; set; }  // Sender
        public User ToUser { get; set; }  // Receiver
    }
}
