// See https://aka.ms/new-console-template for more information

using System.CommandLine;
using Modeler.Samples.HR;

var documentationPathOption = new Option<string>("--documentationPath")
{
    Description = "Path to the source of documentation."
};

var generateDocumentation = new RootCommand("Generate documentation");

var generateViewsCommand = new Command("generate-views","Generate views");
generateViewsCommand.Options.Add(documentationPathOption);
generateDocumentation.Subcommands.Add(generateViewsCommand);

generateViewsCommand.SetAction(parseResult =>
{
    if (parseResult.GetValue(documentationPathOption) is { } documentationPath)
    {
        Console.WriteLine($"Views generation to {documentationPath} started.");
        ViewsGenerator.Generate(documentationPath);
        Console.WriteLine("Views generated.");
        
        Console.WriteLine("Images generation started.");
        ImagesGenerator.GenerateFromPlantUml(documentationPath, "svg");
    }
});

return generateDocumentation.Parse(args).Invoke();