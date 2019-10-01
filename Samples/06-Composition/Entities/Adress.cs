using Fluent.Architecture.Core.Attributes;
using Fluent.Architecture.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Composition.Entities
{
    public class Adress : FluentEntity
    {
        [Key, FluentRandomKeyValueOnAdd]
        public string Code { get; set; }

        [ForeignKey(nameof(User))]
        public long UserCode { get; set; }

        public string adress { get; set; }
    }
}