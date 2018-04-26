using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;

namespace CustomFormatter
{
    public class CsvOutputFormatter : OutputFormatter
    {
        private const string delimiter = ",";
        private const string contentType = "text/csv";
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
        }
        protected override bool CanWriteType(Type type) => type.GetInterfaces().Contains(typeof(System.Collections.IEnumerable));
        public async override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            var type = context.Object.GetType();
            Type itemType;
            if (type.GetGenericArguments().Length > 0)
            {
                itemType = type.GetGenericArguments()[0];
            }
            else
            {
                itemType = type.GetElementType();
            }
            var stringWriter = new StringWriter();
            var header = string.Join(",", itemType.GetProperties().Select(x => x.Name));
            stringWriter.WriteLine(header);
            foreach (var item in (IEnumerable<object>)context.Object)
            {
                var values = item.GetType().GetProperties().Select(pi => new
                {
                    Value = pi.GetValue(item, null)
                });
                var valueLine = string.Empty;
                foreach (var val in values)
                {
                    if (val.Value != null)
                    {
                        valueLine = string.Concat(valueLine, val.Value.
                       ToString(), delimiter);
                    }
                    else
                    {
                        valueLine = string.Concat(valueLine, string.Empty,
                       delimiter);
                    }
                }
                stringWriter.WriteLine(valueLine);
            }

            var streamWriter = new StreamWriter(context.HttpContext.Response.Body);
            await streamWriter.WriteAsync(stringWriter.ToString());
            await streamWriter.FlushAsync();
        }
    }
}
