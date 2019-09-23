using System;
using System.Collections.Generic;
using System.Text;

namespace Core.EncryptionTools
{
    public static class ExceptionHelpers
    {
        public static string GetErrorMessage(this Exception ex)
        {
            if (ex.InnerException == null)
                return ex.Message;

            return GetErrorMessage(ex.InnerException);
        }
    }
}
