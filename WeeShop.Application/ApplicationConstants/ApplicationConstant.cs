﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeShop.Application.ApplicationConstants
{
    public class ApplicationConstant
    {
    }
    public class CommonMessage
    {
        public const string CreateOperationSuccess = "Record Created Successfully";
        public const string UpdateOperationSuccess = "Record Updated Successfully";
        public const string DeleteOperationSuccess = "Record Deleted Successfully";

        public const string CreateOperationFailed = "Created Operation Failed";
        public const string UpdateOperationFailed = "Updated Operation Failed";
        public const string DeleteOperationFailed = "Deleted Operation Failed";

        public const string RecordNotFound = "Record Not Found";
        public const string SystemError = "Something went wrong";
    }
}
