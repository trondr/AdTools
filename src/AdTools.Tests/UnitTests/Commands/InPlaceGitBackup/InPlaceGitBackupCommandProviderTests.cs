using System;
using AdTools.Library.Commands.InPlaceGitBackup;
using AdTools.Library.Infrastructure;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Common.Logging;
using Common.Logging.Simple;
using NUnit.Framework;

namespace AdTools.Tests.UnitTests.Commands.InPlaceGitBackup
{
    [TestFixture]
    public class InPlaceGitBackupCommandProviderTests
    {
        [Test]
        public void InPlaceGitBackupNewRepositoryWithOneFileTest()
        {
            using (var testBooStrapper = new TestBootStrapper(GetType()))
            {
                using (var testFolder = TestFolderHelper.CreateTestFolder())
                {
                    testFolder.AddOneFile();
                    var target = testBooStrapper.Container.Resolve<IInPlaceGitBackupProvider>();
                    var actual = target.InPlaceGitBackup(testFolder.Path);
                    var expected = new GitBackupStatus(true, 1, 0, 0);
                    Assert.AreEqual(expected.CreateRepository, actual.CreateRepository, "CreatedRepository");
                    Assert.AreEqual(expected.NumberOfFilesAdded, actual.NumberOfFilesAdded, "NumberOfFilesAdded");
                    Assert.AreEqual(expected.NumberOfFilesChanged, actual.NumberOfFilesChanged, "NumberOfFilesChanged");
                    Assert.AreEqual(expected.NumberOfFilesRemoved, actual.NumberOfFilesRemoved, "NumberOfFilesRemoved");                    
                }
            }
        }

        [Test]
        public void InPlaceGitBackupNewRepositoryWithTwoFilesTest()
        {
            using (var testBooStrapper = new TestBootStrapper(GetType()))
            {
                using (var testFolder = TestFolderHelper.CreateTestFolder())
                {
                    testFolder.AddOneFile();
                    testFolder.AddOneFile();
                    var target = testBooStrapper.Container.Resolve<IInPlaceGitBackupProvider>();
                    var actual = target.InPlaceGitBackup(testFolder.Path);
                    var expected = new GitBackupStatus(true, 2, 0, 0);
                    Assert.AreEqual(expected.CreateRepository, actual.CreateRepository, "CreatedRepository");
                    Assert.AreEqual(expected.NumberOfFilesAdded, actual.NumberOfFilesAdded, "NumberOfFilesAdded");
                    Assert.AreEqual(expected.NumberOfFilesChanged, actual.NumberOfFilesChanged, "NumberOfFilesChanged");
                    Assert.AreEqual(expected.NumberOfFilesRemoved, actual.NumberOfFilesRemoved, "NumberOfFilesRemoved");                    
                }
            }
        }

        [Test]
        public void InPlaceGitBackupExistingRepositoryWithTwoFilesModifyingOneFileTest()
        {
            using (var testBooStrapper = new TestBootStrapper(GetType()))
            {
                using (var testFolder = TestFolderHelper.CreateTestFolder())
                {
                    var testFile1 = testFolder.AddOneFile();
                    var testFile2 = testFolder.AddOneFile();
                    var target = testBooStrapper.Container.Resolve<IInPlaceGitBackupProvider>();
                    var status = target.InPlaceGitBackup(testFolder.Path);

                    testFolder.ModifyFile(testFile1);

                    var actual = target.InPlaceGitBackup(testFolder.Path);
                    var expected = new GitBackupStatus(false, 0, 1, 0);
                    Assert.AreEqual(expected.CreateRepository, actual.CreateRepository, "CreatedRepository");
                    Assert.AreEqual(expected.NumberOfFilesAdded, actual.NumberOfFilesAdded, "NumberOfFilesAdded");
                    Assert.AreEqual(expected.NumberOfFilesChanged, actual.NumberOfFilesChanged, "NumberOfFilesChanged");
                    Assert.AreEqual(expected.NumberOfFilesRemoved, actual.NumberOfFilesRemoved, "NumberOfFilesRemoved");                    
                }
            }
        }

        [Test]
        public void InPlaceGitBackupExistingRepositoryWithTwoFilesModifyingTwoFilesTest()
        {
            using (var testBooStrapper = new TestBootStrapper(GetType()))
            {
                using (var testFolder = TestFolderHelper.CreateTestFolder())
                {
                    var testFile1 = testFolder.AddOneFile();
                    var testFile2 = testFolder.AddOneFile();
                    var target = testBooStrapper.Container.Resolve<IInPlaceGitBackupProvider>();
                    var status = target.InPlaceGitBackup(testFolder.Path);

                    testFolder.ModifyFile(testFile1);
                    testFolder.ModifyFile(testFile2);

                    var actual = target.InPlaceGitBackup(testFolder.Path);
                    var expected = new GitBackupStatus(false, 0, 2, 0);
                    Assert.AreEqual(expected.CreateRepository, actual.CreateRepository, "CreatedRepository");
                    Assert.AreEqual(expected.NumberOfFilesAdded, actual.NumberOfFilesAdded, "NumberOfFilesAdded");
                    Assert.AreEqual(expected.NumberOfFilesChanged, actual.NumberOfFilesChanged, "NumberOfFilesChanged");
                    Assert.AreEqual(expected.NumberOfFilesRemoved, actual.NumberOfFilesRemoved, "NumberOfFilesRemoved");                    
                }
            }
        }

        [Test]
        public void InPlaceGitBackupExistingRepositoryWithTwoFilesOverwritingOneFileTest()
        {
            using (var testBooStrapper = new TestBootStrapper(GetType()))
            {
                using (var testFolder = TestFolderHelper.CreateTestFolder())
                {
                    var testFile1 = testFolder.AddOneFile();
                    var testFile2 = testFolder.AddOneFile();
                    var target = testBooStrapper.Container.Resolve<IInPlaceGitBackupProvider>();
                    var status = target.InPlaceGitBackup(testFolder.Path);

                    testFolder.OverWriteButDoNotChange(testFile1);

                    var actual = target.InPlaceGitBackup(testFolder.Path);
                    var expected = new GitBackupStatus(false, 0, 0, 0);
                    Assert.AreEqual(expected.CreateRepository, actual.CreateRepository, "CreatedRepository");
                    Assert.AreEqual(expected.NumberOfFilesAdded, actual.NumberOfFilesAdded, "NumberOfFilesAdded");
                    Assert.AreEqual(expected.NumberOfFilesChanged, actual.NumberOfFilesChanged, "NumberOfFilesChanged");
                    Assert.AreEqual(expected.NumberOfFilesRemoved, actual.NumberOfFilesRemoved, "NumberOfFilesRemoved");                    
                }
            }
        }

        [Test]
        public void InPlaceGitBackupExistingRepositoryWithTwoFilesNoChangeTest()
        {
            using (var testBooStrapper = new TestBootStrapper(GetType()))
            {
                using (var testFolder = TestFolderHelper.CreateTestFolder())
                {
                    var testFile1 = testFolder.AddOneFile();
                    var testFile2 = testFolder.AddOneFile();
                    var target = testBooStrapper.Container.Resolve<IInPlaceGitBackupProvider>();
                    var status = target.InPlaceGitBackup(testFolder.Path);

                    var actual = target.InPlaceGitBackup(testFolder.Path);
                    var expected = new GitBackupStatus(false, 0, 0, 0);
                    Assert.AreEqual(expected.CreateRepository, actual.CreateRepository, "CreatedRepository");
                    Assert.AreEqual(expected.NumberOfFilesAdded, actual.NumberOfFilesAdded, "NumberOfFilesAdded");
                    Assert.AreEqual(expected.NumberOfFilesChanged, actual.NumberOfFilesChanged, "NumberOfFilesChanged");
                    Assert.AreEqual(expected.NumberOfFilesRemoved, actual.NumberOfFilesRemoved, "NumberOfFilesRemoved");                    
                }
            }
        }


        [Test]
        public void InPlaceGitBackupExistingRepositoryWithThreeFilesModifyingOneFileRemovingOneFileTest()
        {
            using (var testBooStrapper = new TestBootStrapper(GetType()))
            {
                using (var testFolder = TestFolderHelper.CreateTestFolder())
                {
                    var testFile1 = testFolder.AddOneFile();
                    var testFile2 = testFolder.AddOneFile();
                    var testFile3 = testFolder.AddOneFile();
                    var target = testBooStrapper.Container.Resolve<IInPlaceGitBackupProvider>();
                    var status = target.InPlaceGitBackup(testFolder.Path);

                    testFolder.ModifyFile(testFile1);
                    testFolder.RemoveFile(testFile2);

                    var actual = target.InPlaceGitBackup(testFolder.Path);
                    var expected = new GitBackupStatus(false, 0, 1, 1);
                    Assert.AreEqual(expected.CreateRepository, actual.CreateRepository, "CreatedRepository");
                    Assert.AreEqual(expected.NumberOfFilesAdded, actual.NumberOfFilesAdded, "NumberOfFilesAdded");
                    Assert.AreEqual(expected.NumberOfFilesChanged, actual.NumberOfFilesChanged, "NumberOfFilesChanged");
                    Assert.AreEqual(expected.NumberOfFilesRemoved, actual.NumberOfFilesRemoved, "NumberOfFilesRemoved");                    
                }
            }
        }


        internal class TestBootStrapper : IDisposable
        {
            private readonly ILog _logger;
            private IWindsorContainer _container;

            public TestBootStrapper(Type type)
            {
                _logger = new ConsoleOutLogger(type.Name, LogLevel.All, true, false, false, "yyyy-MM-dd HH:mm:ss");
            }

            public IWindsorContainer Container
            {
                get
                {
                    if (_container == null)
                    {
                        _container = new WindsorContainer();
                        _container.Register(Component.For<IWindsorContainer>().Instance(_container));

                        //Configure logging
                        _container.Register(Component.For<ILog>().Instance(_logger));

                        //Manual override registrations for interfaces that the interface under test is dependent on
                        //_container.Register(Component.For<ISomeInterface>().Instance(MockRepository.GenerateStub<ISomeInterface>()));

                        //Factory registrations example:

                        //container.Register(Component.For<ITeamProviderFactory>().AsFactory());
                        //container.Register(
                        //    Component.For<ITeamProvider>()
                        //        .ImplementedBy<CsvTeamProvider>()
                        //        .Named("CsvTeamProvider")
                        //        .LifeStyle.Transient);
                        //container.Register(
                        //    Component.For<ITeamProvider>()
                        //        .ImplementedBy<SqlTeamProvider>()
                        //        .Named("SqlTeamProvider")
                        //        .LifeStyle.Transient);

                        ///////////////////////////////////////////////////////////////////
                        //Automatic registrations
                        ///////////////////////////////////////////////////////////////////
                        //
                        //   Register all command providers and attach logging interceptor
                        //
                        const string libraryRootNameSpace = "AdTools.Library";

                        //
                        //   Register all singletons found in the library
                        //
                        _container.Register(Classes.FromAssemblyContaining<CommandDefinition>()
                            .InNamespace(libraryRootNameSpace, true)
                            .If(type => Attribute.IsDefined(type, typeof(SingletonAttribute)))
                            .WithService.DefaultInterfaces().LifestyleSingleton());

                        //
                        //   Register all transients found in the library
                        //
                        _container.Register(Classes.FromAssemblyContaining<CommandDefinition>()
                            .InNamespace(libraryRootNameSpace, true)
                            .WithService.DefaultInterfaces().LifestyleTransient());

                    }
                    return _container;
                }

            }

            ~TestBootStrapper()
            {
                Dispose(false);
            }

            public void Dispose()
            {
                Dispose(true);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (_container != null)
                    {
                        _container.Dispose();
                        _container = null;
                    }
                }
            }
        }
    }
}