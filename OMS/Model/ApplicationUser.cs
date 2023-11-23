using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMS.Model;

[Dapper.Contrib.Extensions.Table("ApplicationUser")]
public partial class ApplicationUser
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public int? AccessLevel { get; set; }

    public bool? SendEmail { get; set; }

    [Write(false)]
    public virtual HierarchyLevel? AccessLevelNavigation { get; set; }
}
