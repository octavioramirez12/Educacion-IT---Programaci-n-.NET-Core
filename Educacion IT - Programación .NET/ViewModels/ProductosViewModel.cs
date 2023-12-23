using Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Educacion_IT___Programación_.NET.ViewModels
{
    public class ProductosViewModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }
        public bool Activo { get; set; }
        public IFormFile Imagen_Archivo { get; set; }

        public static implicit operator ProductosViewModel(Productos producto)
        {
            var productosViewModel = new ProductosViewModel();
            productosViewModel.Id = producto.Id;
            productosViewModel.Descripcion = producto.Descripcion;
            productosViewModel.Precio = producto.Precio;
            productosViewModel.Stock = producto.Stock;
            productosViewModel.Imagen = producto.Imagen;
            productosViewModel.Activo = producto.Activo;

            return productosViewModel;

        }
    }
}
