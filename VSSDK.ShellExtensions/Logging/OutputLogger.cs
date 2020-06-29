using System;

namespace Microsoft.VisualStudio.Shell
{
    public static class OutputLogger
    {
        private static OutputWindow _window;

        public static void Initialize(OutputWindow window)
        {
            _window = window;
        }

        public static void Log(string message)
        {
            _window.WriteMessage(message);
        }

        public static void Log(Exception exception)
        {
            Log(exception.Message);
        }
    }
}
