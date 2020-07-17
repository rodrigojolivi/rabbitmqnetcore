using RabbitMQ.Publisher.Extensios;
using System;

namespace RabbitMQ.Publisher.Domain
{
    public class User
    {
        public User(string name, string email, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;

            EncryptPassword(password);
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateUpdated { get; private set; }

        private void EncryptPassword(string password)
        {
            Password = password.Encrypt();
        }
    }
}
