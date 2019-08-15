# Oqtane Blog Module

Oqtane allows developers to create third party modules which are rendered by the framework dynamically at run-time.

Currently developers must use the following conventions when creating modules:

- the name of the module folder must contain "*.Module.*" ( this is required because Blazor generates component namespaces based on folder structure )
- the name of the project file must match the name of module folder
- the namespace of the optional Module.cs file ( which implements the IModule interface ) must match the module folder

The various module *.csproj files contain PostBuild events. The XCOPY commands for these events need to be updated so that they copy the DLLs to the appropriate folder locations for your Oqtane installation:

  \<Target Name="PostBuild" AfterTargets="PostBuildEvent">
    \<Exec Command="XCOPY &quot;$(TargetDir)Oqtane.Module.Blogs.Client.dll&quot; &quot;**{Your Oqtane Framework Specific Path Here}**\Oqtane.Server\bin\Debug\netcoreapp3.0\&quot; /S /Y&#xD;&#xA;XCOPY &quot;$(TargetDir)Oqtane.Module.Blogs.Client.dll&quot; &quot;**{Your Oqtane Framework Specific Path Here}**\Oqtane.Client\bin\Debug\netstandard2.0\dist\_framework\_bin\&quot; /S /Y" />
  \</Target>

A module shuld include a module.cs file which implements the IModule interface. This interface is used by the framework to load any metadata which is applicable to the module.

    public class Module : IModule
    {
        public string Name { get { return "Blog Module"; } }
        public string Description { get { return "Blog Module"; } }
        public string Version { get { return "0.0.1"; } }
        public string Owner { get { return ""; } }
        public string Url { get { return ""; } }
        public string Contact { get { return ""; } }
        public string License { get { return ""; } }
        public string Dependencies { get { return ""; } }
    }

# Example Screenshot

Various user interface examples from the Blog module:

![Blog Module](https://github.com/oqtane/oqtane.module.blogs/blob/master/screenshot1.png?raw=true "Blog Module")
