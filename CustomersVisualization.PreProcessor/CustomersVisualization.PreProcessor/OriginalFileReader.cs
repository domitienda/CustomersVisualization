using System;
using System.Collections.Generic;
using System.IO;

namespace CustomersVisualization.PreProcessor
{
    public class OriginalFileReader
    {
        private const string OriginalFile = "customers.csv";
        private const char Separator = ';';

        public IEnumerable<OriginalRecord> ReadInitialFile()
        {
            var result = new List<OriginalRecord>();

            using (var streamReader = File.OpenText(OriginalFile))
            {
                var rawContent = streamReader.ReadToEnd();
                var lines = rawContent.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                foreach (var line in lines)
                {
                    var tokens = line.Split(Separator);

                    result.Add(new OriginalRecord
                    {
                        EventDateTime = DateTime.Parse(tokens[0]),
                        Town = tokens[1],
                        Country = tokens[2]
                    });
                }
            }

            return result;
        }
    }
}
