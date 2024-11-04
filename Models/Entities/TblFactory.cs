using System;
using System.Collections.Generic;

namespace Net_Core.Models.Entities;

public partial class TblFactory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? ImageName { get; set; }

    public string? Intro { get; set; }

    public string? Info { get; set; }

    public int? Status { get; set; }
}
