// // -----------------------------------------------------------------------
// // <copyright file="ReplacementsService.cs" company="sped.mobi">
// //     Copyright © 2019 Sped Mobi. All rights reserved.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    /// <summary>
    /// Defines the <see cref="ReplacementsService" />.
    /// </summary>
    [Export(typeof(IReplacementsService))]
    public class ReplacementsService : IReplacementsService
    {
        /// <summary>
        /// The Create.
        /// </summary>
        /// <param name="parameters">The parameters<see cref="IRepositoryGeneratorParameters"/>.</param>
        /// <returns>The <see cref="Dictionary{string, string}"/>.</returns>
        public Dictionary<string, string> Create(IRepositoryGeneratorParameters parameters)
        {
            return CreateReplacementsDictionary(
                parameters.ProjectName,
                parameters.Description,
                parameters.RootNamespace,
                parameters.RepositoryName,
                parameters.TargetFramework);
        }

        /// <summary>
        /// The Replace.
        /// </summary>
        /// <param name="input">The input<see cref="string"/>.</param>
        /// <param name="replacements">The replacements<see cref="Dictionary{string, string}"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string Replace(string input, Dictionary<string, string> replacements)
        {
            string retVal = input;
            foreach (var kvp in replacements)
            {
                retVal = retVal.Replace(kvp.Key, kvp.Value);
            }

            return retVal;
        }

        /// <summary>
        /// The CreateReplacementsDictionary.
        /// </summary>
        /// <param name="name">The name<see cref="string"/>.</param>
        /// <param name="description">The description<see cref="string"/>.</param>
        /// <param name="defaultNamespace">The defaultNamespace<see cref="string"/>.</param>
        /// <param name="repositoryName">The repositoryName<see cref="string"/>.</param>
        /// <param name="targetFramework">The targetFramework<see cref="TargetFramework"/>.</param>
        /// <returns>The <see cref="Dictionary{string, string}"/>.</returns>
        private Dictionary<string, string> CreateReplacementsDictionary(
            string name,
            string description,
            string defaultNamespace,
            string repositoryName,
            TargetFramework targetFramework)
        {
            string tf = string.Empty;
            switch (targetFramework)
            {
                case TargetFramework.Net_472:
                    tf = "net472";
                    break;
                case TargetFramework.Net_48:
                    tf = "net48";
                    break;
                case TargetFramework.NetStandard_2_0:
                    tf = "netstandard2.0";
                    break;

                case TargetFramework.NetStandard_2_1:
                    tf = "netstandard2.1";
                    break;

                case TargetFramework.NetCoreApp_2_0:
                    tf = "netcoreapp2.0";
                    break;
                case TargetFramework.NetCoreApp_2_1:
                    tf = "netcoreapp2.1";
                    break;
                case TargetFramework.NetCoreApp_2_2:
                    tf = "netcoreapp2.2";
                    break;
                case TargetFramework.NetCoreApp_3_0:
                    tf = "netcoreapp3.0";
                    break;

                case TargetFramework.NetCoreApp_3_1:
                    tf = "netcoreapp3.1";
                    break;
                case TargetFramework.NetCoreApp_3_2:
                    tf = "netcoreapp3.2";
                    break;
                case TargetFramework.NetCoreApp_3_3:
                    tf = "netcoreapp3.3";
                    break;
            }

            return new Dictionary<string, string>
            {
                ["{{name}}"] = name,
                ["{{repositoryName}}"] = repositoryName,
                ["{{targetFramework}}"] = tf,
                ["{{defaultNamespace}}"] = defaultNamespace,
                ["{{description}}"] = description,
                ["{{codeGeneratorGuid}}"] = GenerateGuid(),
                ["{{buildGuid}}"] = GenerateGuid(),
                ["{{toolsGuid}}"] = GenerateGuid(),
                ["{{arcadeRepoGuid}}"] = GenerateGuid(),
                ["{{solutionGuid}}"] = GenerateGuid()
            };
        }

        /// <summary>
        /// The GenerateGuid.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        private static string GenerateGuid() => Guid.NewGuid().ToString("B").ToUpper();
    }
}
