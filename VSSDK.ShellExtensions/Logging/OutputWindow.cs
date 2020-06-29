using Microsoft.VisualStudio.Shell.Interop;
using System;

namespace Microsoft.VisualStudio.Shell
{
    public class OutputWindow
    {
        private IServiceProvider _provider;
        private IVsOutputWindow _window;

        public OutputWindow(IServiceProvider serviceProvider)
        {
            _provider = serviceProvider;
        }

        protected IVsOutputWindow Window
        {
            get
            {
                return _window ?? (_window = _provider.GetService<SVsOutputWindow, IVsOutputWindow>());
            }
        }

        public void ActivatePane(Guid guidPane)
        {
            if (!ErrorHandler.Succeeded(GetPane(guidPane, out IVsOutputWindowPane pane)) || pane == null)
                return;
            pane.Activate();
        }

        public Guid CreatePane(string paneName, bool visible, bool clearWithSolution)
        {
            Guid rguidPane = Guid.NewGuid();
            if (string.IsNullOrEmpty(paneName))
                throw new ArgumentNullException(nameof(paneName));
            if (ErrorHandler.Failed(GetPane(rguidPane, out IVsOutputWindowPane outputWindowPane)) && outputWindowPane == null)
            {
                if (ErrorHandler.Succeeded(_window.CreatePane(ref rguidPane, paneName, visible ? 1 : 0, clearWithSolution ? 1 : 0)))
                    _window.GetPane(ref rguidPane, out outputWindowPane);
            }
            else if (!visible)
                outputWindowPane.Hide();
            else
                outputWindowPane.Activate();
            if (outputWindowPane == null)
                throw new InvalidOperationException();
            return rguidPane;
        }

        public void DeletePane(Guid guidPane)
        {
            if (guidPane == Guid.Empty)
                throw new ArgumentNullException(nameof(guidPane));
            if (!ErrorHandler.Succeeded(GetPane(guidPane, out IVsOutputWindowPane pane)) || pane == null)
                return;
            Guid rguidPane = guidPane;
            _window.DeletePane(ref rguidPane);
        }

        public void WriteMessage(string message)
        {
            WriteMessage(Guid.Empty, message);
        }

        public void WriteMessage(Guid guidPane, string message)
        {
            if (string.IsNullOrEmpty(message))
                return;
            message = FormatMessage(message);
            Guid guidPane1 = guidPane;
            if (guidPane1 == Guid.Empty)
                guidPane1 = VSConstants.GUID_OutWindowGeneralPane;
            if ((ErrorHandler.Failed(GetPane(guidPane1, out IVsOutputWindowPane pane)) || pane == null) && guidPane1.Equals(VSConstants.GUID_OutWindowGeneralPane))
                pane = _provider.GetService<SVsGeneralOutputWindowPane, IVsOutputWindowPane>();
            pane?.OutputStringThreadSafe(message);
        }

        public void Clear(Guid guidPane)
        {
            Guid guidPane1 = guidPane;
            if (guidPane1 == Guid.Empty)
                guidPane1 = VSConstants.GUID_OutWindowGeneralPane;
            if (!ErrorHandler.Succeeded(GetPane(guidPane1, out IVsOutputWindowPane pane)) || pane == null)
                return;
            pane.Clear();
        }

        private int GetPane(Guid guidPane, out IVsOutputWindowPane pane)
        {
            if (Window == null)
                throw new InvalidOperationException();
            Guid rguidPane = guidPane;
            return Window.GetPane(ref rguidPane, out pane);
        }

        private static string FormatMessage(string message)
        {
            string str = message;
            if (!str.EndsWith("\r\n", StringComparison.OrdinalIgnoreCase))
                str += "\r\n";
            return str;
        }
    }
}
