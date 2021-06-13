using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
	public static class Config
	{
		public static IEnumerable<IdentityResource> GetIdentityResources()
		{
			return new List<IdentityResource>
			{
			new IdentityResources.OpenId(),
			new IdentityResources.Profile(),
			new IdentityResources.Email()
			};
		}

		public static IEnumerable<ApiScope> GetApiScopes()
		{
			return new List<ApiScope>
			{
			new ApiScope("api1", "My API"),
			new ApiScope("scope1"),
			new ApiScope("scope2"),
			new ApiScope("Profile"),
			new ApiScope("OpenId")
			};
		}

		public static IEnumerable<Client> GetClients()
		{
			return new List<Client>
			{
				new Client
				{
					ClientId = "client",
					ClientSecrets = { new Secret("secret".Sha256()) },

					AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
					// scopes that client has access to
					AllowedScopes= new List<string>
					{
						IdentityServerConstants.StandardScopes.OpenId,
						IdentityServerConstants.StandardScopes.Profile,
						"api1"
					}
				}
			};
		}
	}
}
