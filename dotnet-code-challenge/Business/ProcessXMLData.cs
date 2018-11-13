namespace dotnet_code_challenge.Business
{
    using dotnet_code_challenge.Model;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;

    public class ProcessXMLData : IProcessData
    {
        public IList<BetEasyModel> Transform(FileInfo file)
        {
            IList<BetEasyModel> betEasyModelList = new List<BetEasyModel>();

            using (StreamReader r = new StreamReader(file.FullName))
            {
                var xmlData = r.ReadToEnd();

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlData);

                XmlNode root = doc.DocumentElement;
                //Display the contents of the child nodes.
                
                XmlNodeList horseNodeList  =  root.SelectNodes("races/race/horses/horse");

                XmlNodeList priceNodeList = root.SelectNodes("races/race/prices/price/horses/horse");

                foreach(XmlNode horseNode in horseNodeList)
                {
                    BetEasyModel model = new BetEasyModel();
                    model.Id = horseNode.SelectSingleNode("number").InnerText;
                    model.HorseName = horseNode.Attributes["name"].Value;
                    foreach(XmlNode priceNode in priceNodeList)
                    {
                        if(priceNode.Attributes["number"].Value == model.Id)
                        {
                            string price = priceNode.Attributes["Price"].Value;
                            model.Price = double.Parse(price);
                        }
                    }
                    betEasyModelList.Add(model);
                }

            }
            return betEasyModelList;
        }
    }
}
