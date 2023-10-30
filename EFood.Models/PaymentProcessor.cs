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
    public bool Status { get; set; }

    [Required(ErrorMessage = "Es requerido")]
    public string Processor { get; set; }

    [Required]
    public bool Verification { get; set; }

    [Required(ErrorMessage = "Es requerido")]
    public string Method { get; set; }

    [NotMapped]
    public IEnumerable<string> ProcessorType { get; set; } = new List<string> { "Tarjeta de Crédito o Débito", "Efectivo", "Cheque Electrónico" };









}
