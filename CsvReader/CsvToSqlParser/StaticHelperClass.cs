using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CsvToSqlParser
{
    public static class StaticHelperClass
    {
        public static int GetCsvLineCount(string fileName)
        {
            int count = 0;
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read, 32768, true))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    while (streamReader.ReadLine() != null)
                        count++;
                }
            }
            return count - 1;
        }

        
        public static List<string> SplitString(char delimiter, string stringToSplit, int WhiteSpaceTrimState)
        {
            var result = new List<string>();
            //var temp = "";
            StringBuilder builder = new StringBuilder();

            bool isDoubleQuotesEscaped = false;
            for (int i = 0; i < stringToSplit.Length; i++)
            {
                if (stringToSplit[0] == '#')
                    return null;

                if (stringToSplit[i] == '"')
                {
                    if ((i > 1 && stringToSplit[i - 1] == delimiter) ||
                        (i < stringToSplit.Length - 1 && stringToSplit[i + 1] == delimiter) ||
                        i == stringToSplit.Length - 1 ||
                        (i > 1) && stringToSplit[i - 1] == '\\')
                    {
                        isDoubleQuotesEscaped = !isDoubleQuotesEscaped;

                    }
                }
                if (stringToSplit[i] == delimiter && !isDoubleQuotesEscaped)
                {
                    if (i > 1)
                    {
                        if (stringToSplit[i - 1] != '\\')
                        {
                            result.Add(builder.ToString());
                            builder.Clear();
                            continue;
                        }
                    }

                }
                if (stringToSplit[i] != '\\')
                    builder.Append(stringToSplit[i]);

            }
            if (isDoubleQuotesEscaped)
                throw new InvalidDataException("CSV file format is invalid!");

            result.Add(builder.ToString());

            // trim whitespaces for the unescaped lines

            if (WhiteSpaceTrimState == 1)
                return TrimAllWhiteSpaces(result);
            else if (WhiteSpaceTrimState == 2)
                return NormalizeWhiteSpaces(result);
            else
            {
                for (var i = 0; i < result.Count; i++)
                {
                    result[i] = CheckAndRemoveEncirclingQuotes(result[i], out bool mod);
                }
                return result;
            }
        }

        private static List<string> TrimAllWhiteSpaces(List<string> data)
        {
            for (var i = 0; i < data.Count; i++)
            {
                CheckAndRemoveEncirclingQuotes(data[i], out bool mod);
                if (!mod)
                {
                    data[i] = new string(data[i]
                        .ToCharArray()
                        .Where(c => !Char.IsWhiteSpace(c))
                        .ToArray());
                }
            }
            return data;
        }

        private static List<string> NormalizeWhiteSpaces(List<string> data)
        {
            StringBuilder sb = new StringBuilder();

            bool isWhite = false;

            for (int i = 0; i < data.Count; i++)
            {
                try
                {
                    CheckAndRemoveEncirclingQuotes(data[i], out bool mod);
                    if (!mod)
                    {
                        sb.Clear();
                        foreach (var c in data[i].ToCharArray())
                        {
                            if (Char.IsWhiteSpace(c))
                            {
                                if (!isWhite)
                                {
                                    isWhite = true;
                                    sb.Append(c.ToString());
                                }
                            }
                            else
                            {
                                sb.Append(c.ToString());
                                isWhite = false;
                            }
                        }

                        data[i] = sb.ToString();
                    }
                }
                catch { continue; }
            }

            return data;
        }

        private static string CheckAndRemoveEncirclingQuotes(string input, out bool isModified)
        {
            isModified = false;

            if (input != string.Empty)
            {
                if (input[0] == '"' && input[input.Length - 1] == '"')
                {
                    input = input.Remove(0, 1);
                    input = input.Remove(input.Length - 1, 1);
                    isModified = true;
                }
            }


            return input;
        }
    }
}
