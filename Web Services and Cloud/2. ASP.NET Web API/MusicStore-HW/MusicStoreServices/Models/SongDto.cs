namespace MusicStoreServices.Models
{
    public class SongDto
    {
        public int SongId { get; set; }

        public int? ArtistId { get; set; }

        public int? AlbumId { get; set; }

        public string SongTitle { get; set; }

        public int? SongYear { get; set; }

        public string Genre { get; set; }
    }
}