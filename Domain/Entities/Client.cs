using FluentValidator.Validation;
using Shared.Entities;
using System;
using System.Text;

namespace Domain.Entities
{
    public class Client : Entity
    {
        protected Client() { }
        public Client(string name, string userName, string email, string password, string clienteUniqueId)
        {
            Name = name;
            UserName = userName;
            ClientUniqueId = clienteUniqueId;
            Email = email;
            Password = password;
            if (String.IsNullOrEmpty(Name))
                AddNotification("Name", "Nome é obrigatório");
            if (String.IsNullOrEmpty(clienteUniqueId))
                AddNotification("ClientUniqueId", "Documento obrigatório");
            AddNotifications();
            if (Notifications.Count == 0)
            {
                var contract = new ValidationContract()
                    .Requires()
                    .HasMaxLen(ClientUniqueId, 20, "ClientUniqueId", "Identificador deve ter até 20 caracteres")
                    .HasMaxLen(Name, 100, "Name", "Nome deve ter até 100 caracteres");
                AddNotifications(contract.Notifications);
            }
            
        }
        public string Name { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string ClientUniqueId { get; private set; }
        public string Password { get; private set; }

        public bool Authenticate(string username, string password)
        {
            //todo: encriptar pass
            if (UserName == username && Password == password)
                return true;

            AddNotification("User", "Usuário ou senha inválidos");
            return false;
        }

        private string EncryptPassword(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return "";
            var password = (pass += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }

    }
}
