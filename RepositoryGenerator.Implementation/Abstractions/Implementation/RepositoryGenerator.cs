// // -----------------------------------------------------------------------
// // <copyright file="RepositoryGenerator.cs" company="sped.mobi">
// //     Copyright © 2019 Sped Mobi. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using Task = System.Threading.Tasks.Task;

    /// <summary>
    /// Defines the <see cref="RepositoryGenerator" />.
    /// </summary>
    [Export(typeof(IRepositoryGenerator))]
    public class RepositoryGenerator : IRepositoryGenerator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryGenerator"/> class.
        /// </summary>
        /// <param name="services">The services<see cref="IRepositoryGeneratorServices"/>.</param>
        [ImportingConstructor]
        public RepositoryGenerator(
            [Import] IRepositoryGeneratorServices services)
        {
            Services = services;
        }

        /// <summary>
        /// Gets the Services.
        /// </summary>
        public IRepositoryGeneratorServices Services { get; }

        /// <summary>
        /// The CreateRepositoryAsync.
        /// </summary>
        /// <param name="parameters">The parameters<see cref="IRepositoryGeneratorParameters"/>.</param>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task CreateRepositoryAsync(IRepositoryGeneratorParameters parameters, CancellationToken cancellationToken = default)
        {
            string zipFileName = Guid.NewGuid().ToString("N");
            string zipFilePath = Path.Combine(parameters.Output, $"{zipFileName}.zip");
            string targetDirectory = Path.Combine(parameters.Output, parameters.RepositoryName);
            string solutionFilePath = Path.Combine(targetDirectory, $"{parameters.SolutionName}.sln");

            SlowlyRemoveAndRecreateDirectory(targetDirectory);

            await Services.Downloader.DownloadFileAsync(DownloadUrls.Arcade, zipFilePath);

            await Services.Expander.ExpandFileAsync(zipFilePath, targetDirectory);

            ProcessRun1(parameters, targetDirectory, solutionFilePath);

            var replacements = Services.Replace.Create(parameters);

            ProcessRun2(targetDirectory, replacements);

            if (File.Exists(solutionFilePath))
                await Services.Opener.OpenRepositoryAsync(solutionFilePath);
        }

        /// <summary>
        /// The ProcessRun2.
        /// </summary>
        /// <param name="targetDirectory">The targetDirectory<see cref="string"/>.</param>
        /// <param name="replacements">The replacements<see cref="Dictionary{string, string}"/>.</param>
        private void ProcessRun2(string targetDirectory, Dictionary<string, string> replacements)
        {
            var files = Directory.GetFiles(targetDirectory, "*.*", SearchOption.AllDirectories).Select(x => new FileInfo(x));
            foreach (var file in files)
            {
                ProcessFileInfo(file, replacements);
            }
        }

        /// <summary>
        /// The ProcessRun1.
        /// </summary>
        /// <param name="parameters">The parameters<see cref="IRepositoryGeneratorParameters"/>.</param>
        /// <param name="targetDirectory">The targetDirectory<see cref="string"/>.</param>
        /// <param name="solutionFilePath">The solutionFilePath<see cref="string"/>.</param>
        private void ProcessRun1(IRepositoryGeneratorParameters parameters, string targetDirectory, string solutionFilePath)
        {
            var files = Directory.GetFiles(targetDirectory, "*.*", SearchOption.AllDirectories).Select(x => new FileInfo(x));

            foreach (var file in files)
            {
                switch (file.Name)
                {
                    case "ArcadeRepo.sln":
                        {
                            File.Copy(file.FullName, solutionFilePath);
                            File.Delete(file.FullName);
                            break;
                        }
                    case "ArcadeRepo.csproj":
                        {
                            string newDir = Path.Combine(targetDirectory, "src", parameters.ProjectName);
                            Directory.CreateDirectory(newDir);
                            string newPath = Path.Combine(targetDirectory, "src", parameters.ProjectName, $"{parameters.ProjectName}.csproj");
                            File.Move(file.FullName, newPath);
                            file.Directory.Delete(true);
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// The SlowlyRemoveAndRecreateDirectory.
        /// </summary>
        /// <param name="targetDirectory">The targetDirectory<see cref="string"/>.</param>
        private static void SlowlyRemoveAndRecreateDirectory(string targetDirectory)
        {
            if (Directory.Exists(targetDirectory))
            {
                string[] files = Directory.GetFiles(targetDirectory, "*.*", SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    File.Delete(file);
                }

                try
                {
                    Directory.Delete(targetDirectory, true);
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.Message);
                    //Logger.Log(ex.Message);
                }
            }

            try
            {
                Directory.CreateDirectory(targetDirectory);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                //Logger.Log(ex.Message);
            }
        }

        /// <summary>
        /// The ProcessFileInfo.
        /// </summary>
        /// <param name="info">The info<see cref="FileInfo"/>.</param>
        /// <param name="replacements">The replacements<see cref="Dictionary{string, string}"/>.</param>
        private void ProcessFileInfo(FileInfo info, Dictionary<string, string> replacements)
        {
            string text = Services.Replace.Replace(File.ReadAllText(info.FullName), replacements);
            File.WriteAllText(info.FullName, text);
        }
    }
}
