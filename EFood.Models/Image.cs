using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFood.models;
public partial class Image
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Imagen es Requerido")]
    [MaxLength(150, ErrorMessage = "Path debe ser Maximo 150 Caracteres")]
    public string Path { get; set; }


}
