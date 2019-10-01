using System.ComponentModel.DataAnnotations;

namespace MultipleDatabases
{
    public class User : BaseEntity
    {
        [Key]
        public long Code { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }
    }
}