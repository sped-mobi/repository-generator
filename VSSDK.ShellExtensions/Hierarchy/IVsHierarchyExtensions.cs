using EnvDTE;
using Microsoft.VisualStudio.Shell.Interop;

namespace Microsoft.VisualStudio.Shell.Hierarchy
{
    public static class IVsHierarchyExtensions
    {
        public static Project ToProject(this IVsHierarchy hierarchy)
        {
            return (Project)new ProjectWrapper(hierarchy).ExtObject;
        }
    }
}
