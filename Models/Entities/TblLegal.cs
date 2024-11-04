using System;
using System.Collections.Generic;

namespace Net_Core.Models.Entities;

public partial class TblLegal
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? FileName { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? Status { get; set; }
}
