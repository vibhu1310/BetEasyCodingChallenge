namespace dotnet_code_challenge.Business
{
    using dotnet_code_challenge.Model;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;

    public class ProcessJSONData : IProcessData
    {
        public IList<BetEasyModel> Transform(FileInfo file)
        {
            IList<BetEasyModel> modelList = new List<BetEasyModel>();

            using (StreamReader r = new StreamReader(file.FullName))
            {
                var json = r.ReadToEnd();
                JSONModel jsonModel = JsonConvert.DeserializeObject<JSONModel>(json);
                if(jsonModel != null && jsonModel.RawData != null && jsonModel.RawData.Markets != null)
                {
                    List<Market> markets = jsonModel.RawData.Markets;
                    foreach(var market in markets)
                    {
                        var selections = market.Selections.Select(t => new { t.Price, t.Tags.name ,t.Id }).ToList();
                        foreach(var selection in selections)
                        {
                            BetEasyModel model = new BetEasyModel();
                            model.HorseName = selection.name;
                            model.Price = selection.Price;
                            model.Id = selection.Id;
                            modelList.Add(model);
                        }
                    }
                }
            }

            return modelList;
        }
    }
}
