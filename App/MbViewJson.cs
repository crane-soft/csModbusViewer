using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using csModbusView;
using Newtonsoft.Json;
using System.Drawing;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace csModbusViewer
{
    class MbViewJson
    {
        private string jsonFileName;
        public MbViewJson(string fileName)
        {
            jsonFileName = fileName;
        }

        public class ModbusViewContractResolver : DefaultContractResolver
        {
            private string[] propertyList = { "Name","Title", "BaseAddr", "NumItems", "ItemColumns", "ItemNames", "Location", "Size" };

            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                if (Array.IndexOf(propertyList, member.Name) >= 0) {
                    var property = base.CreateProperty(member, memberSerialization);
                    return property;
                }
                return null;
            }

        }

        public void Serialize(List<ModbusView> ModbusViewList)
        {
            var settings = new JsonSerializerSettings {
                ContractResolver = new ModbusViewContractResolver(),
                TypeNameHandling = TypeNameHandling.Auto
            };
            string jsonStr = JsonConvert.SerializeObject(ModbusViewList, Formatting.Indented, settings);
            System.IO.File.WriteAllText(jsonFileName, jsonStr);
          }

        public List<ModbusView> Deserialize()
        {
            string jsonStr = System.IO.File.ReadAllText(jsonFileName);

            var settings = new JsonSerializerSettings {
                TypeNameHandling = TypeNameHandling.Auto
            };
            List<ModbusView> outList = JsonConvert.DeserializeObject<List<ModbusView>>(jsonStr, settings);
            return outList;
        }
    }
}
