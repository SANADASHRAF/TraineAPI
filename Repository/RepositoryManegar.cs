using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public sealed class RepositoryManegar : IRepositoryManegar
    {

        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IAdminRepository> _AdminRepository;
        private readonly Lazy<ICommentRepository> _CommentRepository;
        private readonly Lazy<IPaymentRepository> _PaymentRepository;
        private readonly Lazy<IPostRepository> _PostRepository;
        private readonly Lazy<IReportRepository> _ReportRepository;
        private readonly Lazy<IStationRepository> _StationRepository;
        private readonly Lazy<ITeketRepository> _TeketRepository;
        private readonly Lazy<ITrainRepository> _TrainRepository;
        private readonly Lazy<IUserRepository> _UserRepository;
        private readonly Lazy<ILocationRepository> _LocationRepository;
        private readonly Lazy<InewsRepository> _newsRepository;
        public  RepositoryManegar(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _AdminRepository = new Lazy<IAdminRepository>(() => new AdminRepository(repositoryContext));
            _CommentRepository = new Lazy<ICommentRepository>(() => new CommentRepository(repositoryContext));
            _PaymentRepository = new Lazy<IPaymentRepository>(() => new PaymentRepository(repositoryContext));
            _PostRepository = new Lazy<IPostRepository>(() => new PostRepository(repositoryContext));
            _ReportRepository = new Lazy<IReportRepository>(() => new ReportRepository(repositoryContext));
            _StationRepository = new Lazy<IStationRepository>(() => new StationRepository(repositoryContext));
            _TeketRepository = new Lazy<ITeketRepository>(() => new TeketRepository(repositoryContext));
            _TrainRepository = new Lazy<ITrainRepository>(() => new TrainRepository(repositoryContext));
            _UserRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _LocationRepository = new Lazy<ILocationRepository>(() => new LocationRepository(repositoryContext));
            _newsRepository=new Lazy<InewsRepository>(() => new newsRepository(repositoryContext));
        }


        public IAdminRepository Admin => _AdminRepository.Value;
        public ICommentRepository Comment => _CommentRepository.Value;

        public IPaymentRepository Payment => _PaymentRepository.Value;

        public IPostRepository Post => _PostRepository.Value;

        public IReportRepository Report => _ReportRepository.Value;

        public IStationRepository Station => _StationRepository.Value;

        public ITeketRepository Teket => _TeketRepository.Value;

        public ITrainRepository Train => _TrainRepository.Value;

        public IUserRepository User => _UserRepository.Value;
         
        public ILocationRepository Location => _LocationRepository.Value;
        public InewsRepository news => _newsRepository.Value;
        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
