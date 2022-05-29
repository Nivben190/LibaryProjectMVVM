using Services;
using Services.ServicesExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFCustomMessageBox;

namespace DimitryProject.ForInterfaceClasses
{
    public class ForInterface : IMessagbleService
    {
        public ForInterface() { }
        private static ForInterface forInterfaceInstance = null;
        public static ForInterface ForInterfaceInstance
        {
            get
            {
                if (forInterfaceInstance == null)
                {
                    forInterfaceInstance = new ForInterface();
                }
                return forInterfaceInstance;
            }
        }
        public void DisplayError(string errorMessage)
        {
            MessageBox.Show(errorMessage);
        }
        public void DisplayWarning(string warningMessage)
        {
            MessageBox.Show(warningMessage);
        }     
    }
}
