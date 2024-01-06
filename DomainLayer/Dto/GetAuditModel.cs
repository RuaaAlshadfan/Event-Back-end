namespace DomainLayer.Dto
{
    public class GetAuditModel
    {
        public int Id { get; set; }
        public int CreaterUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsDeleted { get; set; }
        public int? DeletedUserId { get; set; }
    }
}
