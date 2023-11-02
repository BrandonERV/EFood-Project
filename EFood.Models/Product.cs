using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFood.models;
public partial class Product
{
    [Key]
    public int Id { get; set; }

    [MaxLength(50)]
    [Required]
    public string Name { get; set; }

    [MaxLength(150)]
    [Required]
    public string Description { get; set; }

    [Required]
    public string Image { get; set; }

    [Required]
    public int FoodLineId { get; set; }

    [ForeignKey("FoodLineId")]
    public FoodLine FoodLine { get; set; }

  
}
