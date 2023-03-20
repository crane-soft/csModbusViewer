using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;
using csModbusView;

// https://stackoverflow.com/questions/51611870/hide-some-properties-in-propertygrid-at-run-time

namespace csFormsDesign
{
    public class mbViewProperties : CustomTypeDescriptor
    {
        public static string[] PropertyList = {
            /* ModbusView */
            "Title", "BaseAddr", "NumItems", "ItemColumns", "ItemNames", "DataType",
            /* Layout */
            // "Anchor", not working so far, due to split panel 
            "AutoSize","Location", "Size"
        };

        private object WrappedObject;

        public mbViewProperties(object o)
            : base(TypeDescriptor.GetProvider(o).GetTypeDescriptor(o))
        {
            WrappedObject = o;

            if (typeof(ModbusView).IsAssignableFrom(WrappedObject.GetType())) {
                ModbusView mb = (ModbusView)WrappedObject;
                mb.setBrowsableProperties();
            }
        }
        public override PropertyDescriptorCollection GetProperties()
        {
            return this.GetProperties(new Attribute[] { });
        }

        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            var properties = base.GetProperties(attributes).Cast<PropertyDescriptor>()
                                 .Where(p => PropertyList.Contains(p.Name))
                                 .Select(p => TypeDescriptor.CreateProperty(
                                     WrappedObject.GetType(),
                                     p,
                                     p.Attributes.Cast<Attribute>().ToArray()))
                                 .ToArray();
            return new PropertyDescriptorCollection(properties);
        }
    }
}
