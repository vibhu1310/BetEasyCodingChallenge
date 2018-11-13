using dotnet_code_challenge.Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Model.BetEasyModel> betEasyModels = new List<Model.BetEasyModel>();
            DirectoryInfo feedData = new DirectoryInfo("FeedData");
            FileInfo[] files = feedData.GetFiles();
            foreach(var file in files)
            {
                IProcessData processData = ProcessDataFactory.GetProcessDataType(file.Extension.ToLower());
                if(processData != null)
                {
                    var model = processData.Transform(file);
                    if(model != null)
                    {
                        betEasyModels.AddRange(model);
                    }
                }
            }

            betEasyModels = betEasyModels.OrderBy(t => t.Price).ToList();

            foreach(var model in betEasyModels)
            {
                Console.WriteLine(string.Format("Horse Name : {0}   Price : {1}", model.HorseName, model.Price));
            }

            Console.ReadLine();
        }
    }
}
