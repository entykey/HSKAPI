namespace HSKAPI.Models.DomainModels
{
    using Extensions;
    using System.ComponentModel.DataAnnotations;

    public class Level
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = "Untitled";
        public string? Text { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTimeHelper.GetCurrentTimeInDesiredTimeZone();
        public User? User { get; set; }
    }
}
