using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Reflection;
using csModbusView;

namespace csFormsDesign
{
    // This is the one, which I'm using
    public class CustomObjectWrapper : CustomTypeDescriptor
    {
        public object WrappedObject { get; private set; }
        public List<string> BrowsableProperties { get; private set; }
        public CustomObjectWrapper(object o)
            : base(TypeDescriptor.GetProvider(o).GetTypeDescriptor(o))
        {
            WrappedObject = o;
            BrowsableProperties = new List<string>() {
                /* Apperance */
                "BorderStyle",
                /* ModbusView */
                "BaseAddr", "ItemColumns","ItemNames","NumItems","Title",
                /* Layout */
                "Anchor","Location","Padding","Size"
            };

        }
        public override PropertyDescriptorCollection GetProperties()
        {
            return this.GetProperties(new Attribute[] { });
        }

        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            var properties = base.GetProperties(attributes).Cast<PropertyDescriptor>()
                                 .Where(p => BrowsableProperties.Contains(p.Name))
                                 .Select(p => TypeDescriptor.CreateProperty(
                                     WrappedObject.GetType(),
                                     p,
                                     p.Attributes.Cast<Attribute>().ToArray()))
                                 .ToArray();
            return new PropertyDescriptorCollection(properties);
        }

        /* public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
         {
             PropertyDescriptorCollection properties = base.GetProperties(attributes);
             foreach (PropertyDescriptor prop in properties) {
                 if (BrowsableProperties.Contains (prop.Name) {

                 }
             }
             return properties;
         }*/
    }
    class csMbProperties
    {
        static Type ObjectType = typeof(ModbusView);

        public static void setBrowsableProperty(string strPropertyName, bool bIsBrowsable)
        {
            // Get the Descriptor's Properties
            PropertyDescriptor theDescriptor = TypeDescriptor.GetProperties(ObjectType)[strPropertyName];

            // Get the Descriptor's "Browsable" Attribute
            BrowsableAttribute theDescriptorBrowsableAttribute = (BrowsableAttribute)theDescriptor.Attributes[typeof(BrowsableAttribute)];
            FieldInfo isBrowsable = theDescriptorBrowsableAttribute.GetType().GetField("Browsable", BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Instance);

            // Set the Descriptor's "Browsable" Attribute
            isBrowsable.SetValue(theDescriptorBrowsableAttribute, bIsBrowsable);
        }

        public static void SetBrowsableAttributeOfAProperty(string propertyName, bool isBrowsable)
        {
            var objPropertyInfo = TypeDescriptor.GetProperties(ObjectType);

            PropertyDescriptor theDescriptor = objPropertyInfo[propertyName];

            if (theDescriptor == null)
                throw new Exception($"The property '{propertyName}' is not found in the Type '{ObjectType}'");

            SetBrowsableAttribut(theDescriptor, isBrowsable);
        }

        public static void RemovePropertyCategory(string category)
        {
            PropertyDescriptorCollection objPropertyInfo = TypeDescriptor.GetProperties(ObjectType);

            foreach (PropertyDescriptor prop in objPropertyInfo) {
                if (prop.Category == category) {
                    SetBrowsableAttribut(prop, false);
                }
            }

        }
        public static void SetBrowsableAttribut(PropertyDescriptor property, bool isBrowsable)
        {
            // Get the Descriptor's "Browsable" Attribute
            BrowsableAttribute theDescriptorBrowsableAttribute = (BrowsableAttribute)property.Attributes[typeof(BrowsableAttribute)];
            FieldInfo browsablility = theDescriptorBrowsableAttribute.GetType().GetField("Browsable", BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Instance);

            // Set the Descriptor's "Browsable" Attribute
            browsablility.SetValue(theDescriptorBrowsableAttribute, isBrowsable);
        }

        private static void SetBrowsableAttribut2(PropertyDescriptor prop, bool isBrowsable)
        {
            AttributeCollection runtimeAttributes = prop.Attributes;
            // make a copy of the original attributes 
            // but make room for one extra attribute
            Attribute[] attrs = new Attribute[runtimeAttributes.Count + 1];
            runtimeAttributes.CopyTo(attrs, 0);
            attrs[runtimeAttributes.Count] = new BrowsableAttribute(isBrowsable);
            /*
            prop = TypeDescriptor.CreateProperty(ObjectType,
                         propname, prop.PropertyType, attrs);
            properties[propname] = prop;
            */
        }
    }
}


