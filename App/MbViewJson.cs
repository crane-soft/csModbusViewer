using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using csModbusLib;
using csModbusView;
using Newtonsoft.Json;
using System.Drawing;
using Newtonsoft.Json.Serialization;
using System.Reflection;


namespace csModbusViewer
{
    public class MbViewProfile
    {
        public csModbusLib.DeviceType DeviceType { get; set; }
        public Size ViewSize { get; set; }
        public List<ModbusView> ModbusViewList { get; set; }
    }

    class MbViewJson
    {
        private string jsonFileName;
        public MbViewJson(string fileName)
        {
            jsonFileName = fileName;
        }

        public class ModbusViewContractResolver : DefaultContractResolver
        {
            private string[] propertyList = {
                "DeviceType","ViewSize","ModbusViewList",
                "Name","Title", "BaseAddr", "NumItems", "ItemColumns", "ItemNames", "Location", "Size" };

            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                if (Array.IndexOf(propertyList, member.Name) >= 0) {
                    var property = base.CreateProperty(member, memberSerialization);
                    return property;
                }
                return null;
            }

        }

        public void Serialize(MbViewProfile mbProfile)
        {
            var settings = new JsonSerializerSettings {
                ContractResolver = new ModbusViewContractResolver(),
                TypeNameHandling = TypeNameHandling.Auto,
                // Passende Property Decoration: [DefaultValue(30)]
                DefaultValueHandling = DefaultValueHandling.Ignore
            };

            string jsonStr = JsonConvert.SerializeObject(mbProfile, Formatting.Indented, settings);
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
