namespace HSKAPI.Models.DomainModels
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;
    using Extensions;
    using Models.DomainModels.UserAgent;

    public class User : IdentityUser
    {
        // additional properties will go here

        public string? Phone { get; set; }
        public int UserType { get; set; }
        public int Active { get; set; }
        public DeviceInfo? DeviceInfo { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [MaxLength(100)]
        public string? FullName { get; set; }
        public DateTimeOffset? CreatedDate { get; set; } = DateTimeHelper.GetCurrentTimeInDesiredTimeZone();  // GetCurrentTimeInDesiredTimeZone();
        public DateTimeOffset? UpdatedDate { get; set; } = DateTimeOffset.UtcNow;
        public string? Country { set; get; }
        [MaxLength(100)]
        public string? City { set; get; }
        [MaxLength(255)]
        public string? Address { set; get; }
        [DataType(DataType.Date)]
        public DateTime? Birthday { set; get; }
        [MaxLength(100)]
        public string? Gender { set; get; }
        [MaxLength(100)]
        public string? University { set; get; }
        [MaxLength(260)]
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public IList<LogLogin>? LogLogins { get; set; }
        public IList<Favorite>? Favorites { get; set; }
        public IList<Diem>? Diems { get; set; }
        public virtual LienHe? LienHe { get; set; }

    }
}
