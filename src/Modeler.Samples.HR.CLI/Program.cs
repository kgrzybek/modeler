// See https://aka.ms/new-console-template for more information

using Modeler.Samples.HR;

if (args.Length != 1)
{
    throw new Exception("Provide path to documentation output directory");
}

var documentationPath = args[0];

Console.WriteLine($"Documentation generation to {documentationPath} started.");

ViewsGenerator.Generate(documentationPath);

Console.WriteLine("Documentation generated.");