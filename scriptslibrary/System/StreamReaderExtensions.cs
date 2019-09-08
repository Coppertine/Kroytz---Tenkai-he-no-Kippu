using System;
using System.IO;
using System.Runtime.Serialization;

public static class StreamReaderExtensions {
    public static void ParseSections(this StreamReader reader, Action<string> action)
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            line = line.Trim();
            if (line.StartsWith("[") && line.EndsWith("]"))
            {
                var sectionName = line.Substring(1, line.Length - 2);
                action(sectionName);
            }
        }
    }
    /// <summary>
    /// Calls the action with the content of a line, until it finds a blank line or the end of the file.
    /// </summary>
    public static void ParseSectionLines(this StreamReader reader, Action<string> action, bool trimLines = true)
    {
        var line = string.Empty;
        try
        {
            while ((line = reader.ReadLine()) != null)
            {
                if (trimLines) line = line.Trim();
                if (line.Length == 0) return;

                action(line);
            }
        }
        catch (Exception e)
        {
            throw new SectionLineParsingFailedException($"Failed to parse line \"{line}\".", e);
        }
    }

    [Serializable]
    public class SectionLineParsingFailedException : Exception
    {
        public SectionLineParsingFailedException()
        {
        }

        public SectionLineParsingFailedException(string message) : base(message)
        {
        }

        public SectionLineParsingFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SectionLineParsingFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}