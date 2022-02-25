﻿using System.Collections;

namespace Ecommerce.Common.Dtos
{
    public class ResponseException
    {
        public string ErrorLevel { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorSource { get; set; }
        public string ErrorStackTrace { get; set; }
        public string ErrorTargetSite { get; set; }
        public IDictionary ErrorData { get; set; }
    }
}