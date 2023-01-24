namespace Task5_0.Entities
{
    public class Test : BasicEntity
    {
        public Test()
        {
            Name = string.Empty;
            Method_Name = string.Empty;
            Env = string.Empty;
        }

        [Required]
        public string Name { get; set; }
        public int? Status_Id { get; set; }
        [Required]
        public string Method_Name { get; set; }
        [Required]
        public int Project_Id { get; set; }
        [Required]
        public int Session_Id { get; set; }
        public DateTime? Start_Time { get; set; }
        public DateTime? End_Time { get; set; }
        [Required]
        public string Env { get; set; }
        public string? Browser { get; set; }
        public int? Author_Id { get; set; }
    }
}