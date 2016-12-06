using System;
using System.Globalization;
using Common.Logging;
using LibGit2Sharp;
using Newtonsoft.Json;

namespace AdTools.Library.Commands.InPlaceGitBackup
{
    public class InPlaceGitBackupProvider : IInPlaceGitBackupProvider
    {
        private readonly ILog _logger;

        public InPlaceGitBackupProvider(ILog logger)
        {
            _logger = logger;
        }

        public GitBackupStatus InPlaceGitBackup(string repositoryFolder)
        {            
            var isValidGitRepository = LibGit2Sharp.Repository.IsValid(repositoryFolder);
            var createdRepository = false;
            if (!isValidGitRepository)
            {
                _logger.InfoFormat("Initializing git repository in folder '{0}'...", repositoryFolder);
                repositoryFolder = LibGit2Sharp.Repository.Init(repositoryFolder, false);
                createdRepository = true;
            }
            var numberOfFilesAdded = 0;
            var numberOfFilesChanged = 0;
            var numberOfFilesRemoved = 0;
            using (var repository = new LibGit2Sharp.Repository(repositoryFolder))
            {
                var options = new StatusOptions();
                var status = repository.RetrieveStatus(options);
                _logger.Debug("Repository Status: " + JsonConvert.SerializeObject(status));
                if (status.IsDirty)
                {
                    var untractedFiles = status.Untracked;
                    foreach (var untrackedFile in untractedFiles)
                    {                        
                        _logger.Info("Added: " + untrackedFile.FilePath);
                        var stageOptions = new StageOptions();                        
                        repository.Stage(untrackedFile.FilePath, stageOptions);
                        numberOfFilesAdded++;
                    }
                    
                    var modifiedFiles = status.Modified;
                    foreach (var modifiedFile in modifiedFiles)
                    {
                        _logger.Info("Modified: " + modifiedFile.FilePath);
                        var stageOptions = new StageOptions();                        
                        repository.Stage(modifiedFile.FilePath, stageOptions);
                        numberOfFilesChanged++;
                    }                    
                    
                    var removedFiles = status.Missing;
                    foreach (var removedFile in removedFiles)
                    {
                        _logger.Info("Removed: " + removedFile.FilePath);
                        var stageOptions = new StageOptions();                        
                        repository.Stage(removedFile.FilePath, stageOptions);
                        numberOfFilesRemoved++;
                    }
                    var author = new Signature(Environment.UserName, "someemail@tesdt.com", System.DateTimeOffset.Now);
                    var committer = new Signature(Environment.UserName, "someemail@tesdt.com", System.DateTimeOffset.Now);
                    var commitOptions = new CommitOptions();
                    _logger.Info("Commiting...");
                    repository.Commit(DateTime.Now.ToString(CultureInfo.InvariantCulture), author, committer, commitOptions);
                }
            }
            var gitBackupStatus = new GitBackupStatus(createdRepository, numberOfFilesAdded, numberOfFilesChanged, numberOfFilesRemoved);
            return gitBackupStatus;
        }
    }
}