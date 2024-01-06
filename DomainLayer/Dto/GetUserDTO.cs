namespace DomainLayer.Dto
{
    public class GetUserDTO : GetAuditModel
    {
        
        public string Name { get; set; }
        public string Emailaddress { get; set; }
        public string Password { get; set; }
        public int MobileNumber { get; set; }

    }
}
