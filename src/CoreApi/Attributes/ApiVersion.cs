using System;
using System.Collections.Generic;

namespace src
{
    public class ApiVersionAttribute : Attribute
    {
        public List<string> Versions { get; set; } = new List<string>();

        public ApiVersionAttribute(params string[] versions)
        {
            Versions.AddRange(versions);
        }
    }
}