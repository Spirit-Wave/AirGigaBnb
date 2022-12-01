using System.ComponentModel.DataAnnotations;

namespace GigaBnB.Model;

public class EntityBase
{
    [Key] 
    public Guid Id { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateUpdated { get; set; }
}