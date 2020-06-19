using System;

namespace Practica_Ado.net
{
    public interface iSuplidoresRepositorio
    {
        OperationResult Create(Suplidor suplidor);
        OperationResult GetAll();
        OperationResult FindByRNC(string rnc);
        OperationResult Update(Suplidor suplidor, string rnc);
        OperationResult SoftDelete(string rnc);
    }
}
