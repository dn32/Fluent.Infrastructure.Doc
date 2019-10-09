using Fluent.Architecture.Core.Attributes;
using Fluent.Architecture.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Redis
{
    /* 3. Example entity */
    public class User : FluentEntity
    {
        [Key, FluentRandomKeyValueOnAdd]
        public long Code { get; set; }

        public string Email { get; set; }
        
        [JsonIgnore]
        public string MD5Password { get; set; }

        public string Name { get; set; }
    }
}