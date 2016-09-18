namespace Bangalore_University_Learning_System.Utilities
{
    using Models;

    public static class UserRoleUtilities
    {
        public static bool IsInRole(this User user, Role role)
        {
            return user != null && user.Role == role;
        }
    }
}
