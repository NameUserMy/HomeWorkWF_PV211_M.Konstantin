namespace P.F.M.Models
{
    internal class Settings
    {
        public int Id { get; set; }
        public string? About { get; set; }
        public string? login { get; set; }
        public string? Pass { get; set; }
        public  int UserId { get; set; }
        public User? User { get; set; } = null!;

    }
}
