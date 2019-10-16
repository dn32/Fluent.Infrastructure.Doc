using Fluent.Architecture.Core.Attributes;
using Fluent.Architecture.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace CustomController
{
    [FluentAPIController(AutomaticGeneration = false)]
    public class EntityNotAutomaticGenerationApi : FluentEntity
    {
        [Key]
        public long Code { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }
    }
}