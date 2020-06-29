using EnvDTE;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.VisualStudio.Shell.Hierarchy
{
    public static partial class IVsSolutionExtensions
    {
        public static IVsHierarchy GetProject(this IVsSolution2 source, string projectName)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            SolutionWrapper solution = new SolutionWrapper();
            ProjectEnumerator projects = new ProjectEnumerator(solution);
            return projects.FindProject(projectName);
        }

        public static IEnumerable<IVsHierarchy> GetProjects(this IVsSolution source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            SolutionWrapper solution = new SolutionWrapper(source);
            return new ProjectEnumerator(solution);
        }

        public static IEnumerable<Project> GetDTEProjects(this IVsSolution source)
        {
            return GetProjects(source).Select(IVsHierarchyExtensions.ToProject);
        }
    }
}
