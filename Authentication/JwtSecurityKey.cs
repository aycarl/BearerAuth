using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace BearerAuth
{
    public class JwtSecurityKey
    {
        internal static IConfiguration Configuration;

        public JwtSecurityKey(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Creates a JWT <c>SecurityKey</c> from provided secret paramerter
        /// </summary>
        /// <param name="secret"></param>
        /// <returns></returns>
        public SecurityKey Create()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Key"]));
        }
    }
}