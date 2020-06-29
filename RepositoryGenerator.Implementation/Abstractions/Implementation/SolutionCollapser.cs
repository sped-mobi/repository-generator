namespace Microsoft.VisualStudio.RepositoryGenerator.Abstractions.Implementation
{
    using EnvDTE;
    using EnvDTE80;
    using System.ComponentModel.Composition;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="SolutionCollapser" />.
    /// </summary>
    [Export(typeof(ISolutionCollapser))]
    public class SolutionCollapser : ISolutionCollapser
    {
        /// <summary>
        /// Defines the _dte.
        /// </summary>
        private readonly EnvDTE80.DTE2 _dte;

        /// <summary>
        /// Initializes a new instance of the <see cref="SolutionCollapser"/> class.
        /// </summary>
        /// <param name="dte">The dte<see cref="DTE2"/>.</param>
        [ImportingConstructor]
        public SolutionCollapser(
            [Import] DTE2 dte)
        {
            _dte = dte;
        }

        /// <summary>
        /// The CollapseSolutionAsync.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task CollapseSolutionAsync()
        {
            await VisualStudio.Shell.ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            UIHierarchy solutionExplorer = _dte.ToolWindows.SolutionExplorer;
            if (solutionExplorer.UIHierarchyItems.Count <= 0)
                return;
            UIHierarchyItem rootNode = solutionExplorer.UIHierarchyItems.Item(1);
            Collapse(rootNode, ref solutionExplorer);
            rootNode.Select(vsUISelectionType.vsUISelectionTypeSelect);
            rootNode.DTE.SuppressUI = false;
        }

        /// <summary>
        /// The Collapse.
        /// </summary>
        /// <param name="item">The item<see cref="UIHierarchyItem"/>.</param>
        /// <param name="solutionExplorer">The solutionExplorer<see cref="UIHierarchy"/>.</param>
        public void Collapse(UIHierarchyItem item, ref UIHierarchy solutionExplorer)
        {
            foreach (UIHierarchyItem innerItem in item.UIHierarchyItems)
            {
                if (innerItem.UIHierarchyItems.Count > 0)
                {
                    Collapse(innerItem, ref solutionExplorer);
                    if (innerItem.UIHierarchyItems.Expanded)
                    {
                        innerItem.UIHierarchyItems.Expanded = false;
                        if (innerItem.UIHierarchyItems.Expanded)
                        {
                            innerItem.Select(vsUISelectionType.vsUISelectionTypeSelect);
                            solutionExplorer.DoDefaultAction();
                        }
                    }
                }
            }
        }
    }
}
