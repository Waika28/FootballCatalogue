using System.ComponentModel.DataAnnotations;

namespace FootballCatalogue.Models;

public class Player
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    [EnumDataType(typeof(Enums.Sex))]
    public Enums.Sex Sex { get; set; }

    [DataType(DataType.Date)]
    public DateTime Birthday { get; set; }

    public string? Team { get; set; }

    public string? Country { get; set; }

}
