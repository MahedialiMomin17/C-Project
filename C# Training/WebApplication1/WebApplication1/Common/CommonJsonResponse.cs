namespace WebApplication1.Common
{
    public class CommonJsonResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public dynamic data { get; set; }

    }

    public class LoginResponse : CommonJsonResponse
    {
        public string access_token { get; set; }

        public string token_type { get; set; }

    }
}
