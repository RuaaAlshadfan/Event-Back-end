namespace DomainLayer.Dto
{
    public class GetEventDTO: GetAuditModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int UserId { get; set; }
    }
}
