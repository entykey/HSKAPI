namespace HSKAPI.Models.DomainModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class LienHe
    {
        // without this FK attribute  => Migration fail: The dependent side could not be determined for the one-to-one relationship between 'LienHe.User' and 'User.LienHe'. To identify the dependent side of the relationship, configure the foreign key property. If these navigations should not be part of the same relationship, configure them independently via separate method chains in 'OnModelCreating'. See http://go.microsoft.com/fwlink/?LinkId=724062 for more details.
        [ForeignKey("User")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? UserName { get; set; }
        public string Title { get; set; } = "Untitled";
        public string? Noidung { get; set; }
        [MaxLength(50)]
        public string Tinhtrang { get; set; }
        public DateTimeOffset Ngaytao { get; set; }
        public virtual User? User { get; set; }
    }
}
