using System;

namespace Dog
{
    //ファイルの一行を扱うクラス
    public class Line
    {
        public static String AddLineNumber(String? line, int lineNumber)
        {
            if (line == null) return "";
            var editedLine = string.Format("  {0} {1}", lineNumber, line);
            return editedLine;
        }
    }
}
