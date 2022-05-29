using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibary.LibaryManagmentClasses;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;


namespace BookLibary.LibaryItemsClasses
{  
    public class ClassInstance
    {
        public Customer RentedByCustomerRef { get; set; }
        public DateTime RentExipredDate { get; set; }
        public List<string> ListOfCategorys { get; set; }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ClassName { get; set; }

        public List<PropertyInstance> ListOfPropertyInstances;
        public ClassInstance()
        {
            RentedByCustomerRef = new Customer();
            ListOfCategorys = new List<string>();
            ListOfPropertyInstances = new List<PropertyInstance>();
        }
        public ClassInstance Filter(string  name, object value)
        {
            foreach (var item in ListOfPropertyInstances)
            {
                if(item.PropertyTamplate.Name==name&& item.Value.ToString() == value.ToString())
                {
                   return this;                 
                }
            }
            return default;
        }
        public string GetCategory(string category)
        {
            return  ListOfCategorys.FirstOrDefault(item => item == category);
        }
        public PropertyInstance this[string name]
        {
            get { return ListOfPropertyInstances.FirstOrDefault(item => item.PropertyTamplate.Name == name); }
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < 1; i++)
            {
                stringBuilder.Append($"{ListOfPropertyInstances[i].PropertyTamplate.Name} : {ListOfPropertyInstances[i].Value}");
            }     
            return $"{stringBuilder}";

        }
        public void AddProp(PropertyInstance propertyInstance)
        {
            ListOfPropertyInstances.Add(propertyInstance);
        }
        public void RemoveProp(PropertyInstance propertyInstance)
        {
            ListOfPropertyInstances.Remove(propertyInstance);
        }
        public void SaveClassWithJson(string className)
        {
            var myClass = JsonConvert.SerializeObject(this, Formatting.Indented,
                new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            File.WriteAllText($"//Mac/Home/Desktop/ObjectOriented/DimitryProject/DynamicClassFolder/{className}Instnace.json", myClass);
        }
        public static ClassInstance CreateInstance(string className, object[] props)
        {
            string json;
            using (var reader = new StreamReader($"//Mac/Home/Desktop/ObjectOriented/DimitryProject/DynamicClassFolder/{className}.json"))
            {
                json = reader.ReadToEnd();
            }
            var classInstance = JsonConvert.DeserializeObject<ClassInstance>(json);
            return classInstance;
        }
    }
}
