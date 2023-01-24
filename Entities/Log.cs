namespace Task5_0.Entities
{
    public class Log : BasicEntity
    {
        public Log()
        {
            Content = string.Empty;
        }


        [Required]
        public string Content { get; set; }
        [Required]
        public bool Is_Exception { get; set; }
        [Required]
        public int Test_Id { get; set; }
    }
}