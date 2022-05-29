using BookLibary;
using BookLibary.LibaryItemsClasses;
using DimitryProject.ViewModel;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace DimitryProject.LogicClass
{
    public class ImageLogic:ViewModelBase
    {
        private ImageLogic() { }
        private static ImageLogic instance = null;
        public static ImageLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ImageLogic();
                }
                return instance;
            }
        }
        public bool IsFileExist(string name)
        {
            string fileName = $"//Mac/Home/Desktop/ObjectOriented/DimitryProject/DynamicClassFolder/DynamicImages/{name}.jpg";
            if (!File.Exists(fileName))
            {
                MessageBox.Show("item dont have Picture");
                return false;
            }
            else return true;
        }
    }
}
