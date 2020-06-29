using EnvDTE;
using System.Collections.Generic;

namespace Microsoft.VisualStudio.Shell.Hierarchy
{
    public static class EnvDTEExtensions
    {
        public static IEnumerable<ProjectItem> GetAllProjectItems(this ProjectItem projectItem)
        {
            return GetAllProjectItems(projectItem.ProjectItems, true);
        }
        public static IEnumerable<ProjectItem> GetAllProjectItems(this Project project)
        {
            return GetAllProjectItems(project.ProjectItems, true);
        }

        private static IEnumerable<ProjectItem> GetAllProjectItems(ProjectItems collection, bool recursive = true)
        {
            foreach (ProjectItem item in collection)
            {
                yield return item;
                if (recursive)
                {
                    IEnumerable<ProjectItem> children = GetAllProjectItems(item.ProjectItems, recursive);
                    if (children != null)
                    {
                        foreach (ProjectItem childItem in children)
                            yield return childItem;
                    }
                }
            }
        }
    }
}
