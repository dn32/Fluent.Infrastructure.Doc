﻿using Fluent.Architecture.Entities;
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
    }
}