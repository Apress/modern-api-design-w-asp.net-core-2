using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeServer
{
    public class AwesomeFolderWatcher<TContext>
{
    private readonly FileSystemWatcher watcher;
    private readonly IHttpApplication<TContext> application;
    private readonly IFeatureCollection features;
    public AwesomeFolderWatcher(IHttpApplication<TContext> application, IFeatureCollection features)
    {
        var path = features.Get<IServerAddressesFeature>().Addresses.FirstOrDefault();
        this.watcher = new FileSystemWatcher(path);
        this.watcher.EnableRaisingEvents = true;
        this.application = application;
        this.features = features;
    }
    public void Watch()
    {
        watcher.Created += async (sender, e) =>
        {
            var context = (HostingApplication.Context)(object)application.CreateContext(features);
            context.HttpContext = new AwesomeHttpContext(features, e.FullPath);
            await application.ProcessRequestAsync((TContext)(object)context);
            context.HttpContext.Response.OnCompleted(null, null);
        };

        Task.Run(() => watcher.WaitForChanged(WatcherChangeTypes.All));
    }
}

}
