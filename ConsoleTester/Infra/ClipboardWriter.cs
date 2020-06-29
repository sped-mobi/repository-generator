// -----------------------------------------------------------------------
// <copyright file="ClipboardWriter.cs" company="Ollon, LLC">
//     Copyright (c) 2017 Ollon, LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.IO;
using System.Windows;

namespace System.Text
{
    /// <summary>
    /// Defines the <see cref="ClipboardWriter" />
    /// </summary>
    public partial class ClipboardWriter : IndentedWriter
    {
        private readonly StringBuilder _builder;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClipboardWriter"/> class.
        /// </summary>
        /// <param name="builder">The builder<see cref="StringBuilder"/></param>
        /// <param name="tabStyle">The tabStyle<see cref="TabStyle"/></param>
        /// <param name="useClipboard">The useClipboard<see cref="bool"/></param>
        public ClipboardWriter(StringBuilder builder, TabStyle tabStyle = TabStyle.QuadrupleSpace, bool useClipboard = false) : this(
            new StringWriter(builder),
            tabStyle,
            useClipboard)
        {
            _builder = builder;
            UseClipboard = useClipboard;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClipboardWriter"/> class.
        /// </summary>
        /// <param name="tabStyle">The tabStyle<see cref="TabStyle"/></param>
        /// <param name="useClipboard">The useClipboard<see cref="bool"/></param>
        public ClipboardWriter(TabStyle tabStyle = TabStyle.QuadrupleSpace, bool useClipboard = true)
            : this(new StringWriter(), tabStyle, useClipboard)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClipboardWriter"/> class.
        /// </summary>
        /// <param name="writer">The writer<see cref="TextWriter"/></param>
        /// <param name="tabStyle">The tabStyle<see cref="TabStyle"/></param>
        /// <param name="useClipboard">The useClipboard<see cref="bool"/></param>
        public ClipboardWriter(TextWriter writer, TabStyle tabStyle = TabStyle.QuadrupleSpace, bool useClipboard = true) : base(writer,
            ConvertToSpaces(tabStyle))
        {
            UseClipboard = useClipboard;
        }

        /// <summary>
        /// Gets the Encoding
        /// </summary>
        public override Encoding Encoding => Encoding.ASCII;

        /// <summary>
        /// Gets or sets the NewLine
        /// </summary>
        public override string NewLine
        {
            get => "\r\n";
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether UseClipboard
        /// </summary>
        public bool UseClipboard { get; set; }

        /// <summary>
        /// The CreateForConsoleOutput
        /// </summary>
        /// <param name="tabStyle">The tabStyle<see cref="TabStyle"/></param>
        /// <param name="useClipboard">The useClipboard<see cref="bool"/></param>
        /// <returns>The <see cref="ClipboardWriter"/></returns>
        public static ClipboardWriter CreateForConsoleOutput(TabStyle tabStyle = TabStyle.QuadrupleSpace, bool useClipboard = true)
        {
            return new ClipboardWriter(Console.Out, tabStyle, useClipboard);
        }

        /// <summary>
        /// The CreateForStringBuilder
        /// </summary>
        /// <param name="builder">The builder<see cref="StringBuilder"/></param>
        /// <param name="tabStyle">The tabStyle<see cref="TabStyle"/></param>
        /// <param name="useClipboard">The useClipboard<see cref="bool"/></param>
        /// <returns>The <see cref="ClipboardWriter"/></returns>
        public static ClipboardWriter CreateForStringBuilder(StringBuilder builder,
            TabStyle tabStyle = TabStyle.QuadrupleSpace,
            bool useClipboard = true)
        {
            return new ClipboardWriter(builder, tabStyle, useClipboard);
        }

        /// <summary>
        /// The Clip
        /// </summary>
        public void Clip()
        {
            Clipboard.SetText(ToString());
        }

        /// <summary>
        /// The Close
        /// </summary>
        public override void Close()
        {
            InnerWriter.Close();
        }

        /// <summary>
        /// The CloseBlockCommaCore
        /// </summary>
        public void CloseBlockCommaCore()
        {
            PopIndent();
            WriteLine("},");
        }

        /// <summary>
        /// The CloseBlockSemicolonCore
        /// </summary>
        public void CloseBlockSemicolonCore()
        {
            PopIndent();
            WriteLine("};");
        }

        /// <summary>
        /// The Flush
        /// </summary>
        public override void Flush()
        {
            InnerWriter.Flush();
        }

        /// <summary>
        /// The OpenBlockComma
        /// </summary>
        /// <returns>The <see cref="IDisposable"/></returns>
        public IDisposable OpenBlockComma()
        {
            return new BlockAndComma(this);
        }

        /// <summary>
        /// The OpenBlockSemicolon
        /// </summary>
        /// <returns>The <see cref="IDisposable"/></returns>
        public IDisposable OpenBlockSemicolon()
        {
            return new BlockAndSemicolon(this);
        }

        /// <summary>
        /// The ToString
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return _builder.ToString();
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.IO.TextWriter" /> and optionally releases the
        /// managed resources.
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
        /// The ConvertToSpaces
        /// </summary>
        /// <param name="style">The style<see cref="TabStyle"/></param>
        /// <returns>The <see cref="string"/></returns>
        private static string ConvertToSpaces(TabStyle style)
        {
            switch (style)
            {
                case TabStyle.SingleSpace:
                    return " ";
                case TabStyle.DoubleSpace:
                    return "  ";
                case TabStyle.TripleSpace:
                    return "   ";
                case TabStyle.QuadrupleSpace:
                    return "    ";
                case TabStyle.TabCharacter:
                    return "\t";
                default:
                    return "";
            }
        }
    }
}
