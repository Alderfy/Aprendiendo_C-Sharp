using System;

namespace Nomina_sParcial
{
    public class OperationResult
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public OperationResult(bool result, string message)
        {
            this.Result = result;
            this.Message = message;
        }
        public OperationResult(bool result, object data)
        {
            this.Result = result;
            this.Data = data;
        }
        public OperationResult()
        {
        }
    }
}
