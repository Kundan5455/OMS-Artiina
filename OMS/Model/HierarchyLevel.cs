using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMS.Model;

[Dapper.Contrib.Extensions.Table("HierarchyLevel")]
public partial class HierarchyLevel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? AccessLevel { get; set; }

    [Write(false)]
    public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();
}
