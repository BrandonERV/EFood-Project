using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFood.models;
public partial class Status
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Type { get; set; }

}
