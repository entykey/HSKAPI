namespace HSKAPI.Models.DomainModels
{
    using Extensions;
    using System.ComponentModel.DataAnnotations;

    public class Favorite
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Id_User { get; set; }
        public string Id_Loai { get; set; } // ????
        public string Loai { get; set; }    // ????
        public DateTimeOffset Ngayluu { get; set; } = DateTimeHelper.GetCurrentTimeInDesiredTimeZone();
        public User? User { get; set; }
    }
}
