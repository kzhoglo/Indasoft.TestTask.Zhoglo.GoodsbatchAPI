using System.Reflection;
using Indasoft.TestTask.Zhoglo.GoodsbatchAPI.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Indasoft.TestTask.Zhoglo.GoodsbatchAPI.Models
{
    public class PatchRequestContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var prop = base.CreateProperty(member, memberSerialization);

            prop.SetIsSpecified += (o, o1) =>
            {
                if (o is PatchGoodsBatch patchDtoBase)
                {
                    patchDtoBase.SetHasProperty(prop.PropertyName);
                }
            };

            return prop;
        }
    }
}
