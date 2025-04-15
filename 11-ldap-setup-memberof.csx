#!/usr/bin/env dotnet-script
#r "nuget: Lestaly, 0.73.0"
#nullable enable
using Lestaly;
using Lestaly.Cx;

return await Paved.RunAsync(config: c => c.AnyPause(), action: async () =>
{
    var composeFile = ThisSource.RelativeFile("./compose.yml");
    await "docker".args(
        "compose", "--file", composeFile.FullName, "exec", "ldap",
        "ldapadd", "-Q", "-Y", "EXTERNAL", "-H", "ldapi:///", "-f", "/ldifs/memberof.ldif"
    );
});
