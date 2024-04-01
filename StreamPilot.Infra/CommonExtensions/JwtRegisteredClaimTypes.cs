namespace StreamPilot.Infra.CommonExtensions
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/azure/active-directory/develop/reference-claims-mapping-policy-type
    /// </summary>
    public struct JwtRegisteredClaimTypes
    {
        /// <summary>
        /// </summary>
        public const string Actort = "actort";

        /// <summary>
        /// http://openid.net/specs/openid-connect-core-1_0.html#IDToken
        /// </summary>
        public const string AuthTime = "auth_time";

        /// <summary>
        /// https://openid.net/specs/openid-connect-core-1_0.html#StandardClaims
        /// </summary>
        public const string Birthdate = "birth_date";

        /// <summary>
        /// https://openid.net/specs/openid-connect-core-1_0.html#StandardClaims
        /// </summary>
        public const string Email = "email";

        /// <summary>
        /// https://openid.net/specs/openid-connect-core-1_0.html#StandardClaims
        /// </summary>
        public const string Gender = "gender";

        /// <summary>
        /// https://openid.net/specs/openid-connect-core-1_0.html#StandardClaims
        /// </summary>
        public const string FamilyName = "family_name";

        /// <summary>
        /// https://openid.net/specs/openid-connect-core-1_0.html#StandardClaims
        /// </summary>
        public const string GivenName = "given_name";

        /// <summary>
        /// https://openid.net/specs/openid-connect-core-1_0.html#StandardClaims
        /// </summary>
        public const string Name = "name";

        /// <summary>
        /// </summary>
        public const string NameId = "nameId";

        /// <summary>
        /// </summary>
        public const string NameIdentifier = "name_identifier";

        /// <summary>
        /// https://datatracker.ietf.org/doc/html/rfc7519#section-5
        /// </summary>
        public const string Type = "type";

        /// <summary>
        /// </summary>
        public const string UniqueName = "unique_name";

        /// <summary>
        /// </summary>
        public const string Website = "website";
    }
}
