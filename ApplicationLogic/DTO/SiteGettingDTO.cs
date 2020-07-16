using Domain;

namespace ApplicationLogic.DTO
{
    public class SiteGettingDTO
    {
        public int Id { get; set; }
        public string SiteUrl { get; set; }

        public static SiteGettingDTO MapFromSiteEntity(Site site) => new SiteGettingDTO
        {
            Id = site.Id,
            SiteUrl = site.SiteUrl
        };
    }
}