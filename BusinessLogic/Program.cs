namespace BusinessLogic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.V2;
    using System.Net.Http;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    internal class Program
    {
        private static void Print(IV2Enumerable<string> data)
        {
            foreach (var element in data)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine();
        }

        /*public static async Task DoWork()
        {
            using (var httpClient = new HttpClient())
            {
                using (var httpResponse = await httpClient.GetAsync("https://www.google.com"))
                {
                    httpResponse.
                }
            }
        }*/

        private sealed class Company
        {
            public IReadOnlyDictionary<string, string> CompanyData { get; set; }

            public IReadOnlyDictionary<string, string>[] RosterData { get; set; }
        }

        private static IReadOnlyDictionary<string, string> ParseNamedParameters(string filePath)
        {
            using (var file = System.IO.File.OpenRead(filePath))
            {
                return System.Text.Json.JsonSerializer.Deserialize<IReadOnlyDictionary<string, string>>(file)
                    .ToDictionary(kvp => $"{{{kvp.Key}}}", kvp => kvp.Value);
            }
        }

        private static void ReplacePowerPointContents(IReadOnlyDictionary<string, string> namedParameters, string powerpointTemplateFilePath, string outputPowerpointFilePath)
        {
            System.IO.File.Copy(powerpointTemplateFilePath, outputPowerpointFilePath);
            var application = new Microsoft.Office.Interop.PowerPoint.Application();
            application.Presentations.Open(
                outputPowerpointFilePath,
                Microsoft.Office.Core.MsoTriState.msoFalse,
                Microsoft.Office.Core.MsoTriState.msoFalse,
                Microsoft.Office.Core.MsoTriState.msoFalse);

            foreach (Microsoft.Office.Interop.PowerPoint.Presentation presentation in application.Presentations)
            {
                foreach (Microsoft.Office.Interop.PowerPoint.Slide slide in presentation.Slides)
                {
                    foreach (Microsoft.Office.Interop.PowerPoint.Shape shape in slide.Shapes)
                    {
                        var textBoxText = shape.TextFrame.TextRange.Text;
                        if (namedParameters.TryGetValue(textBoxText, out var replacementText))
                        {
                            shape.TextFrame.TextRange.Text = replacementText;
                        }
                    }
                }

                presentation.Save();
                presentation.Close();
            }

            application.Quit();
        }

        static int Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.Error.WriteLine("3 parameters are required: the path to the company's JSON file, the path to the companys powerpoint template, and the path that the output powerpoint file should be saved to");
                return 1;
            }

            var jsonFilePath = args[0];
            var powerpointTemplateFilePath = args[1];
            var outputPowerpointFilePath = args[2];

            var namedParameters = ParseNamedParameters(jsonFilePath);
            ReplacePowerPointContents(namedParameters, powerpointTemplateFilePath, outputPowerpointFilePath);
            
            return 0;
        }

        public static IV2Enumerable<string> GetDuplicatable()
        {
            return new GetDuplicatableEnumerable();
        }

        private sealed class GetDuplicatableEnumerable : IDuplicateEnumerable<string>
        {
            private readonly bool isDuplicated;

            public GetDuplicatableEnumerable()
                : this(false)
            {
            }

            private GetDuplicatableEnumerable(bool isDuplicated)
            {
                this.isDuplicated = isDuplicated;
            }

            public IV2Enumerable<string> Duplicate()
            {
                return new GetDuplicatableEnumerable(true);
            }

            public IEnumerator<string> GetEnumerator()
            {
                if (this.isDuplicated)
                {
                    return new[] { "6789", "6789" }.AsEnumerable().GetEnumerator();
                }
                else
                {
                    return new[] { "hjkl" }.AsEnumerable().GetEnumerator();
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        public static IV2Enumerable<string> GetData2()
        {
            return new GetDataEnumerable();
        }

        private sealed class GetDataEnumerable : IWhereEnumerable<string>
        {
            private bool isWhered;

            public GetDataEnumerable()
                : this(false)
            {
            }

            private GetDataEnumerable(bool isWhered)
            {
                this.isWhered = isWhered;
            }

            public IEnumerator<string> GetEnumerator()
            {
                if (this.isWhered)
                {
                    return new[] { "asdf", "qwer" }.AsEnumerable().GetEnumerator();
                }
                else
                {
                    return new[] { "asdf", "qwer", "zxcv" }.AsEnumerable().GetEnumerator();
                }
            }

            public IV2Enumerable<string> Where(Func<string, bool> predicate)
            {
                return new GetDataEnumerable(true);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        public static IV2Enumerable<string> GetData()
        {
            return new[] { "asdf", "qwer", "zxcv" }.ToV2Enumerable();
        }
    }
}