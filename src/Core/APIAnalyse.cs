namespace Microsoft365_E5_Renew_X;

public sealed class APIAnalyse : List<APIAnalyse.APIAnalyseBase>
{
    public sealed class APIAnalyseBase
    {
        public string API { get; set; } = "";

        public int Success { get; set; }

        public int Fail { get; set; }

        public int Request { get; set; }
    }
}
