using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManegar
    {
        IAdminRepository Admin { get; }
        ICommentRepository Comment { get; }
        IPaymentRepository Payment { get; }
        IPostRepository Post { get; }
        IReportRepository Report { get; }
        IStationRepository Station { get; }
        ITeketRepository Teket { get; }
        ITrainRepository Train { get; }
        IUserRepository User { get; }
        ILocationRepository Location { get; }
        InewsRepository news { get; }
        void Save();

    }
}
