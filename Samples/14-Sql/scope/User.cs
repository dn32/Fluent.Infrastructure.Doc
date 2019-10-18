using Fluent.Architecture.Attributes;
using Fluent.Architecture.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace SimpleHelloWorld
{
    /* 3. Example entity */
    public class User : FluentEntity
    {
        [Key]
        public long Code { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public PernonType PernonType { get; set; }
    }

    [FluentEnumValueForSetNull(value: 0)]
    public enum PernonType
    {
        None = 0,
        LegalPerson = 1,
        PhysicalPerson = 2
    }
}