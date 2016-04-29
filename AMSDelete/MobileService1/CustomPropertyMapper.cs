using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.OData.Query;

namespace MobileService1
{
    public class CustomPropertyMapper : IPropertyMapper
    {
        private readonly IDictionary<string, string> map;

        public CustomPropertyMapper(IDictionary<string, string> map)
        {
            if (map == null)
            {
                throw new ArgumentNullException("map");
            }
            this.map = map;
        }

        /// <inheritdoc />
        public string MapProperty(string propertyName)
        {
            string value;
            if (this.map.TryGetValue(propertyName, out value))
            {
                return value;
            }
            return propertyName;
        }
    }
}