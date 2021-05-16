namespace ASP.NET_CORE_3_Chapter_15.Services
{
    public static class TypeBroker
    {
        private static IResponseFormatter formatter = new HtmlResponseFormatter();
        public static IResponseFormatter Formatter => formatter;
    }
}
