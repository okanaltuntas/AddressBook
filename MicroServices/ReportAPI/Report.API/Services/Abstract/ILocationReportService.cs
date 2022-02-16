using Report.API.Model;
using System.Threading.Tasks;

namespace Report.API.Services.Abstract
{
    public interface ILocationReportService : IBaseService<NumbersOfAtLocation>
    {
        Task<bool> GenerateLocationReport();
    }
}


