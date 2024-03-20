using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Webdoctruyen.Models;

public partial class Voice
{
    [Key]
    public int Id { get; set; }

    public string Link { get; set; }

    public int Nhanvat { get; set; }

    public int IdTruyen { get; set; }
}
