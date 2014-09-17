﻿namespace MusicStoreModels
{
    public partial class Artist
    {
        public void UpdateWith(Artist artist)
        {
            if (!string.IsNullOrWhiteSpace(artist.ArtistName))
            {
                this.ArtistName = artist.ArtistName;
            }

            if (!string.IsNullOrWhiteSpace(artist.Country))
            {
                this.Country = artist.Country;
            }

            if (artist.DateOfBirth.HasValue)
            {
                this.DateOfBirth = artist.DateOfBirth;
            }
        }
    }
}