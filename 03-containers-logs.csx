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
    var composeFile = ThisSource.RelativeFile("./compose.yml");
    await "docker".args("compose", "--file", composeFile.FullName, "logs", "-f").interactive().result().success();
});
