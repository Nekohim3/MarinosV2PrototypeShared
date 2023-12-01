using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MarinosV2PrototypeShared.Utils.Extensions
{
    public static class ListExtension
    {
        public static ICollection GetListCopy(this ICollection list)
        {
            var s = JsonConvert.SerializeObject(list);
            var d = JsonConvert.DeserializeObject(s) as ICollection;
            return d;
        }
    }
}
