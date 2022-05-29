using DimitryProject.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimitryProject.DynamicClassFolder
{
    //public class ClassInstance
    //{
    //      public string ClassName { get; set; }
    //      public  List<PropertyInstance> ListOfPropertyInstances;
    //    public ClassInstance()
    //    {
    //        ListOfPropertyInstances = new List<PropertyInstance>();
    //    }
    //    public PropertyInstance this[string name]
    //    {
    //        get { return ListOfPropertyInstances.FirstOrDefault(item => item.PropertyTamplate.Name == name); }
    //    }
    //    public override string ToString()
    //    {
    //        StringBuilder stringBuilder = new StringBuilder();
    //        foreach (var item in ListOfPropertyInstances)
    //        {
    //            stringBuilder.Append($"{item.PropertyTamplate.Name} , {item.value}");
    //        }
    //       return $"Name:{ClassName}, {stringBuilder}";

    //    }
    //    public void AddProp(PropertyInstance propertyInstance)
    //    {
    //        ListOfPropertyInstances.Add(propertyInstance);
    //    }
    //    public void RemoveProp(PropertyInstance propertyInstance)
    //    {
    //        ListOfPropertyInstances.Remove(propertyInstance);
    //    }
    //    public void SaveClassWithJson(string className)
    //    {
    //        var myClass = JsonConvert.SerializeObject(this, Formatting.Indented);
    //        File.WriteAllText($"//Mac/Home/Desktop/ObjectOriented/DimitryProject/DynamicClassFolder/{className}Instnace.json", myClass);
    //    }        
    //    public  static ClassInstance CreateInstance(string className, object[] props)
    //    {
    //        string json;
    //        using (var reader = new StreamReader($"//Mac/Home/Desktop/ObjectOriented/DimitryProject/DynamicClassFolder/{className}.json"))
    //        {
    //            json = reader.ReadToEnd();
    //        }
    //        var classInstance = JsonConvert.DeserializeObject<ClassInstance>(json);
    //        return classInstance;
    //    }
    //}
}
