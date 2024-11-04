using System;
using System.Collections.Generic;

namespace Net_Core.Models.Entities;

public partial class TblContact
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int? Status { get; set; }
}
