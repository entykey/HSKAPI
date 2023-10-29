namespace HSKAPI.Models.DomainModels
{
    using Extensions;
    using System.ComponentModel.DataAnnotations;

    public class Diem
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Id_User { get; set; }
        public string Id_Level { get; set; }
        [MaxLength(50)]
        public string Diemso { get; set; }
        public int Socaudung { get; set; }
        public int Socauhoi { get; set; }
        public DateTimeOffset Ngaythi { get; set; } = DateTimeHelper.GetCurrentTimeInDesiredTimeZone();
        public User? User { get; set; }
    }
}
