namespace AdTools.Library.Commands.InPlaceGitBackup
{
    public interface IInPlaceGitBackupProvider
    {
        GitBackupStatus InPlaceGitBackup(string repositoryFolder);
    }
}
