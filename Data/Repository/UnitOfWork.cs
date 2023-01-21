using RadicalTherapy.Data.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadicalTherapy.Data.Repository
{
    public class UnitOfWork : IDisposable
    {
        private MyContext context = new MyContext();
        private GenericRepository<Reserve> reserveRepository;
        private GenericRepository<Comment> commentRepository;
        private GenericRepository<Client> clientRepository;
        private GenericRepository<RadicalTherapy.Data.model.Data> dataRepository;
        private GenericRepository<CustomerVideo> customerVideosRepository;
        private GenericRepository<Statistics> statisticsRepository;
        private GenericRepository<User> userRepository;
        private GenericRepository<RadicalReserve> radicalReserveRepository;
        private GenericRepository<Subject> subjectRepository;
        private GenericRepository<Content> contentRepository;
         private GenericRepository<Question> questionRepository;


        private bool disposed = false;
         public GenericRepository<Question> QuestionRepository
        {
            get
            {
                if (this.questionRepository == null)
                {
                    this.questionRepository = new GenericRepository<Question>(context);
                }
                return questionRepository;
            }
        }
        public GenericRepository<Content> ContentRepository
        {
            get
            {
                if (this.contentRepository == null)
                {
                    this.contentRepository = new GenericRepository<Content>(context);
                }
                return contentRepository;
            }
        }
        public GenericRepository<Subject> SubjectRepository
        {
            get
            {
                if (this.subjectRepository == null)
                {
                    this.subjectRepository = new GenericRepository<Subject>(context);
                }
                return subjectRepository;
            }
        }

        public GenericRepository<Statistics> StatisticsRepository
        {
            get
            {
                if (this.statisticsRepository == null)
                {
                    this.statisticsRepository = new GenericRepository<Statistics>(context);
                }
                return statisticsRepository;
            }
        }
        public GenericRepository<RadicalTherapy.Data.model.CustomerVideo> CustomerVideosRepository
        {
            get
            {
                if (this.customerVideosRepository == null)
                {
                    this.customerVideosRepository = new GenericRepository<RadicalTherapy.Data.model.CustomerVideo>(context);
                }
                return customerVideosRepository;
            }
        }
        public GenericRepository<RadicalTherapy.Data.model.Data> DataRepository
        {
            get
            {
                if (this.dataRepository == null)
                {
                    this.dataRepository = new GenericRepository<RadicalTherapy.Data.model.Data>(context);
                }
                return dataRepository;
            }
        }
        public GenericRepository<Reserve> ReserveRepository
        {
            get
            {
                if (this.reserveRepository == null)
                {
                    this.reserveRepository = new GenericRepository<Reserve>(context);
                }
                return reserveRepository;
            }
        }
        public GenericRepository<Comment> CommentRepository
        {
            get
            {
                if (this.commentRepository == null)
                {
                    this.commentRepository = new GenericRepository<Comment>(context);
                }
                return commentRepository;
            }
        }
        public GenericRepository<Client> ClientRepository
        {
            get
            {
                if (this.clientRepository == null)
                {
                    this.clientRepository = new GenericRepository<Client>(context);
                }
                return clientRepository;
            }
        }
        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }
        public GenericRepository<RadicalReserve> RadicalReserveRepository
        {
            get
            {
                if (this.radicalReserveRepository == null)
                {
                    this.radicalReserveRepository = new GenericRepository<RadicalReserve>(context);
                }
                return radicalReserveRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
