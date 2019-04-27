using SportConnect.Core.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportConnect.Core.Domain
{
    [Table(nameof(Role))]
    public class Role : Entity<Enums.Role>
    {
        public string RoleName { get; set; }
    }
}
