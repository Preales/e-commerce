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

        public enum Loglevel
        {
            Trace = 0,
            Debug = 1,
            Information = 2,
            Warning = 3,
            Error = 4,
            Critical = 5,
            None = 6,
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