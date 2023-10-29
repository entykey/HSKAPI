namespace HSKAPI.Models.DomainModels.UserAgent
{
    using System.ComponentModel.DataAnnotations;

    public class DeviceInfo
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }

        public UserAgentOS? OS { get; set; }

        public UserAgentDevice? Device { get; set; }

        public UserAgentBrowser? Browser { get; set; }
    }
}