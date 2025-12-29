namespace ERPAppApplication.DTOs.AuthenticationDTOs
{
    public class AuthResultDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public UserDto User { get; set; } = default!;
    }
}
