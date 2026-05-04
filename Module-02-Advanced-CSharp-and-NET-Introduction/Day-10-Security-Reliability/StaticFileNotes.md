# Static Files and the wwwroot Folder

In ASP.NET Core, we have a convention for serving static content (like HTML, CSS, and Images).

## The wwwroot Folder
The `wwwroot` folder is the default root directory for static files in a web project. Files placed here can be accessed directly by the browser if the pipeline is configured correctly.

## Enabling Static Files
By default, .NET does not serve static files for security reasons. We must explicitly enable this in our `Program.cs` file.

The simple command to do this is:
```csharp
app.UseStaticFiles();
```

### Why is this useful?
- It lets us serve a simple `index.html` file as our homepage.
- It allows the browser to download CSS stylesheets and JavaScript files.
- It keeps our "public" assets separate from our "private" C# code.

*Student Note: Always make sure your index.html is actually inside the wwwroot folder!*
