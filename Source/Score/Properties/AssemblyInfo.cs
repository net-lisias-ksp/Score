using System.Reflection;
using System.Runtime.CompilerServices;

// Information about this assembly is defined by the following attributes. 
// Change them to the values specific to your project.

[assembly: AssemblyTitle("Score!")]
[assembly: AssemblyDescription("A Utility for automating computing Scores for Challenges.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("L Aerospace KSP Division")]
[assembly: AssemblyProduct("Scare!")]
[assembly: AssemblyCopyright("©2020 Lisias")]
[assembly: AssemblyTrademark("Score!")]
[assembly: AssemblyCulture("")]

// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
// The form "{Major}.{Minor}.*" will automatically update the build and revision,
// and "{Major}.{Minor}.{Build}.*" will update just the revision.

[assembly: AssemblyVersion(Score.Version.Number)]
[assembly: AssemblyFileVersion(Score.Version.Number)]
[assembly: KSPAssembly("Score!", Score.Version.major, Score.Version.minor)]
[assembly: KSPAssemblyDependency("KSPe", 2, 1)]
[assembly: KSPAssemblyDependency("KSPe.UI", 2, 1)]
[assembly: KSPAssemblyDependency("ToolbarController", 1, 0)]
// The following attributes are used to specify the signing key for the assembly, 
// if desired. See the Mono documentation for more information about signing.

//[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile("")]
