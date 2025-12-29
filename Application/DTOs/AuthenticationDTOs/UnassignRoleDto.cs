namespace ERPAppApplication.DTOs.AuthenticationDTOs
{
    public class UnassignRoleDto
    {
        public Guid UserId { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }
}
