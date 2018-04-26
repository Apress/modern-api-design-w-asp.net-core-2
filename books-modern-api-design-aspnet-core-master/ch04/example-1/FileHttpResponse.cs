using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeServer
{
    public class FileHttpResponse : HttpResponse
    {
        private readonly string path;
        public FileHttpResponse(HttpContext httpContext, string path)
        {
            this.HttpContext = httpContext;
            this.path = path;
        }
        public override HttpContext HttpContext { get; }
        public override int StatusCode { get; set; }
        public override IHeaderDictionary Headers => new HeaderDictionary();
        public override Stream Body { get; set; } = new MemoryStream();
        public override long? ContentLength { get; set; }
        public override string ContentType { get; set; }
        public override IResponseCookies Cookies => throw new NotImplementedException();
        public override bool HasStarted => true;

        public override void OnCompleted(Func<object, Task> callback, object state)
        {
            using (var reader = new StreamReader(Body))
            {
                Body.Position = 0;
                var text = reader.ReadToEnd();
                File.WriteAllText(path, $"{this.StatusCode} - {text}");
                Body.Flush();
                Body.Dispose();
            }
        }

        public override void OnStarting(Func<object, Task> callback, object state) { }
        public override void Redirect(string location, bool permanent) { }
    }


}
