using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using Newtonsoft.Json;
using System.IO;
using System.Reflection.Emit;
using GalaSoft.MvvmLight;
using MongoDB.Driver;
using DimitryProject.ForInterfaceClasses;
using BookLibary.LibaryItemsClasses;
using MongoDB.Bson.Serialization.Attributes;
using System.Net;
using System.Net.Http;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DimitryProject.LogicClass;
using DimitryProject.LoginClasses;

namespace DimitryProject.ViewModel
{
    [BsonKnownTypes(typeof(Type))]
    public class AddDynamicClassViewModel : ViewModelBase
    {
        #region Binding
        #region Public Binding
        public List<string> ListOfCategorys { get; set; } = new List<string>();
        public string CategoryNameToAdd { get => categoryNameToAdd; set => Set(ref categoryNameToAdd, value); }
        private ImageSource imagePath;
        public ImageSource ImagesPath { get => imagePath; set => Set(ref imagePath, new BitmapImage(new Uri($"//Mac/Home/Desktop/ObjectOriented/DimitryProject/DynamicClassFolder/DynamicImages/{ItemName}.jpg"))); }
        public string ClassName { get => className; set => Set(ref className, value); }
        public string NameOFProp { get => nameOFProp; set => Set(ref nameOFProp, value); }
        public bool IsNullable { get => isNullable; set { Set(ref isNullable, value); } }
        public string KindOFProp { get => kindOFProp; set { Set(ref kindOFProp, value); } }
        public string ItemName { get => itemName; set => Set(ref itemName, value); }
        public int ItemAmount { get => itemAmount; set => Set(ref itemAmount, value); }
        public int ItemPrice { get => itemPrice; set { Set(ref itemPrice, value); } }
        public object ItemValue { get => itemValue; set { Set(ref itemValue, value); } }
        public long ISBN { get => iSBN; set { Set(ref iSBN, value); } }
        public bool[] TypeOfBool { get => typeOfBool; set => typeOfBool = value; }
        public string[] TypeOFArray { get => typeOFArray; set => typeOFArray = value; }
        #endregion Public Binding

        #region Private Binding
        bool alreadyPressed;
        private object[] prop;
        private long iSBN;
        private object itemValue;
        private int itemAmount;
        private int itemPrice;
        private string className;
        private string itemName;
        private string nameOFProp;
        private string kindOFProp;
        private bool isNullable;
        private string[] typeOFArray = { "System.String", "System.Int32", "System.Int64", "System.DateTime", "System.Boolean" };
        private bool[] typeOfBool = { true, false };
        #endregion Private Binding

        #region Instance
        ClassTemplate ClassTemplateByUser;
        ReportsViewModel reportsViewModel;
        List<object> list = new List<object>();
        public List<ClassInstance> ListOfAllItems { get; set; } = new List<ClassInstance>();
        RegisterViewModel registerViewModel;
        private string categoryNameToAdd;


        #endregion Instance

        #endregion Binding

        #region consts
        private const string itemNameConst="Item Name";
        private const string itemPriceConst="Item Price";
        private const string itemISBNConst="Item ISBN";
        private const string itemAmountConst="Item Amount";
        private const string systemStringConst= "System.String";
        private const string systemInt32Const = "System.Int32";
       private const string systemInt64Const= "System.Int64";

        #endregion consts

        #region RelayCommands  
        public RelayCommand AddCategory { get; set; }
        public RelayCommand SaveItem { get; set; }
        public RelayCommand AddClassName { get; set; }
        public RelayCommand LoadWithJson { get; set; }
        public RelayCommand AddProp { get; set; }
        #endregion RelayCommands

        public AddDynamicClassViewModel(RegisterViewModel registerViewModel, ReportsViewModel reportsViewModel)
        {
            this.registerViewModel = registerViewModel;
            this.reportsViewModel = reportsViewModel;
            SaveItem = new RelayCommand(SaveItemFunc);
            AddCategory = new RelayCommand(AddToCategoryList);
            AddClassName = new RelayCommand(ClassTemplateByUserIntance);
            LoadWithJson = new RelayCommand(LoadWithJsonFunc);
            AddProp = new RelayCommand(AddPropFunc);
            ListOfAllItems = new List<ClassInstance>();
            MongoDBClass.ConvertDBToList(ListOfAllItems);
        }
        private void AddToCategoryList()
        {
            ListOfCategorys.Add(categoryNameToAdd);
            CategoryNameToAdd = "";
        }
        public void AddAbstractItemProps()
        {
            PropertyTamplate itemName = new PropertyTamplate(itemNameConst, Type.GetType(systemStringConst), false);
            ClassTemplateByUser.AddProp(itemName);
            PropertyTamplate ItemPrice = new PropertyTamplate(itemPriceConst, Type.GetType(systemInt32Const), false);
            ClassTemplateByUser.AddProp(ItemPrice);
            PropertyTamplate ItemISBN = new PropertyTamplate(itemISBNConst, Type.GetType(systemInt64Const), false);
            ClassTemplateByUser.AddProp(ItemISBN);
            PropertyTamplate ItemAmount = new PropertyTamplate(itemAmountConst, Type.GetType(systemInt32Const), false);
            ClassTemplateByUser.AddProp(ItemAmount);

        }
        private void ClassTemplateByUserIntance()
        {
            ClassTemplateByUser = new ClassTemplate(itemName);
            ClassTemplateByUser.ListOfCategorys = ListOfCategorys;
            AddAbstractItemProps();
            SetAbstractItemValues();
        }
        private void SetAbstractItemValues()
        {
            list.Add(itemName);
            list.Add(itemPrice);
            list.Add(iSBN);
            list.Add(itemAmount);
        }
        private void LoadWithJsonFunc()
        {
            ClassTemplateByUser = ClassTemplate.CreateInstance(itemName);
            object[] prop = ClassTemplateByUser.ListOfProperties.ToArray();
            ClassInstance classInstance = ClassTemplateByUser.LoadFromJson();
            foreach (var item in classInstance.ListOfPropertyInstances)
            {
                MessageBox.Show(item.Value.ToString());
            }
            PropertyInstance propertyInstance = classInstance[nameOFProp];
        }
        private void AddPropFunc()
        {
            if (!alreadyPressed) ClassTemplateByUserIntance();
            alreadyPressed = true;
            PropertyTamplate property = new PropertyTamplate($"{NameOFProp}", Type.GetType($"{KindOFProp}"), IsNullable);
            ClassTemplateByUser.AddProp(property);
            list.Add(itemValue);
            NameOFProp = "";
            itemValue = default;
            isNullable = false;
            KindOFProp = "";
        }
        private void SaveItemFunc()
        {
            ClassInstance classInstanceFound = HelperFuncService.GetItemByName(itemName,ListOfAllItems);
            if (classInstanceFound != default)
            {
                MessageService.Instance.DisplayMessageItemAlreadyAdded();
                return;
            }
            if (ExceptionsService.Instance.IsItemValide(ItemAmount, ItemName))
            {
                if (!alreadyPressed) ClassTemplateByUserIntance();
                ClassInstance classInstanceToAdd = CreateAndSaveItem();
                AddService.Instance.AddItemToList(classInstanceToAdd, ListOfAllItems);
                MessageService.Instance.DisplayItemWasAddedMessage(classInstanceToAdd);
                reportsViewModel.AddRows(classInstanceToAdd);
            }
            else
            {
                MessageService.Instance.DisplayItemIsNotValidMessage();
                return;
            }
            MessageBox.Show($"{itemName} was saved");
            ResetAllParemetrs();
            alreadyPressed = false;
        }

        #region HelpFunc
        private void ResetAllParemetrs()
        {
            NameOFProp = "";
            KindOFProp = "";
            itemName = "";
            itemPrice = 0;
            itemValue = String.Empty;
            isNullable = false;
            ISBN = 0;
        }
        private void CalculateDiscountForItems(ClassInstance classInstance)
        {
            int ToDown;
            if (classInstance.ListOfCategorys.Contains("Other"))
            {
                classInstance.SaveClassWithJson(itemName);
                return;
            }
            if (classInstance.ListOfCategorys.Contains("Drama"))
            {
                PropertyInstance itemPrice = HelperFuncService.GetItemPrice(classInstance,itemPriceConst);
                ToDown = Convert.ToInt32(itemPrice.Value) - Convert.ToInt32(itemPrice.Value) * 30 / 100;
                itemPrice.Value = ToDown;

                classInstance.SaveClassWithJson(itemName);

            }
            else if (classInstance.ListOfCategorys.Contains("Art") && !classInstance.ListOfCategorys.Contains("Drama"))
            {
                PropertyInstance itemPrice = HelperFuncService.GetItemPrice(classInstance, itemPriceConst);
                itemPrice.Value = Convert.ToInt32(itemPrice.Value) * 40 / 100;
                classInstance.SaveClassWithJson(itemName);

            }
            else if (classInstance.ListOfCategorys.Contains("Music") && !classInstance.ListOfCategorys.Contains("Arts") && !classInstance.ListOfCategorys.Contains("Drama"))

            {
                PropertyInstance itemPrice = HelperFuncService.GetItemPrice(classInstance, itemPriceConst);
                itemPrice.Value = Convert.ToInt32(itemPrice.Value) * 20 / 100;
                classInstance.SaveClassWithJson(itemName);

            }
            else
            {
                classInstance.SaveClassWithJson(itemName);
                return;
            }
        }
        private ClassInstance CreateAndSaveItem()
        {
            ClassTemplateByUser.SaveClassWithJson(itemName);
            ClassTemplateByUser = ClassTemplate.CreateInstance(itemName);
            prop = list.ToArray();
            ClassInstance classInstance = ClassTemplateByUser.CreateInstance(prop);
            CalculateDiscountForItems(classInstance);
            list.Clear();
            ListOfCategorys.Clear();
            alreadyPressed = false;
            return classInstance;
        }

        #endregion HelpFunc

    }
}
