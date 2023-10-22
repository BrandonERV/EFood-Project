using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFood.models;

public partial class Card
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage ="Nombre Requerido")]
    [MaxLength(50, ErrorMessage = "Nombre debe ser Maximo 50 Caracteres")]
    public string Name { get; set; }
}
