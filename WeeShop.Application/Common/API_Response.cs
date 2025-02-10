using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeeShop.Application.Common
{
    public class API_Response
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<API_Error> Errors { get; set; } = new();
        public List<API_Warning> Warnings { get; set; } = new();

        public void AddError(string errormessage)
        {
            API_Error error = new API_Error (description: errormessage);
            Errors.Add(error);
        }

        public void AddWarning(string warningmessage)
        {
            API_Warning warning = new API_Warning (description: warningmessage);
            Warnings.Add(warning);
        }
    }
}