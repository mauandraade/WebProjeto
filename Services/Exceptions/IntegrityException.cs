using System;
namespace SalesWebMvcc.Services.Exceptions
{
    public class IntegrityException :ApplicationException
    {
        public IntegrityException(string message) : base(message)
        {

        }
    }
}
