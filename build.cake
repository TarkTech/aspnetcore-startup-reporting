var nugetApiKey = EnvironmentVariable<string>("NUGET_KEY", "");
var nugetSource = EnvironmentVariable<string>("NUGET_SOURCE", "https://api.nuget.org/v3/index.json");
var buildNumber = EnvironmentVariable<string>("BUILD_NUMBER", "0");
var target = Argument("target", "PublishPackage");

var solution = "Tark.AspNetCore.StartupReporting.sln";
var package = "Tark.AspNetCore.StartupReporting/Tark.AspNetCore.StartupReporting.csproj";

var configuration = "Release";
var outputDir = "./artifacts";
var version = $"1.0.0.{buildNumber}";

Task("Clean")
    .Does(() => {
        CleanDirectory(outputDir);
        DotNetCoreClean(solution);
    });
    
Task("Build")
    .IsDependentOn("Clean")
    .Does(() => {
        var msBuildSettings = new DotNetCoreMSBuildSettings();
        msBuildSettings.SetVersion(version);
        
        DotNetCoreBuild(solution, new DotNetCoreBuildSettings
        {
            Configuration = configuration,
            OutputDirectory = outputDir,
            MSBuildSettings = msBuildSettings
        });
    });
    
Task("PublishPackage")
    .IsDependentOn("Build")
    .Does(() => {                     
        DotNetCoreNuGetPush($"{outputDir}/*.nupkg", new DotNetCoreNuGetPushSettings
                                                  {
                                                      ApiKey = nugetApiKey,
                                                      Source = nugetSource
                                                  });
    });

RunTarget(target);
