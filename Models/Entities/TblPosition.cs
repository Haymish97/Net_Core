using System;
using System.Collections.Generic;

namespace Net_Core.Models.Entities;

public partial class TblPosition
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? Status { get; set; }
}
