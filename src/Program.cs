using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: dotnet run 'path to input file' 'path to output file'");
            return;
        }

        string inputFile = args[0];
        string outputFile = args[1];

        try
        {
            ConvertPlaylistToText(inputFile, outputFile);
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void ConvertPlaylistToText(string inputFile, string outputFile)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(inputFile);

        XmlNodeList displayNames = doc.SelectNodes("//Property[@Name='DisplayName']/@Value");
        XmlNodeList namespaces = doc.SelectNodes("//Property[@Name='Namespace']/@Value");
        XmlNodeList classes = doc.SelectNodes("//Property[@Name='Class']/@Value");
        XmlNodeList qualifiedName = doc.SelectNodes("//Property[@Name='TestWithNormalizedFullyQualifiedName']/@Value");

        HashSet<string> uniqueMethods = new HashSet<string>();

        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            for (int i = 0; i < namespaces.Count; i++)
            {
                for (int j = 0; j < classes.Count; j++)
                {
                    for (int k = 0; k < displayNames.Count; k++)
                    {
                        string namespaceValue = i < namespaces.Count ? namespaces[i].Value : string.Empty;
                        string classValue = j < classes.Count ? classes[j].Value : string.Empty;
                        string methodName = displayNames[k].Value;
                        string combinedMethodName = $"{namespaceValue}.{classValue}.{methodName}";

                        for (int l = 0; l < qualifiedName.Count; l++)
                        {
                            string validation = qualifiedName[l].Value;
                            if (combinedMethodName.Contains(validation))
                            {
                                writer.WriteLine(combinedMethodName);
                            }
                        }
                    }
                }
            }
        }
    }
}
