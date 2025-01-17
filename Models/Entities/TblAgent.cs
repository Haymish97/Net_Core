﻿using System;
using System.Collections.Generic;

namespace Net_Core.Models.Entities;

public partial class TblAgent
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Area { get; set; }

    public string? Address { get; set; }

    public string? District { get; set; }

    public string? City { get; set; }

    public int? Status { get; set; }
}
