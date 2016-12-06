namespace AdTools.Library.Commands.InPlaceGitBackup
{
    public class GitBackupStatus
    {
        public GitBackupStatus(bool createRepository, int numberOfFilesAdded, int numberOfFilesChanged, int numberOfFilesRemoved)
        {
            NumberOfFilesAdded = numberOfFilesAdded;
            NumberOfFilesChanged = numberOfFilesChanged;
            NumberOfFilesRemoved = numberOfFilesRemoved;
            CreateRepository = createRepository;
        }
        public bool CreateRepository { get; }
        public int NumberOfFilesAdded { get; }
        public int NumberOfFilesChanged { get; }
        public int NumberOfFilesRemoved { get; }
    }
}