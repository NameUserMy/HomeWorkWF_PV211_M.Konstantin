namespace P.F.M.Model
{
    internal class UserOperation
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int PFMTransactionId { get; set; }
        public PFMTransaction? PFMTransaction { get; set; }
    }
}
