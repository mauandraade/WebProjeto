using System;

namespace SalesWebMvcc.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public string Message { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId); // verifica se é nulo ou vazio
    }
}