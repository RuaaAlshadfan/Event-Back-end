namespace DomainLayer.Dto
{
    public class GetCustomerDTO : GetAuditModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int MobileNumber { get; set; }
        public int NumberOfPeople { get; set; }
        public string Note { get; set; }
    }
}
