﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFood.models
{
    public class User : IdentityUser
    {

        [Required(ErrorMessage = "Nombre es Requerido")]
        [MaxLength(50, ErrorMessage = "Nombre debe ser Maximo 50 Caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Contraseña es Requerida")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email es Requerido")]
        [MaxLength(80, ErrorMessage = "Email debe ser Maximo 80 Caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pregunta de seguridad es Requerida")]
        [MaxLength(80, ErrorMessage = "Pregunta de seguridad debe ser Maximo 80 Caracteres")]
        public string SecurityQuestion { get; set; }

        [Required(ErrorMessage = "Respuesta de seguridad es Requerida")]
        [MaxLength(80, ErrorMessage = "Respuesta de seguridad debe ser Maximo 80 Caracteres")]
        public string SecurityAnswer { get; set; }

        [NotMapped]
        public String Role { get; set; }

    }
}

