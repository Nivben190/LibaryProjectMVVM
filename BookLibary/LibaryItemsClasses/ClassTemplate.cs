using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibary.LibaryItemsClasses
{ 
    public class ClassTemplate
    {
        public List<string> ListOfCategorys { get; set; }
        public string ClassName { get; set; }
        public List<PropertyTamplate> ListOfProperties { get; set; }
        public ClassTemplate(string ClassName)
        {
            ListOfProperties = new List<PropertyTamplate>();
            ListOfCategorys = new List<string>();
            this.ClassName = ClassName;
        }
        public void AddMyCategorys(string category)
        {
            ListOfCategorys.Add(category);
        }    
        public PropertyTamplate this[string name]
        {
            get { return ListOfProperties.FirstOrDefault(item => item.Name == name); }
        }
        public void AddProp(PropertyTamplate propertyTamplate)
        {
            ListOfProperties.Add(propertyTamplate);
        }
        public void RemoveProp(PropertyTamplate propertyTamplate)
        {
            ListOfProperties.Remove(propertyTamplate);
        }
        public static ClassTemplate CreateInstance(string className)
        {
            string json;
            try
            {
                using (var reader = new StreamReader($"//Mac/Home/Desktop/ObjectOriented/DimitryProject/DynamicClassTemplate/{className}.json"))
                {
                    json = reader.ReadToEnd();
                }
            }
            catch (Exception)
            {
                throw new Exception("The Item Could not be found");
            }

            var classInstance = JsonConvert.DeserializeObject<ClassTemplate>(json);
            return classInstance;
        }
        private PropertyInstance[] SetValueToProp(object[] props)
        {
            PropertyInstance[] listOfPropIntance = new PropertyInstance[props.Length];
            for (int i = 0; i < listOfPropIntance.Length; i++)
            {
                listOfPropIntance[i] = ListOfProperties[i].CreateIntance(props[i]);
            }
            return listOfPropIntance;
        }
        public ClassInstance CreateInstance(object[] props)
        {
            string json;
            try
            {
                using (var reader = new StreamReader($"//Mac/Home/Desktop/ObjectOriented/DimitryProject/DynamicClassTemplate/{ClassName}.json"))
                {
                    json = reader.ReadToEnd();
                }
            }
            catch (Exception)
            {
                throw new Exception("The Item Could not be found");
            }
            var classInstance = JsonConvert.DeserializeObject<ClassInstance>(json);
            classInstance.ListOfPropertyInstances = SetValueToProp(props).ToList();
            classInstance.ListOfCategorys = ListOfCategorys ;
            return classInstance;
        }
        public ClassInstance LoadFromJson()
        {
            string json;
            try
            {
                using (var reader = new StreamReader($"//Mac/Home/Desktop/ObjectOriented/DimitryProject/DynamicClassFolder/{ClassName}Instnace.json"))
                {
                    json = reader.ReadToEnd();
                }
            }
            catch (Exception)
            {
                throw new Exception("The Item Could not be found");
            }
            var classInstance = JsonConvert.DeserializeObject<ClassInstance>(json);
            return classInstance;
        }
        public void SaveClassWithJson(string className)
        {
            var myClass = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText($"//Mac/Home/Desktop/ObjectOriented/DimitryProject/DynamicClassTemplate/{className}.json", myClass);
        }
    }
}
