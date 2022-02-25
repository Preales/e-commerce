using System;

namespace Ecommerce.Service.Dtos
{
    public class ClientDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class ClientUpdateDto : ClientDto
    {
        public DateTime? ModificationDate { get; set; }
    }
}