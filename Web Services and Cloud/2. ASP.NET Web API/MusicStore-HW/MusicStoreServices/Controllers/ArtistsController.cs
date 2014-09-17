namespace MusicStoreServices.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using MusicStoreModels;

    using MusicStoreServices.Models;

    public class ArtistsController : ApiController
    {
        private readonly MusicStoreEntities db = new MusicStoreEntities();

        public ArtistsController()
        {
            this.db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/Artists
        public IEnumerable<ArtistDto> GetArtists()
        {
            IQueryable<ArtistDto> artists = from artist in this.db.Artists.Include(a => a.Songs)
                                            select new ArtistDto
                                                       {
                                                           ArtistId = artist.ArtistId, 
                                                           ArtistName = artist.ArtistName, 
                                                           Country = artist.Country, 
                                                           DateOfBirth = artist.DateOfBirth, 
                                                           Songs = (from song in artist.Songs
                                                                    select new SongDto
                                                                               {
                                                                                   SongId = song.SongId, 
                                                                                   ArtistId = song.ArtistId, 
                                                                                   AlbumId = song.AlbumId, 
                                                                                   SongTitle = song.SongTitle, 
                                                                                   SongYear = song.SongYear, 
                                                                                   Genre = song.Genre
                                                                               }).AsEnumerable()
                                                       };

            return artists.AsEnumerable();
        }

        // GET api/Artists/5
        public ArtistDto GetArtist(int id)
        {
            Artist artist = this.db.Artists.Find(id);
            if (artist == null)
            {
                throw new HttpResponseException(this.Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new ArtistDto
                       {
                           ArtistId = artist.ArtistId, 
                           ArtistName = artist.ArtistName, 
                           Country = artist.Country, 
                           DateOfBirth = artist.DateOfBirth
                       };
        }

        // PUT api/Artists/5
        public HttpResponseMessage PutArtist(int id, ArtistDto artist)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
            }

            Artist artistToUpdate = this.db.Artists.FirstOrDefault(a => a.ArtistId == id);

            if (artistToUpdate != null && artist != null)
            {
                artistToUpdate.UpdateWith(
                                          new Artist
                                              {
                                                  ArtistName = artist.ArtistName, 
                                                  Country = artist.Country, 
                                                  DateOfBirth = artist.DateOfBirth
                                              });
            }
            else
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            this.db.Entry(artistToUpdate).State = EntityState.Modified;

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Artists
        public HttpResponseMessage PostArtist(ArtistDto artist)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
            }

            Artist newArtist = new Artist
                                   {
                                       ArtistName = artist.ArtistName, 
                                       Country = artist.Country, 
                                       DateOfBirth = artist.DateOfBirth
                                   };

            this.db.Artists.Add(newArtist);
            this.db.SaveChanges();

            HttpResponseMessage response = this.Request.CreateResponse(HttpStatusCode.Created, newArtist);
            response.Headers.Location = new Uri(this.Url.Link("DefaultApi", new { id = newArtist.ArtistId }));
            return response;
        }

        // DELETE api/Artists/5
        public HttpResponseMessage DeleteArtist(int id)
        {
            Artist artist =
                this.db.Artists.Include(a => a.Albums).Include(a => a.Songs).FirstOrDefault(a => a.ArtistId == id);
            if (artist == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            }

            List<int> songIds = artist.Songs.Select(song => song.SongId).ToList();

            foreach (int songId in songIds)
            {
                this.db.Songs.Remove(this.db.Songs.Single(s => s.SongId == songId));
            }

            List<int> albumIds = artist.Albums.Select(album => album.AlbumId).ToList();

            foreach (int albumId in albumIds)
            {
                this.db.Albums.Remove(this.db.Albums.Single(a => a.AlbumId == albumId));
            }

            this.db.Artists.Remove(artist);

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, artist);
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}