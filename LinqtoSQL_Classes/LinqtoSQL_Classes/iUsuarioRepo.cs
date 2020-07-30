using LinqtoSQL_Classes.Model.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqtoSQL_Classes
{
    interface iUsuarioRepo
    {
        List<Usuario> getAll();
        Usuario Create(Usuario usuario);
        Usuario findById(int Id);
        OperationResult Update(Usuario usuario, int Id);
        OperationResult hDelete(int Id);
    }
}
