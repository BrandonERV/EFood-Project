using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFood.models;
public partial class Error
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    [MaxLength(250)]
    public string Message { get; set; }
}
