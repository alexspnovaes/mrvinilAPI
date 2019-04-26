using FluentValidator;
using System;

namespace Shared.Entities
{
    public class Entity : Notifiable
    {
        public Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}