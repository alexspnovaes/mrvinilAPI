using Domain.Enumerators;
using FluentValidator.Validation;
using Shared.Entities;
using System;

namespace Domain.Entities
{
    public class Disk : Entity
    {
        protected Disk(){ }
        public Disk(string name, string description, decimal price, EDiskGenre genre, string imageUrl)
        {
            Name = name;
            Description = description;            
            Price = price;
            Genre = genre;
            ImageURL = imageUrl;
            new ValidationContract()
                                  .IsNotNullOrEmpty(Name, "Name", "Nome é obrigatório")
                                   .HasMaxLen(Name, 100, "Name", "Nome deve ter até 100 caracteres")
                                   .IsNotNullOrEmpty(Description, "Description", "Descrição é obrigatório")
                                   .HasMaxLen(Description, 300, "Description", "Descrição deve ter até 300 caracteres")
                                   .IsGreaterThan(Price, 0, "Price", "Preço deve ser maior que zero");

        }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public EDiskGenre Genre { get ; private set; }
        public string GenreDescription { get => Enum.GetName(typeof(EDiskGenre), Genre); }
        public string ImageURL { get; private set; }
    }
}
