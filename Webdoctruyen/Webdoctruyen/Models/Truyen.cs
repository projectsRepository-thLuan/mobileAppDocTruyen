using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Webdoctruyen.Models;

public partial class Truyen
{ 
    [Key]
    public int Id { get; set; }

    public string Tentruyen { get; set; }

    public string Noidung { get; set; }
    public string Anh { get; set; }
    public string? Voice { get; set; }

    public int IdTk { get; set; }

    
}
