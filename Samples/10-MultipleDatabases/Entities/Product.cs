using System.ComponentModel.DataAnnotations;

namespace MultipleDatabases
{
    public class Product : BaseEntity
    {
        [Key]
        public long Code { get; set; }

        public string Name { get; set; }
    }
}