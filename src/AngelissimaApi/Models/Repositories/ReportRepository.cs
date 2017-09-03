namespace AngelissimaApi.Models.Repositories
{
    using System;
    using System.Collections.Generic;
    using Models.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class ReportRepository : IReportRepository
    {
        private AngelContext _context;

        public ReportRepository(AngelContext context)
        {
            this._context = context;
        }

        public IEnumerable<Report> getDayReport(DateTime from, DateTime to)
        {            
            return  _context.Set<Report>().FromSql($" EXECUTE dbo.sp_GetDailyReport {from}, {to}").AsNoTracking().ToList();
        }
    }
}
