using System;

namespace RabbitMQ.Publisher.Extensios
{
    public static class Cryptography
    {
        public static string Encrypt(this string password)
        {
            return $"{password}{Guid.NewGuid()}"; // FAKE
        }
    }
}
