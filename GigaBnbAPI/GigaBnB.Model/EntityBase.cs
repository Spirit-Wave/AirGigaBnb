using System.ComponentModel.DataAnnotations;

namespace GigaBnB.Model;

public class EntityBase
{
    [Key] 
    public Guid Id { get; set; }
}