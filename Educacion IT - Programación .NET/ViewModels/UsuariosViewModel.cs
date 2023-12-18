using Data.Entities;

namespace Educacion_IT___Programación_.NET.ViewModels
{
    public class UsuariosViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Clave { get; set; }
        public string Mail { get; set; }
        public int Id_Rol { get; set; }
        public bool Activo { get; set; }
        public int? Codigo { get; set; }

        public static implicit operator UsuariosViewModel(Usuarios usuario)
        {
            var usuariosViewModel = new UsuariosViewModel();
            usuariosViewModel.Id = usuario.Id;
            usuariosViewModel.Nombre = usuario.Nombre;
            usuariosViewModel.Apellido = usuario.Apellido;
            usuariosViewModel.Fecha_Nacimiento = usuario.Fecha_Nacimiento;
            usuariosViewModel.Clave = usuario.Clave;
            usuariosViewModel.Mail = usuario.Mail;
            usuariosViewModel.Id_Rol = usuario.Id_Rol;
            usuariosViewModel.Activo = usuario.Activo;
            usuariosViewModel.Codigo = usuario.Codigo;

            return usuariosViewModel;

        }
    }
}
