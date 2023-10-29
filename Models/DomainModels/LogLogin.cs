namespace HSKAPI.Models.DomainModels
{
    using Extensions;
    using Models.DomainModels.UserAgent;
    using System.ComponentModel.DataAnnotations;

    public class LogLogin
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserName { get; set; }
        public int UserType { get; set; }
        public DeviceInfo? DeviceInfo { get; set; }
        public DateTimeOffset? Time { get; set; } = DateTimeHelper.GetCurrentTimeInDesiredTimeZone();
        public User? User { get; set; }
    }
}