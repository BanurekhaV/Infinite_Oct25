using System;
using System.Collections.Generic;

namespace Core_EF_DB.Models;

public partial class Test
{
    public string? Testid { get; set; }

    public string? Testname { get; set; }

    public DateOnly? Testdate { get; set; }
}
