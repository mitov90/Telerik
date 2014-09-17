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

    public class AlbumsController : ApiController
    {
        private readonly MusicStoreEntities db = new MusicStoreEntities();

        public AlbumsController()
        {
            this.db.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/Albums
        public IEnumerable<AlbumDto> GetAlbums()
        {
            IQueryable<AlbumDto> albums =
                from album in this.db.Albums.Include(a => a.Songs)
                select new AlbumDto
                           {
                               AlbumId = album.AlbumId, 
                               AlbumTitle = album.AlbumTitle, 
                               AlbumYear = album.AlbumYear, 
                               Producer = album.Producer, 
                               Songs =
                                   (from song in album.Songs
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

            return albums.AsEnumerable();
        }

        // GET api/Albums/5
        public AlbumDto GetAlbum(int id)
        {
            Album album = this.db.Albums.Find(id);
            if (album == null)
            {
                throw new HttpResponseException(this.Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return new AlbumDto
                       {
                           AlbumId = album.AlbumId, 
                           AlbumTitle = album.AlbumTitle, 
                           AlbumYear = album.AlbumYear, 
                           Producer = album.Producer
                       };
        }

        // PUT api/Albums/5
        public HttpResponseMessage PutAlbum(int id, AlbumDto album)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState);
            }

            Album albumToUpdate = this.db.Albums.FirstOrDefault(a => a.AlbumId == id);

            if (albumToUpdate != null && album != null)
            {
                albumToUpdate.UpdateWith(
                                         new Album
                                             {
                                                 AlbumTitle = album.AlbumTitle, 
                                                 AlbumYear = album.AlbumYear, 
                                                 Producer = album.Producer
                                             });
            }
            else
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            this.db.Entry(albumToUpdate).State = EntityState.Modified;

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

        // POST api/Albums
        public HttpResponseMessage PostAlbum(string artistName, [FromBody] AlbumDto album)
        {
            if (string.IsNullOrWhiteSpace(artistName))
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

            if (artist.Albums.Any(a => a.AlbumTitle == album.AlbumTitle))
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

            Album newAlbum = new Album
                                 {
                                     AlbumTitle = album.AlbumTitle, 
                                     AlbumYear = album.AlbumYear, 
                                     Producer = album.Producer
                                 };

            this.db.Albums.Add(newAlbum);
            artist.Albums.Add(newAlbum);
            this.db.SaveChanges();

            HttpResponseMessage response = this.Request.CreateResponse(
                                                                       HttpStatusCode.Created, 
                                                                       newAlbum);
            response.Headers.Location = new Uri(
                this.Url.Link("DefaultApi", new { id = newAlbum.AlbumId }));
            return response;
        }

        // DELETE api/Albums/5
        public HttpResponseMessage DeleteAlbum(int id)
        {
            Album album =
                this.db.Albums.Include(a => a.Artists).Include(a => a.Songs).FirstOrDefault(a => a.AlbumId == id);
            if (album == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            }

            List<int> songIds = album.Songs.Select(song => song.SongId).ToList();

            foreach (int songId in songIds)
            {
                this.db.Songs.Remove(this.db.Songs.Single(s => s.SongId == songId));
            }

            album.Artists.Clear();

            this.db.Albums.Remove(album);

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK, album);
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}