﻿using System.ComponentModel.DataAnnotations;

namespace medcenter_backend.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite o e-mail")]
        public string Email { get; set; }
    }
}
