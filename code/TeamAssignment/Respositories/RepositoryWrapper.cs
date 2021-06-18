using TeamAssignment.Data;
using TeamAssignment.Interfaces;

namespace TeamAssignment.Respositories
{
    public class RepositoryWrapper:IRepositoryWrapper
    {
        ApplicationDbContext _repoContext;
        public RepositoryWrapper(ApplicationDbContext repoContext)
        {
            _repoContext = repoContext;
        }
        ITeamRepository _teams;
        public ITeamRepository Teams{
            get{
                if(_teams==null){
                    _teams = new TeamRepository(_repoContext);
                }
                return _teams;
            }

        }

        void IRepositoryWrapper.Save(){
            _repoContext.SaveChanges();
        }
    }
}