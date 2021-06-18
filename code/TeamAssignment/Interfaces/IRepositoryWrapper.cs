namespace TeamAssignment.Interfaces
{
    public interface IRepositoryWrapper
    {
        ITeamRepository Teams { get; }
        void Save();
    }
}