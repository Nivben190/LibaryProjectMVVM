using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BookLibary.LibaryItemsClasses
{
 

    public class PropertyTamplate
    {
        public string Name { get; set; }
        public Type Kind { get; set; }
        public bool IsNullable { get; set; }
        public PropertyTamplate(string className, Type kind, bool IsNullable)
        {
            Name = className;
            Kind = kind;
            this.IsNullable = IsNullable;
        }
        public PropertyInstance CreateIntance(object value)
        {
            var propertyIntance = new PropertyInstance
            {
                PropertyTamplate = (PropertyTamplate)MemberwiseClone()
            };
            propertyIntance.SetValue(value);
            return propertyIntance;
        }
    }
}