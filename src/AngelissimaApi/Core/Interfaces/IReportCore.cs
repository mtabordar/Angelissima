namespace AngelissimaApi.Core.Interfaces
{
    using AngelissimaApi.ViewModels;

    public interface IReportCore
    {
        ReportViewModel Find(ReportFilterViewModel filter);
    }
}
