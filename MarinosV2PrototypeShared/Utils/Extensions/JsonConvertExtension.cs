using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarinosV2PrototypeShared.BaseModels;
using Newtonsoft.Json;

namespace MarinosV2PrototypeShared.Utils.Extensions
{
    public static class JsonConvertExtension
    {
        public static string ToJson(this Entity? value) => JsonConvert.SerializeObject(value, new JsonSerializerSettings() { ContractResolver = new EntityContractResolver() });
    }
}
