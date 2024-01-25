namespace UsersManagerApi.Data.SwaggerContracts
{
    public class UserContract
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<PhysicalPersonContract> PhysicalPersons { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }

    public class PhysicalPersonContract
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public List<AddressContract> Addresses { get; set; }
        public List<ContactContract> Contacts { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }

    public class AddressContract
    {
        public string Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostalCode { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }

    public class ContactContract
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string EmailOrPhone { get; set; }
    }
}
