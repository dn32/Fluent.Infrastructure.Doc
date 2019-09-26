using Fluent.Architecture.Core.Attributes;
using Fluent.Architecture.Entities;
using Fluent.Architecture.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Composition.Entities
{
    public class User : FluentEntity, IFluentInclusionEntity
    {
        [Key]
        public long Code { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(UserAuthorization.UserCode)), FluentComposition(LocalKey = nameof(Code), ExternalKey = nameof(UserAuthorization.UserCode))]
        public List<UserAuthorization> UserAuthorizations { get; set; }

        [FluentComposition(LocalKey = nameof(Code), ExternalKey = nameof(Entities.Adress.UserCode))]
        public Adress Adress { get; set; }

        public string[] InclusionsForList => new[] { nameof(UserAuthorizations), nameof(Adress) };

        public string[] InclusionsForOne => new[] { nameof(UserAuthorizations), nameof(Adress) };
    }
}