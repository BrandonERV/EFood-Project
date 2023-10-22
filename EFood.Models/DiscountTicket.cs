using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFood.models;

public partial class DiscountTicket
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Nombre es Requerido")]
    [MaxLength(50, ErrorMessage = "Nombre debe ser Maximo 50 Caracteres")]
    public string Name { get; set; }

    [Required]
    public int Availabletickets { get; set; }

    [Required]
    public int Discount { get; set; }

    [Required]
    public string UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
}
