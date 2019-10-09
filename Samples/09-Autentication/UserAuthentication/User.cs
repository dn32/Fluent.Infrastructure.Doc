using Fluent.Architecture.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Authentication.UserAuthentication
{
    /* 3. Example entity */
    public class User : FluentEntity
    {
        [Key]
        public long Code { get; set; }

        public string Email { get; set; }
        
        public string MD5Password { get; set; }

        public string Name { get; set; }
    }
}