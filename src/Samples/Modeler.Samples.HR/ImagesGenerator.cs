using CliWrap;
using CliWrap.Buffered;

namespace Modeler.Samples.HR;

public static class ImagesGenerator
{
    public static void GenerateFromPlantUml(string modelsPath, string destinationImageType)
    {
        const string plantUmlProgram = "plantuml";
        try
        {
            var result = Cli.Wrap(plantUmlProgram).WithArguments("--version").ExecuteBufferedAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            Console.WriteLine($"{plantUmlProgram} found:");
            Console.Write(result.StandardOutput);
        }
        catch (Exception)
        {
            Console.WriteLine($"{plantUmlProgram} program not found. Add it to environment variables.");
            return;
        }

        Console.WriteLine("Images generation...");
        Cli.Wrap(plantUmlProgram)
            .WithArguments([
                $"{modelsPath}/**/*.puml" ,
                $"-t{destinationImageType}"
            ])
            .ExecuteBufferedAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        Console.WriteLine("Images generated.");
    }
}