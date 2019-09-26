using Fluent.Architecture.Entities;
using System.ComponentModel.DataAnnotations;

namespace Composition.Entities
{
    public class UserAuthorization : FluentEntity
    {
        [Key]
        public long Code { get; set; }
        public long UserCode { get; set; }
        public string AuthName { get; set; }
    }
}