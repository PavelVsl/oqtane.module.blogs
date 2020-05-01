"..\..\oqtane.framework\oqtane.package\nuget.exe" pack Oqtane.Module.Blogs.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Modules\" /Y
