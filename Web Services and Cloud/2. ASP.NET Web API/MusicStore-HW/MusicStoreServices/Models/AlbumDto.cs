namespace MusicStoreServices.Models
{
    using System.Collections.Generic;

    public class AlbumDto
    {
        public int AlbumId { get; set; }

        public string AlbumTitle { get; set; }

        public int? AlbumYear { get; set; }

        public string Producer { get; set; }

        public IEnumerable<SongDto> Songs { get; set; }
    }
}