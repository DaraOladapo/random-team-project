using TeamAssignment.Data;
using TeamAssignment.Interfaces;
using TeamAssignment.Models;
using TeamAssignment.Respositories;

namespace TeamAssignment
{
    public class TeamRepository: Repository<Team>, ITeamRepository
    {
        public TeamRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}