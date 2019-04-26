using Data.Context;
using Domain.Entities;
using ExternalServices.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Seed
{
    public static class DbInitializer
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            //SpotifyService spotifyService = (SpotifyService)serviceProvider.GetRequiredService<ISpotifyService>();
            //MrVinilContext context = serviceProvider.GetRequiredService<MrVinilContext>();
            //List<Disk> disks = spotifyService.GetTop50ByGenre();
            //foreach (var item in disks)
            //{
            //    context.Disks.Add(item);
            //}
            //context.SaveChanges();

            //context.Clients.Add(new Client("Kauê Benjamin Samuel da Mota", "51930843976", ""));
            //context.Clients.Add(new Client("Matheus Lucca César Viana", "02614997692"));
            //context.Clients.Add(new Client("Tiago Yago Renato Almeida", "19682373484"));
            //context.Clients.Add(new Client("Vinicius Samuel Assis", "07018331811"));
            //context.SaveChanges();

        }


    }
}
