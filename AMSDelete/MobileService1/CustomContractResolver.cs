using Microsoft.WindowsAzure.Mobile.Service.Serialization;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http.OData.Query;

namespace MobileService1
{
    public class CustomContractResolver : TableContractResolver
    {
        public CustomContractResolver(MediaTypeFormatter formatter)
            : base(formatter)
        {
        }

        protected override JsonContract CreateContract(Type objectType)
        {
            JsonContract contract = base.CreateContract(objectType);

            if (typeof(ISelectExpandWrapper).IsAssignableFrom(objectType))
            {
                contract.Converter = new CustomSelectExpandWrapperConverter();
            }

            return contract;
        }
    }
}