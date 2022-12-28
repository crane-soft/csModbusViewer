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
using Newtonsoft.Json.Linq;

namespace csModbusViewer
{
    public class MbViewProfile
    {
        public string DeviceType { get; set; }
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
            private string[] generalProperties = {
                "DeviceType","ViewSize","ModbusViewList" };

            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                if (Array.IndexOf(csFormsDesign.mbViewProperties.PropertyList, member.Name) >= 0) {
                    var property = base.CreateProperty(member, memberSerialization);
                    if (property.PropertyName == "Name") {
                        property.ShouldSerialize =
                            instance => {
                                ModbusView mv = (ModbusView)instance;
                                return mv.Name.Length > 0;
                            };
                    }
                    return property;
                }


                if (Array.IndexOf(generalProperties, member.Name) >= 0) {
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
            if (mbProfile.DeviceType == csModbusLib.DeviceType.MASTER.ToString()) {
                jsonStr = jsonStr.Replace("csModbusView.Master", "csModbusView.");
            } else if (mbProfile.DeviceType == csModbusLib.DeviceType.SLAVE.ToString()) {
                jsonStr = jsonStr.Replace("csModbusView.Slave", "csModbusView.");
            } else {
                throw new Exception("unknown Devicetype ");
            }
            System.IO.File.WriteAllText(jsonFileName, jsonStr);
          }

        public MbViewProfile Deserialize()
        {
            string jsonStr = System.IO.File.ReadAllText(jsonFileName);

            var jObject = JObject.Parse(jsonStr);
            var jToken = jObject.GetValue("DeviceType");

            if (jToken.Value<string>() == csModbusLib.DeviceType.MASTER.ToString()) {
                jsonStr = jsonStr.Replace("csModbusView.", "csModbusView.Master");
            } else if (jToken.Value<string>() == csModbusLib.DeviceType.SLAVE.ToString()) {
                jsonStr = jsonStr.Replace("csModbusView.", "csModbusView.Slave");
            } else {
                throw new Exception("unknown Devicetype ");
            }

            var settings = new JsonSerializerSettings {
                TypeNameHandling = TypeNameHandling.Auto
            };

            MbViewProfile mbProfile = JsonConvert.DeserializeObject<MbViewProfile>(jsonStr, settings);
            return mbProfile;
        }
    }
}
