using Domain.Entities;
using System.Collections.Generic;

namespace ExternalServices.Services
{
    public interface ISpotifyService
    {
        List<Disk> GetTop50ByGenre();
    }
}