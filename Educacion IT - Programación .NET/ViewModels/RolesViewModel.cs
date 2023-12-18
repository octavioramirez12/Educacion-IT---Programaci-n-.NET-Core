using Data.Entities;

namespace Educacion_IT___Programación_.NET.ViewModels
{
    public class RolesViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public static implicit operator RolesViewModel(Roles rol)
        {
            var rolesViewModel = new RolesViewModel();
            rolesViewModel.Id = rol.Id;
            rolesViewModel.Nombre = rol.Nombre;
            rolesViewModel.Activo = rol.Activo;

            return rolesViewModel;

        }
    }
}
