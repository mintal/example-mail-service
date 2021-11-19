using System.ComponentModel.DataAnnotations;

namespace MailChimp
{
    public class MailSettings
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string Host { get; set; }
        [EmailAddress] public string Email { get; set; }
        public bool Ssl { get; set; }
        public int Port { get; set; }
    }
}
