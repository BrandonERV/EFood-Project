using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFood.models;
public partial class PaymentProcessor
    
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50, ErrorMessage = "Nombre debe ser Maximo 50 Caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Es requerido")]
    public string Type { get; set; }

    [Required(ErrorMessage = "Es requerido")]
    public string Active { get; set; }

    
}
