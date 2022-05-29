using BookLibary;
using BookLibary.LibaryItemsClasses;
using DimitryProject.DynamicClassFolder;
using DimitryProject.LogicClass;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DimitryProject.ViewModel
{
    public class ListViewViewMode : ViewModelBase
    {
        private ImageSource imagePath;
        private ClassInstance selectemItem;
        public ImageSource ImagesPath
        {
            get => imagePath;

            set
            {
                if(SelectemItem!=null)
                {
                    if (ImageLogic.Instance.IsFileExist($"{SelectemItem.ClassName}"))
                    {
                        Set(ref imagePath, new BitmapImage(new Uri($"//Mac/Home/Desktop/ObjectOriented/DimitryProject/DynamicClassFolder/DynamicImages/{SelectemItem.ClassName}.jpg")));
                    }
                    else Set(ref imagePath, null);
                }               
                else Set(ref imagePath, null);

            }
        }
        readonly RentItemViewModel rentItemViewModel;
        public ClassInstance SelectemItem
        {
            get => selectemItem;
            set
            {
                Set(ref selectemItem, value);
                ListOfRentedItems.Add(value);
                rentItemViewModel.AddRentBook(value);
                ImagesPath = null;

            }
        }
        public ObservableCollection<ClassInstance> ListOfAllItemInLibary { get; set; }
        public ObservableCollection<ClassInstance> ListOfRentedItems { get; set; }
        public ListViewViewMode(RentItemViewModel rentItemViewModel)
        {
            this.rentItemViewModel = rentItemViewModel;
            ListOfAllItemInLibary = new ObservableCollection<ClassInstance>();
            ListOfRentedItems = new ObservableCollection<ClassInstance>();
        }
        void ClearLists()
        {
            ListOfAllItemInLibary.Clear();
            ListOfRentedItems.Clear();
        }
    }
}
