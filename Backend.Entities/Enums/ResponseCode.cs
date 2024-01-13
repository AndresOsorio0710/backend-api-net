using System.ComponentModel;

namespace Backend.Entities.Enums
{
    public enum ResponseCode
    {
        // 1xx Informational
        [Description("Continue")] Continue = 100,
        [Description("Switching Protocols")] SwitchingProtocols = 101,
        [Description("Processing")] Processing = 102,
        [Description("Early Hints")] EarlyHints = 103,

        // 2xx Success
        [Description("OK")] Ok = 200,
        [Description("Created")] Created = 201,
        [Description("Accepted")] Accepted = 202,
        [Description("Non-Authoritative Information")] NonAuthoritativeInformation = 203,
        [Description("No Content")] NoContent = 204,
        [Description("Reset Content")] ResetContent = 205,
        [Description("Partial Content")] PartialContent = 206,
        [Description("Multi-Status")] MultiStatus = 207,
        [Description("Already Reported")] AlreadyReported = 208,
        [Description("IM Used")] IMUsed = 226,

        // 3xx Redirection
        [Description("Multiple Choices")] MultipleChoices = 300,
        [Description("Moved Permanently")] MovedPermanently = 301,
        [Description("Found")] Found = 302,
        [Description("See Other")] SeeOther = 303,
        [Description("Not Modified")] NotModified = 304,
        [Description("Use Proxy")] UseProxy = 305,
        [Description("Switch Proxy")] SwitchProxy = 306,
        [Description("Temporary Redirect")] TemporaryRedirect = 307,
        [Description("Permanent Redirect")] PermanentRedirect = 308,

        // 4xx Client Errors
        [Description("Bad Request")] BadRequest = 400,
        [Description("Unauthorized")] Unauthorized = 401,
        [Description("Payment Required")] PaymentRequired = 402,
        [Description("Forbidden")] Forbidden = 403,
        [Description("Not Found")] NotFound = 404,
        [Description("Method Not Allowed")] MethodNotAllowed = 405,
        [Description("Not Acceptable")] NotAcceptable = 406,
        [Description("Proxy Authentication Required")] ProxyAuthenticationRequired = 407,
        [Description("Request Timeout")] RequestTimeout = 408,
        [Description("Conflict")] Conflict = 409,
        [Description("Gone")] Gone = 410,
        [Description("Length Required")] LengthRequired = 411,
        [Description("Precondition Failed")] PreconditionFailed = 412,
        [Description("Payload Too Large")] PayloadTooLarge = 413,
        [Description("URI Too Long")] UriTooLong = 414,
        [Description("Unsupported Media Type")] UnsupportedMediaType = 415,
        [Description("Range Not Satisfiable")] RangeNotSatisfiable = 416,
        [Description("Expectation Failed")] ExpectationFailed = 417,
        [Description("I'm a teapot")] ImATeapot = 418,
        [Description("Misdirected Request")] MisdirectedRequest = 421,
        [Description("Unprocessable Entity")] UnprocessableEntity = 422,
        [Description("Locked")] Locked = 423,
        [Description("Failed Dependency")] FailedDependency = 424,
        [Description("Upgrade Required")] UpgradeRequired = 426,
        [Description("Precondition Required")] PreconditionRequired = 428,
        [Description("Too Many Requests")] TooManyRequests = 429,
        [Description("Request Header Fields Too Large")] RequestHeaderFieldsTooLarge = 431,
        [Description("Unavailable For Legal Reasons")] UnavailableForLegalReasons = 451,

        // 5xx Server Errors
        [Description("Internal Server Error")] InternalServerError = 500,
        [Description("Not Implemented")] NotImplemented = 501,
        [Description("Bad Gateway")] BadGateway = 502,
        [Description("Service Unavailable")] ServiceUnavailable = 503,
        [Description("Gateway Timeout")] GatewayTimeout = 504,
        [Description("HTTP Version Not Supported")] HttpVersionNotSupported = 505,
        [Description("Variant Also Negotiates")] VariantAlsoNegotiates = 506,
        [Description("Insufficient Storage")] InsufficientStorage = 507,
        [Description("Loop Detected")] LoopDetected = 508,
        [Description("Not Extended")] NotExtended = 510,
        [Description("Network Authentication Required")] NetworkAuthenticationRequired = 511
    }
}
