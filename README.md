# Oqtane Blog Module

Oqtane allows developers to create custom modules which are rendered by the framework dynamically at run-time.

Currently developers must use the following conventions when creating modules:

- the name of the module assembly must contain "*.Module.*" 
- the namespace of the optional Module.cs file ( which implements the IModule interface ) must match the module folder

A module should include a module.cs file which implements the IModule interface. This interface is used by the framework to load any metadata which is applicable to the module. See https://github.com/oqtane/oqtane.module.blogs/blob/master/Client/Module.cs 

In order to deploy a module

# Example Screenshot

Main summary view of Blog module:

![Blog Module](https://github.com/oqtane/oqtane.module.blogs/blob/master/screenshot1.png?raw=true "Blog Module")

Detailed view of individual blog:

![Blog Module](https://github.com/oqtane/oqtane.module.blogs/blob/master/screenshot2.png?raw=true "Blog Module")

Add new blog modal dialog:

![Blog Module](https://github.com/oqtane/oqtane.module.blogs/blob/master/screenshot3.png?raw=true "Blog Module")

Modify blog module settings:

![Blog Module](https://github.com/oqtane/oqtane.module.blogs/blob/master/screenshot4.png?raw=true "Blog Module")

