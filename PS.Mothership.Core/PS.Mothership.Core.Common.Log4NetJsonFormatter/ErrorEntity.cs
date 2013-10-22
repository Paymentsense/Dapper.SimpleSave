namespace PS.Mothership.Core.Common.Log4NetJsonFormatter
{
    internal class ErrorEntity
    {
        public string Date { get; set; }
        public string ErrorMessage { get; set; }
        public string ApplicationName { get; set; }
        public string Thread { get; set; }
        public string ErrorLevel { get; set; }
        public string AssemblyName { get; set; }
    }
}
