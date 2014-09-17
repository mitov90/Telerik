namespace MusicStoreServices.Models
{
    using System;
    using System.Collections.Generic;

    public class ArtistDto
    {
        public int ArtistId { get; set; }

        public string ArtistName { get; set; }

        public string Country { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public IEnumerable<SongDto> Songs { get; set; }
    }
}