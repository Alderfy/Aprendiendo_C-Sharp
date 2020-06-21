using System;

namespace Nomina_pParcial
{
    public interface iempleadosRepositorio
    {
        OperationResult createEmpleado(Empleado empleado);
        OperationResult findByCedula(string cedula);
        OperationResult updateEmpleado(Empleado empleado, string cedula);
        OperationResult softDelete(string cedula);
        OperationResult generarNomina();
    }
}