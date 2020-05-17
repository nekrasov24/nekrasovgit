using System.Collections.Generic;
using BillingSystem.Enums;
using BillingSystem.Models.Classes;

namespace BillingSystem.Models.Interfaces
{
    public interface IReportRender
    {
        void Render(Report report);
        IEnumerable<ReportRecord> SortCalls(Report report, TypeSort sortType);
    }
}
