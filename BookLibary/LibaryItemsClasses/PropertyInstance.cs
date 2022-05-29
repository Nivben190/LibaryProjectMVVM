using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibary.LibaryItemsClasses
{   
    public class PropertyInstance
    {
        public PropertyTamplate PropertyTamplate { get; set; }
        public object Value { get; set; }
        public void SetValue(object value)
        {
            this.Value = value;
        }
    }
}
