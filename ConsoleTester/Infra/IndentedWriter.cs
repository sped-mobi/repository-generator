// -----------------------------------------------------------------------
// <copyright file="IndentedWriter.cs" company="sped.mobi">
//     Copyright (c) 2019 Brad Marshall. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.IO;
using System.Text;

namespace System.Text
{
    /// <summary>
    /// Text writer that handles complicated indentations with ease.
    /// </summary>
    public class IndentedWriter : TextWriter
    {
        private bool _needIndent;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndentedWriter"/> class.
        /// </summary>
        /// <param name="builder">The builder<see cref="StringBuilder"/></param>
        /// <param name="indentString">The indentString<see cref="string"/></param>
        public IndentedWriter(StringBuilder builder, string indentString = "    ")
        {
            IndentString = indentString;
            InnerWriter = new StringWriter(builder);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IndentedWriter"/> class.
        /// </summary>
        /// <param name="writer">The writer<see cref="TextWriter"/></param>
        /// <param name="indentString">The indentString<see cref="string"/></param>
        public IndentedWriter(TextWriter writer, string indentString = "    ")
        {
            IndentString = indentString;
            InnerWriter = writer;
        }

        /// <summary>
        /// Gets the Encoding
        /// </summary>
        public override Encoding Encoding => Encoding.ASCII;

        /// <summary>
        /// Gets or sets the Indent
        /// </summary>
        public int Indent { get; set; }

        /// <summary>
        /// Gets the IndentString
        /// </summary>
        public string IndentString { get; }

        /// <summary>
        /// Gets the InnerWriter
        /// </summary>
        public TextWriter InnerWriter { get; }

        /// <summary>
        /// The Close
        /// </summary>
        public override void Close()
        {
            InnerWriter.Close();
        }

        /// <summary>
        /// The Flush
        /// </summary>
        public override void Flush()
        {
            InnerWriter.Flush();
        }

        /// <summary>
        /// The OpenBlock
        /// </summary>
        /// <returns>The <see cref="IDisposable"/></returns>
        public IDisposable OpenBlock()
        {
            return new Block(this);
        }

        /// <summary>
        /// The PopIndent
        /// </summary>
        public void PopIndent()
        {
            Indent--;
        }

        /// <summary>
        /// The PushIndent
        /// </summary>
        public void PushIndent()
        {
            Indent++;
        }

        /// <summary>
        /// The Write
        /// </summary>
        /// <param name="value">The value<see cref="char"/></param>
        public override void Write(char value)
        {
            WriteIndentIfNeeded();
            InnerWriter.Write(value);
        }

        /// <summary>
        /// The Write
        /// </summary>
        /// <param name="value">The value<see cref="long"/></param>
        public override void Write(long value)
        {
            WriteIndentIfNeeded();
            InnerWriter.Write(value);
        }

        /// <summary>
        /// The Write
        /// </summary>
        /// <param name="value">The value<see cref="object"/></param>
        public override void Write(object value)
        {
            WriteIndentIfNeeded();
            InnerWriter.Write(value);
        }

        /// <summary>
        /// The Write
        /// </summary>
        /// <param name="value">The value<see cref="string"/></param>
        public override void Write(string value)
        {
            WriteIndentIfNeeded();
            InnerWriter.Write(value);
        }

        /// <summary>
        /// The WriteIndent
        /// </summary>
        public void WriteIndent()
        {
            _needIndent = false;
            for (int i = 0; i < Indent; i++)
            {
                InnerWriter.Write(IndentString);
            }
        }

        /// <summary>
        /// The WriteLine
        /// </summary>
        public override void WriteLine()
        {
            InnerWriter.WriteLine();
            _needIndent = true;
        }

        /// <summary>
        /// The WriteLine
        /// </summary>
        /// <param name="value">The value<see cref="char"/></param>
        public override void WriteLine(char value)
        {
            WriteIndentIfNeeded();
            InnerWriter.WriteLine(value);
            _needIndent = true;
        }

        /// <summary>
        /// The WriteLine
        /// </summary>
        /// <param name="value">The value<see cref="long"/></param>
        public override void WriteLine(long value)
        {
            WriteIndentIfNeeded();
            InnerWriter.WriteLine(value);
            _needIndent = true;
        }

        /// <summary>
        /// The WriteLine
        /// </summary>
        /// <param name="value">The value<see cref="object"/></param>
        public override void WriteLine(object value)
        {
            WriteIndentIfNeeded();
            InnerWriter.WriteLine(value);
            _needIndent = true;
        }

        /// <summary>
        /// The WriteLine
        /// </summary>
        /// <param name="value">The value<see cref="string"/></param>
        public override void WriteLine(string value)
        {
            if (_needIndent)
            {
                WriteIndent();
            }

            InnerWriter.WriteLine(value);
            _needIndent = true;
        }

        /// <summary>
        /// The CloseBlockCore
        /// </summary>
        protected virtual void CloseBlockCore()
        {
            PopIndent();
            WriteLine("}");
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        /// <param name="disposing">The disposing<see cref="bool"/></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                InnerWriter.Dispose();
            }
        }

        /// <summary>
        /// The OpenBlockCore
        /// </summary>
        protected virtual void OpenBlockCore()
        {
            WriteLine("{");
            PushIndent();
        }

        /// <summary>
        /// The WriteIndentIfNeeded
        /// </summary>
        private void WriteIndentIfNeeded()
        {
            if (_needIndent)
            {
                WriteIndent();
            }
        }

        /// <summary>
        /// Defines the <see cref="Block" />
        /// </summary>
        private class Block : IDisposable
        {
            /// <summary>
            /// Defines the _writer
            /// </summary>
            private readonly IndentedWriter _writer;

            /// <summary>
            /// Initializes a new instance of the <see cref="Block"/> class.
            /// </summary>
            /// <param name="writer">The writer<see cref="IndentedWriter"/></param>
            public Block(IndentedWriter writer)
            {
                _writer = writer;
                _writer.OpenBlockCore();
            }

            /// <summary>
            /// The Dispose
            /// </summary>
            public void Dispose()
            {
                _writer.CloseBlockCore();
            }
        }
    }
}
