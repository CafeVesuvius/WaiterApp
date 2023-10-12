namespace MenuKortV1.Model
{
    public class UserLoginInfo
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public enum RoleDetails
        {
            Chef,
            Waiter,
            Other,
        }
    }
}
