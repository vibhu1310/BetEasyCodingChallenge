using dotnet_code_challenge.Business;
using System;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class UnitTest1
    {
        [Fact]
        public void ProcessDataFactory_XML_Pass()
        {
            IProcessData processData = ProcessDataFactory.GetProcessDataType(".xml");
            Assert.Equal(typeof(ProcessXMLData), processData.GetType());
        }

        [Fact]
        public void ProcessDataFactory_JSON_Pass()
        {
            IProcessData processData = ProcessDataFactory.GetProcessDataType(".json");
            Assert.Equal(typeof(ProcessJSONData), processData.GetType());
        }
        
        [Fact]
        public void ProcessDataFactory_OtherType_Pass()
        {
            IProcessData processData = ProcessDataFactory.GetProcessDataType(".jpeg");
            Assert.Null(processData);
        }

    }
}
