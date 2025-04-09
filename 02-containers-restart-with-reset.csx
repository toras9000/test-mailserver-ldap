#!/usr/bin/env dotnet-script
#r "nuget: Lestaly, 0.73.0"
#r "nuget: Kokuban, 0.2.0"
#nullable enable
using System.Threading;
using Kokuban;
using Lestaly;
using Lestaly.Cx;

return await Paved.RunAsync(config: o => o.AnyPause(), action: async () =>
{
    WriteLine(Chalk.Green["Restart containers."]);
    var composeFile = ThisSource.RelativeFile("./compose.yml");
    await "docker".args("compose", "--file", composeFile.FullName, "down", "--remove-orphans", "--volumes");
    await "docker".args("compose", "--file", composeFile.FullName, "up", "-d", "--wait").result().success();

    WriteLine();
    WriteLine($" {Poster.Link["http://localhost:8186", "Mail WebUI  - http://localhost:8186"]}");
    WriteLine();
});
