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

    public class SongsController : ApiController
    {
        private readonly MusicStoreEntities db = new MusicStoreEntities();

        public SongsController()
        {
            this.db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/Songs
        public IEnumerable<SongDto> GetSongs()
        {
            IQueryable<SongDto> songs =
                from song in this.db.Songs
                                 .Include(s => s.Album)
                                 .Include(s => s.Artist)
                select new SongDto
                           {
                               SongId = song.SongId, 
                               ArtistId = song.ArtistId, 
                               AlbumId = song.AlbumId, 
                               SongTitle = song.SongTitle, 
                               SongYear = song.SongYear, 
                               Genre = song.Genre
                           };

            return songs.AsEnumerable();
        }

        // GET api/Songs/5
        public SongDto GetSong(int id)
        {
            Song song = this.db.Songs.Find(id);
            if (song == null)
            {
                throw new HttpResponseException(
                    this.Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new SongDto
                       {
                           SongId = song.SongId, 
                           ArtistId = song.ArtistId, 
                           AlbumId = song.AlbumId, 
                           SongTitle = song.SongTitle, 
                           SongYear = song.SongYear, 
                           Genre = song.Genre
                       };
        }

        // PUT api/Songs/5
        public HttpResponseMessage PutSong(int id, SongDto song)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Request.CreateErrorResponse(
                                                        HttpStatusCode.BadRequest, 
                                                        this.ModelState);
            }

            Song songToUpdate = this.db.Songs.FirstOrDefault(s => s.SongId == id);

            if (songToUpdate != null && song != null)
            {
                songToUpdate.UpdateWith(
                                        new Song
                                            {
                                                SongTitle = song.SongTitle, 
                                                SongYear = song.SongYear, 
                                                Genre = song.Genre
                                            });
            }
            else
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            this.db.Entry(songToUpdate).State = EntityState.Modified;

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

        // POST api/Songs
        public HttpResponseMessage PostSong(string artistName, string albumTitle, [FromBody] SongDto song)
        {
            if (string.IsNullOrWhiteSpace(artistName) || string.IsNullOrWhiteSpace(albumTitle))
            {
                return this.Request.CreateErrorResponse(
                                                        HttpStatusCode.BadRequest, 
                                                        this.ModelState);
            }

            Artist artist = this.db.Artists
                                .Include(a => a.Albums)
                                .SingleOrDefault(a => a.ArtistName == artistName);

            if (artist == null)
            {
                return this.Request.CreateErrorResponse(
                                                        HttpStatusCode.BadRequest, 
                                                        this.ModelState);
            }

            Album album = artist.Albums.SingleOrDefault(a => a.AlbumTitle == albumTitle);
            if (album == null)
            {
                return this.Request.CreateErrorResponse(
                                                        HttpStatusCode.BadRequest, 
                                                        this.ModelState);
            }

            if (album.Songs.Any(s => s.SongTitle == song.SongTitle))
            {
                return this.Request.CreateErrorResponse(
                                                        HttpStatusCode.BadRequest, 
                                                        this.ModelState);
            }

            if (!this.ModelState.IsValid)
            {
                return this.Request.CreateErrorResponse(
                                                        HttpStatusCode.BadRequest, 
                                                        this.ModelState);
            }

            Song newSong = new Song
                               {
                                   SongTitle = song.SongTitle, 
                                   SongYear = song.SongYear, 
                                   Genre = song.Genre, 
                                   Artist = artist, 
                                   Album = album
                               };

            this.db.Songs.Add(newSong);
            this.db.SaveChanges();

            HttpResponseMessage response = this.Request.CreateResponse(
                                                                       HttpStatusCode.Created, 
                                                                       newSong);
            response.Headers.Location = new Uri(
                this.Url.Link("DefaultApi", new { id = newSong.SongId }));
            return response;
        }

        // DELETE api/Songs/5
        public HttpResponseMessage DeleteSong(int id)
        {
            Song song = this.db.Songs.Find(id);
            if (song == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            }

            this.db.Songs.Remove(song);

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, song);
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}