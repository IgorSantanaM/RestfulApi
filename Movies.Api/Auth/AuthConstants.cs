namespace Movies.Api.Auth
{
    public static class AuthConstants
    {
        public const string AdminUserPolicyName = "Admin";
        public const string AdminClaimName = "admin";
        public const string TrustedUserPolicyName = "Trusted";
        public const string TrustedUserClaimName = "trusted_member";

        public const string ApiKeyHeaderName = "x-api-key";
    }
}
