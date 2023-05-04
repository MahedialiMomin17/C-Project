namespace MVCPrcatice.Common
{
    public static class CommonUtility
    {
        public static void CreateCookie(IHttpContextAccessor _contextAccessor, string Name, string value, CookieOptions options)
        {
            _contextAccessor.HttpContext.Response.Cookies.Append(Name, value, options);
        }
        public static void DeleteCookie(IHttpContextAccessor _contextAccessor, string Name)
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddSeconds(-2);
            _contextAccessor.HttpContext.Response.Cookies.Append(Name, "", options);
        }
        public static string ReadCookie(IHttpContextAccessor _contextAccessor, string Name)
        {
            string objCookie = _contextAccessor.HttpContext.Request.Cookies["Mahediali"];

            return objCookie;
        }
    }
}
