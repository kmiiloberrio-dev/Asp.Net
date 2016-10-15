using System.Collections.Generic;
using System.Threading.Tasks;
using ent = Data.Entidad;
using Data.Modelo;
using Data.Repositorio;
using System;
using System.Transactions;

namespace Dominio
{
    public class TransaccionCategoriaProducto
    {
        public async Task RegistrarTransaccionCategoriaProducto(ent.Categoria cate, ent.Producto prod)
        {
            try
            {
                using (var trn = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    int id = await new Categoria().RegistrarID(cate);
                    prod.ID_Categoria = id;
                    await new Producto().Registrar(prod);

                    trn.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo transacción categoria producto", ex.InnerException);
            }
        }

        public async Task RegistrarListaTransaccionCategoriaProducto(ent.Categoria cate, List<ent.Producto> prod)
        {
            try
            {
                using (var trn = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    int id = await new Categoria().RegistrarID(cate);

                    foreach (var item in prod)
                    {
                        item.ID_Categoria = id;
                        await new Producto().Registrar(item);
                    }

                    trn.Complete();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fallo transacción categoria producto listado", ex.InnerException);
            }
        }
    }


}
