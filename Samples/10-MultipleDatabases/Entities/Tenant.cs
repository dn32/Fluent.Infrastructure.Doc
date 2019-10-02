using System.ComponentModel.DataAnnotations;

namespace MultipleDatabases
{
    public class Tenant : BaseTenantEntity
    {
        [Key]
        public long Code { get; set; }

        public string Email { get; set; }
    }
}