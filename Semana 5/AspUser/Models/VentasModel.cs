using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace AspUser.Models
{
    public class VentasModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }


        public string UsuariosModelId { get; set; }
        public UsuariosModel UsuariosModel { get; set; }


    }
}
