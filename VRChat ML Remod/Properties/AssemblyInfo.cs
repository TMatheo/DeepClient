using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle(BuildInfo.Description)]
[assembly: AssemblyDescription(BuildInfo.Description)]
[assembly: AssemblyCompany(BuildInfo.Company)]
[assembly: AssemblyProduct(BuildInfo.Name)]
[assembly: AssemblyCopyright("Skibided by " +BuildInfo.Author)]
[assembly: AssemblyTrademark(BuildInfo.Company)]
[assembly: AssemblyVersion(BuildInfo.Version)]
[assembly: AssemblyFileVersion(BuildInfo.Version)]
[assembly: MelonInfo(typeof(DeepCore.Entry), BuildInfo.Name, BuildInfo.Version, BuildInfo.Author, BuildInfo.DownloadLink)]
[assembly: MelonColor()]
[assembly: MelonGame(null, null)]
public static class BuildInfo
{
    public const string Name = "DeepClient";
    public const string Description = "Man this guy amanishe.";
    public const string Author = "-> ERROR <-";
    public const string Company = null;
    public const string Version = "1.0";
    public const string DownloadLink = null;
}