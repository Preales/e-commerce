namespace Ecommerce.Common.Enums
{
    public class GenericEnumerator
    {
        public enum DateFormat
        {
            Dmy,
            Dmyh,
            Mdy,
            Mdyh,
            Ymd,
            Ymdh,
            Hhmmss
        }

        public enum Headers
        {
            [EnumeratorExtension("X-API-CODE")]
            XApiKey
        }

        public enum LogType
        {
            [EnumeratorExtension("INFO")]
            Info,
            [EnumeratorExtension("ERROR")]
            Error
        }

        public enum TypeRequest
        {
            Request,
            Response,
            Exception
        }

        public enum Separator
        {
            [EnumeratorExtension("/")]
            Slash,
            [EnumeratorExtension("-")]
            Hyphen,
            [EnumeratorExtension(".")]
            Point,
            [EnumeratorExtension("")]
            Empty,
            [EnumeratorExtension(";")]
            Semicolon,
        }

        public enum Status
        {
            [EnumeratorExtension("OK")]
            Ok = 1,
            [EnumeratorExtension("ERROR")]
            Error = 0
        }

        public enum Log
        {
            Error,
            Info,
            Warn,
            Debug
        }
        public enum OrderByMethod
        {
            OrderBy,
            OrderByDescending
        }
    }
}