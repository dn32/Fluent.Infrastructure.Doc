using Fluent.Architecture.Core.Attributes;
using System.ComponentModel.DataAnnotations;
using Fluent.Architecture.Core.Models;

namespace Composition.Entities
{
    public class UserAuthorization : FluentEntity
    {
        [Key, FluentRandomKeyValueOnAdd]
        public long Code { get; set; }
        
        public long UserCode { get; set; }
        
        [FluentRequired]
        public string AuthName { get; set; }
    }
}