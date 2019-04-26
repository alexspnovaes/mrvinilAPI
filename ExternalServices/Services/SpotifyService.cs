using Domain.Entities;
using Domain.Enumerators;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExternalServices.Services
{
    public class SpotifyService : ISpotifyService
    {
        private const string CLIENTID = "5b4acedfe4624dc6a452f92b21e14f01";
        private const string SECRET = "c48eb7be56244729911958623fc3eb09";
        public List<Disk> GetTop50ByGenre()
        {
            var auth = new CredentialsAuth(CLIENTID, SECRET);
            var token = auth.GetToken().Result;
            var api = new SpotifyWebAPI() { TokenType = token.TokenType, AccessToken = token.AccessToken };
            var genres = Enum.GetValues(typeof(EDiskGenre));
            List<Disk> disks = new List<Disk>();


            //search the top 50 albums by genre and add in the disk list
            foreach (var g in genres)
            {
                SearchItem search = api.SearchItems(g.ToString(), SearchType.Album, 50);

                foreach (var sDisk in search.Albums.Items)
                {                    
                    decimal value = Convert.ToDecimal(string.Format("{0:0.##}", new Random().NextDouble() * 10));
                    var description = $"Released Date: {sDisk.ReleaseDate} | URI: {sDisk.Uri} | Album Type: {sDisk.AlbumType}  | Artists: {string.Join<string>(",", sDisk.Artists.Select(x=> x.Name).ToArray())}";
                    disks.Add(new Disk(sDisk.Name, description, value, (EDiskGenre)g,sDisk.Images.FirstOrDefault().Url));
                }

            }

            return disks;
        }
    }
}