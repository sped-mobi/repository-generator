// -----------------------------------------------------------------------
// <copyright file="ClipboardWriter.cs" company="Ollon, LLC">
//     Copyright (c) 2017 Ollon, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace System.Text
{
    public partial class ClipboardWriter
    {
        private class BlockAndComma : IDisposable
        {
            private readonly ClipboardWriter _writer;

            public BlockAndComma(ClipboardWriter writer)
            {
                _writer = writer;
                _writer.OpenBlockCore();
            }

            public void Dispose()
            {
                _writer.CloseBlockCommaCore();
            }
        }
    }
}
