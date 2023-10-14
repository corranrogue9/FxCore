namespace BusinessLogic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
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

            public IEnumerable<IReadOnlyDictionary<string, string>> RosterData { get; set; }
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
            if (args.Length != 5)
            {
                //// TODO
                Console.Error.WriteLine("3 parameters are required: the path to the company's JSON file, the path to the companys powerpoint template, and the path that the output powerpoint file should be saved to");
                return 1;
            }

            var jsonFilePath = args[0];
            var partialreviewDeckFilePath = args[1];
            var onePagersFolderPath = args[2];
            var agenciesListSlideNumber = int.Parse(args[3]);
            var outputReviewDeckFilePath = args[4];

            System.IO.File.Copy(partialreviewDeckFilePath, outputReviewDeckFilePath, true); //// TODO overwrite?
            var application = new Microsoft.Office.Interop.PowerPoint.Application(); //// TODO dispose
            try
            {
                application.Presentations.Open(
                    outputReviewDeckFilePath,
                    Microsoft.Office.Core.MsoTriState.msoFalse,
                    Microsoft.Office.Core.MsoTriState.msoFalse,
                    Microsoft.Office.Core.MsoTriState.msoFalse);

                foreach (Microsoft.Office.Interop.PowerPoint.Presentation presentation in application.Presentations)
                {
                    try
                    {
                        string[] agencies = new string[0];
                        int i = 0;
                        foreach (Microsoft.Office.Interop.PowerPoint.Slide slide in presentation.Slides)
                        {
                            if (++i != agenciesListSlideNumber)
                            {
                                //// TODO assert
                                continue;
                            }

                            string? agenciesList = null;
                            foreach (Microsoft.Office.Interop.PowerPoint.Shape shape in slide.Shapes)
                            {
                                if (shape.TextFrame.TextRange.ParagraphFormat.Bullet.Type != Microsoft.Office.Interop.PowerPoint.PpBulletType.ppBulletNone)
                                {
                                    var textBoxText = shape.TextFrame.TextRange.Text;
                                    if (!string.IsNullOrEmpty(textBoxText))
                                    {
                                        agenciesList = textBoxText;
                                        break;
                                    }
                                }
                            }

                            if (agenciesList == null)
                            {
                                throw new InvalidOperationException("TODO");
                            }

                            agencies = agenciesList.Split('\r', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                            break;
                        }

                        var missingOnePagers = new List<string>();
                        foreach (var agency in agencies)
                        {
                            var agencyOnePagerFilePath = Path.Combine(onePagersFolderPath, agency + ".pptx");
                            if (!File.Exists(agencyOnePagerFilePath))
                            {
                                missingOnePagers.Add(agencyOnePagerFilePath);
                                continue;
                            }

                            presentation.Slides.InsertFromFile(agencyOnePagerFilePath, presentation.Slides.Count, 1);
                        }

                        if (missingOnePagers.Any())
                        {
                            throw new InvalidOperationException("TODO");
                        }
                    }
                    finally
                    {
                        presentation.Save();
                        presentation.Close();
                    }
                }
            }
            finally
            {
                application.Quit();
            }

            ////var namedParameters = ParseNamedParameters(jsonFilePath);
            ////ReplacePowerPointContents(namedParameters, powerpointTemplateFilePath, outputPowerpointFilePath);

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