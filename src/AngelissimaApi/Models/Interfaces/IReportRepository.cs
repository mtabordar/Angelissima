namespace AngelissimaApi.Models.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IReportRepository
    {
        IEnumerable<Report> getDayReport(DateTime from, DateTime to);
    }
}
