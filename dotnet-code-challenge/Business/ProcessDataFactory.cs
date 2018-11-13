namespace dotnet_code_challenge.Business
{
    using System.IO;

    public static class ProcessDataFactory
    {
        public static IProcessData GetProcessDataType(string fileExtension)
        {
            IProcessData processData = null;
            switch (fileExtension)
            {
                case ".xml":
                    processData = new ProcessXMLData();
                    break;
                case ".json":
                    processData = new ProcessJSONData();
                    break;
            }
            return processData;
        }
    }
}
