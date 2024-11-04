using System;
using System.Collections.Generic;

namespace Net_Core.Models.Entities;

public partial class TblBanner
{
    public int Id { get; set; }

    public string? FileName { get; set; }

    public string? LinkTag { get; set; }

    public int? No { get; set; }

    public int? IdType { get; set; }

    public int? Status { get; set; }
}
