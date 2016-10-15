using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ent = Aplicacion.Entidad;
using data = Data.Entidad;
using map = Mapa;
using dom = Dominio;
using AutoMapper;

namespace Aplicacion.Aplicacion
{
    public class TransaccionCategoriaProducto
    {

        public async Task RegistrarTransaccionCategoriaProducto(ent.Categoria cate, ent.Producto prod)
        {
            map.Mapear.CrearMapaCategoria();
            data.Categoria _categoria = Mapper.Map<ent.Categoria, data.Categoria>(cate);
            map.Mapear.CrearMapaProducto();
            data.Producto _producto = Mapper.Map<ent.Producto, data.Producto>(prod);
            await new dom.TransaccionCategoriaProducto().RegistrarTransaccionCategoriaProducto(_categoria, _producto);

        }
    }
}
