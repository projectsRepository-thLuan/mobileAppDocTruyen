using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Webdoctruyen.Models;

public partial class Danhgium
{
    [Key]
    public int Id { get; set; }

    public string Noidung { get; set; }

    public int IdTaikhoan { get; set; }

    public int IdTruyen { get; set; }
}
