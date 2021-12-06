using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public class FluentUrlBuilder
    {
        private string Url { get; set; }

        public FluentUrlBuilder BaseUrl(string url)
        {
            Url = url;
            return this;
        }

        public FluentUrlBuilder AppendQueryParam(string queyKey, string queryValue)
        {
            Url = QueryHelpers.AddQueryString(Url, queyKey, queryValue);
            return this;
        }

        public FluentUrlBuilder AppendUrlSection(string urlSection)
        {
            Url += $"/{urlSection}";
            return this;
        }

        public string GetUrl()
            => this.Url;
    }
}
