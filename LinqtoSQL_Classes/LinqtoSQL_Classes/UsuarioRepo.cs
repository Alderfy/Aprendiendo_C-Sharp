using LinqtoSQL_Classes.Model.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqtoSQL_Classes
{
    public class UsuarioRepo : iUsuarioRepo
    {
        public Usuario Create(Usuario usuario)
        {
            using (AppLinqDataContext dbcontext = new AppLinqDataContext())
            {
                dbcontext.Usuarios.InsertOnSubmit(usuario);
                dbcontext.SubmitChanges();

                return usuario;
            }
        }

        public Usuario findById(int Id)
        {
            using (AppLinqDataContext dbcontext = new AppLinqDataContext())
            {
                return dbcontext.Usuarios.SingleOrDefault(x => x.ID == Id);
            }
        }

        public List<Usuario> getAll()
        {
            using (AppLinqDataContext dbcontext = new AppLinqDataContext())
            {
                return dbcontext.Usuarios.ToList();
            }
        }

        public OperationResult hDelete(int Id)
        {
            using (AppLinqDataContext dbcontext = new AppLinqDataContext())
            {
                Usuario hardDelete = findById(Id);

                if(hardDelete == null)
                    return new OperationResult() { Result = false, Message = $"No se encontraron registros con el ID {Id}." };

                dbcontext.Usuarios.Attach(hardDelete);
                dbcontext.Usuarios.DeleteOnSubmit(hardDelete);
                dbcontext.SubmitChanges();

                return new OperationResult() { Result = true, Message = "" };
            }
        }

        public OperationResult Update(Usuario usuario, int Id)
        {
            using (AppLinqDataContext dbcontext = new AppLinqDataContext())
            {
                Usuario update = findById(Id);

                if(update == null)
                    return new OperationResult() { Result = false, Message = $"No se encontraron registros con el ID {Id}." };

                dbcontext.Usuarios.Attach(update);
                update.Nombre = usuario.Nombre;
                update.Apellido = usuario.Apellido;

                dbcontext.SubmitChanges();

                return new OperationResult() { Result = true, Message = "" };
            }
        }
    }
}
