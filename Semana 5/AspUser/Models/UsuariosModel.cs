using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;

namespace AspUser.Models
{
    public class UsuariosModel:IdentityUser
    {
        [Required]
        public string Cedula { get; set; }

    }
}
