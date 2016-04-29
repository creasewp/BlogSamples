using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.OData.Query;

namespace MobileService1
{
    public class CustomSelectExpandWrapperConverter : JsonConverter
    {
        private readonly IPropertyMapper propertyMapper = null;

        public CustomSelectExpandWrapperConverter()
        {
            IDictionary<string, string> map = new Dictionary<string, string>();
            map.Add("Deleted", "__deleted");
            map.Add("Version", "__version");
            map.Add("UpdatedAt", "__updatedAt");
            map.Add("CreatedAt", "__createdAt");
            this.propertyMapper = new CustomPropertyMapper(map);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType != null && typeof(ISelectExpandWrapper).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }

            ISelectExpandWrapper wrapper = value as ISelectExpandWrapper;
            if (wrapper != null)
            {
                var convertedValue = wrapper.ToDictionary((model, type) => this.propertyMapper);
                if ((bool)convertedValue["__deleted"])
                {
                    var keysToRemove = convertedValue.Where(item => (item.Key != "__deleted") && (item.Key != "Id")).Select(item => item.Key).ToList();
                    foreach (string key in keysToRemove)
                    {
				        convertedValue.Remove(key);
                    }
                }
                serializer.Serialize(writer, convertedValue);
            }
        }
    }
}