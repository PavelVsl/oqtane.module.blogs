# Oqtane Sample Module

Oqtane allows developers to create external modules which are rendered by the framework dynamically at run-time.

Currently developers must use the following conventions when creating modules:

- the name of the module folder must be prefixed with "Oqtane.Module." ( this is required because Blazor generates component namespaces based on folder structure )
- the name of the project file must match the name of module folder
- the namespace of the optional Module.cs file ( which implements the IModule interface ) must match the module folder

The module *.csproj file contains PostBuild events. The XCOPY commands need to be updated so that they copy the module DLL to the appropriate folder locations for your Oqtane installation:

  \<Target Name="PostBuild" AfterTargets="PostBuildEvent">
    \<Exec Command="XCOPY &quot;$(TargetDir)Oqtane.Module.Sample.dll&quot; &quot;**{Your Specific Path Here}**\Oqtane.Server\bin\Debug\netcoreapp3.0\&quot; /S /Y&#xD;&#xA;XCOPY &quot;$(TargetDir)Oqtane.Module.Sample.dll&quot; &quot;**{Your Specific Path Here}**\Oqtane.Client\bin\Debug\netstandard2.0\dist\_framework\_bin\&quot; /S /Y" />
  \</Target>

A module can optionally choose to include a module.cs file which implements the IModule interface. This interface is used by the framework to load any metadata which is applicable to the module.

    public class Module : IModule
    {
        public string Name { get { return "Sample Module"; } }
        public string Description { get { return "Sample Module"; } }
        public string Version { get { return "0.0.1"; } }
        public string Owner { get { return ""; } }
        public string Url { get { return ""; } }
        public string Contact { get { return ""; } }
        public string License { get { return ""; } }
        public string Dependencies { get { return ""; } }
    }
