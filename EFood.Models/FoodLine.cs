using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFood.models;
public partial class FoodLine
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Linea de comida es Requerido")]
    [MaxLength(80, ErrorMessage = "Linea de comida debe ser Maximo 80 Caracteres")]
    public string Name { get; set; }

}
