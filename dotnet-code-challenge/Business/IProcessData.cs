namespace dotnet_code_challenge.Business
{
    using dotnet_code_challenge.Model;
    using System.Collections.Generic;
    using System.IO;

    public interface IProcessData
    {
        IList<BetEasyModel> Transform(FileInfo file);
    }
}
