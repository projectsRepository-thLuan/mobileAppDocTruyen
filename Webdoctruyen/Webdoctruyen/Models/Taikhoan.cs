using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Webdoctruyen.Models;

public partial class Taikhoan
{
    [Key]
    public int Id { get; set; }

    public string Tentaikhoan { get; set; }

    public string Matkhau { get; set; }

    public string Email { get; set; }

    public int Phanquyen { get; set; }
}
