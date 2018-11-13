using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_code_challenge.Model
{
    public class JSONModel
    {
        public RawData RawData { get; set; }
    }

    public class RawData
    {
        public List<Market> Markets { get; set; }
    }

    public class Market
    {
        public string Id { get; set; }

        public List<Selection> Selections { get; set; }
    }

    public class Selection
    {
        public string Id { get; set; }

        public double Price { get; set; }

        public SelectionTag Tags { get; set; }
    }

    public class SelectionTag
    {
        public string participant { get; set; }

        public string name { get; set; }
        
    }
}
