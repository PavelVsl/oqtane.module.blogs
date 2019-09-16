# Oqtane Blog Module

Oqtane allows developers to create third party modules which are rendered by the framework dynamically at run-time.

Currently developers must use the following conventions when creating modules:

- the name of the module assembly must contain "*.Module.*" 
- the namespace of the optional Module.cs file ( which implements the IModule interface ) must match the module folder

The various module *.csproj files contain PostBuild events. The XCOPY commands for these events need to be updated so that they copy the DLLs to the appropriate folder locations for your Oqtane installation:

  \<Target Name="PostBuild" AfterTargets="PostBuildEvent">
    \<Exec Command="XCOPY &quot;$(TargetDir)Oqtane.Module.Blogs.Client.dll&quot; &quot;**{Your Oqtane Framework Specific Path Here}**\Oqtane.Server\bin\Debug\netcoreapp3.0\&quot; /S /Y&#xD;&#xA;XCOPY &quot;$(TargetDir)Oqtane.Module.Blogs.Client.dll&quot; &quot;**{Your Oqtane Framework Specific Path Here}**\Oqtane.Client\bin\Debug\netstandard2.0\dist\_framework\_bin\&quot; /S /Y" />
  \</Target>

A module shuld include a module.cs file which implements the IModule interface. This interface is used by the framework to load any metadata which is applicable to the module.

   public class Module : IModule
   {
        public Dictionary<string, string> Properties
        {
            get
            {
                Dictionary<string, string> properties = new Dictionary<string, string>
                {
                    { "Name", "Blog" },
                    { "Description", "Blog Module" },
                    { "Version", "0.0.1" },
                    { "Owner", ".NET Foundation" },
                    { "Url", "http://www.oqtane.org" },
                    { "Contact", "support@oqtane.org" },
                    { "License", "Copyright (c) 2019 .NET Foundation." },
                    { "Dependencies", "Oqtane.Module.Blogs.Shared" },
                    { "Permissions", "View,Edit" } // optional
                };
                return properties;
            }
        }
    }


# Example Screenshot

Main summary view of Blog module:

![Blog Module](https://github.com/oqtane/oqtane.module.blogs/blob/master/screenshot1.png?raw=true "Blog Module")

Detailed view of individual blog:

![Blog Module](https://github.com/oqtane/oqtane.module.blogs/blob/master/screenshot2.png?raw=true "Blog Module")

Add new blog modal dialog:

![Blog Module](https://github.com/oqtane/oqtane.module.blogs/blob/master/screenshot3.png?raw=true "Blog Module")

Modify blog module settings:

![Blog Module](https://github.com/oqtane/oqtane.module.blogs/blob/master/screenshot4.png?raw=true "Blog Module")

