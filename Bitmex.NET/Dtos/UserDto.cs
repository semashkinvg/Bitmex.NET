using System;

namespace Bitmex.NET.Dtos
{
    public class UserDto
    {
        public decimal? Id { get; set; }
        public decimal? OwnerId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? LastUpdated { get; set; }
        public UserPreferencesDto Preferences { get; set; }
        public string TFAEnabled { get; set; }
        public string AffiliateID { get; set; }
        public string PgpPubKey { get; set; }
        public string Country { get; set; }
        public string GeoipCountry { get; set; }
        public string GeoipRegion { get; set; }
        public string Typ { get; set; }


    }
}
