namespace AdTools.Library.Commands.ReportAllGpos
{
    public interface IReportAllGposCommandProvider
    {
        int ReportAllGpos(string reportFolder, bool removeReadTimestamp, string domainController);
    }
}
