/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:DimitryProject"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using BookLibary;
using CommonServiceLocator;
using DimitryProject.ForInterfaceClasses;
using DimitryProject.LogicClass;
using DimitryProject.LoginClasses;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Services;
using Services.ServicesExtensions;

namespace DimitryProject.ViewModel
{
 
    public class ViewModelLocator
    {    
        public ViewModelLocator()
        {     
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);       
            SimpleIoc.Default.Register<RegisterViewModel>();
            SimpleIoc.Default.Register<ReportsViewModel>();
            SimpleIoc.Default.Register<ListViewViewMode>();
            SimpleIoc.Default.Register<AddDynamicClassViewModel>();
            SimpleIoc.Default.Register<AddDynamicClassViewModel>();
            SimpleIoc.Default.Register<VisibilityFuncs>();
            SimpleIoc.Default.Register<RegisterTextBoxViewModel>();
            SimpleIoc.Default.Register<ReturnItemViewModel>();
            SimpleIoc.Default.Register<LibaryManager>();
            SimpleIoc.Default.Register<RentItemViewModel>();
            SimpleIoc.Default.Register<DisplayItemsViewModel>();
            SimpleIoc.Default.Register<FilterService>();
            SimpleIoc.Default.Register<DisplayServices>();
            SimpleIoc.Default.Register<UpdateViewModel>();
            SimpleIoc.Default.Register<IMessagbleService,ForInterface>();
        }
        public DisplayServices DisplayServices => ServiceLocator.Current.GetInstance<DisplayServices>();
        public FilterService FilterService => ServiceLocator.Current.GetInstance<FilterService>();
        public UpdateViewModel UpdateViewModel => ServiceLocator.Current.GetInstance<UpdateViewModel>();
        public DisplayItemsViewModel DisplayItemsViewModel => ServiceLocator.Current.GetInstance<DisplayItemsViewModel>();
        public RentItemViewModel RentItemViewModel => ServiceLocator.Current.GetInstance<RentItemViewModel>();
        public ReturnItemViewModel ReturnItemViewModel => ServiceLocator.Current.GetInstance<ReturnItemViewModel>();
        public RegisterTextBoxViewModel RegisterTextBoxViewModel => ServiceLocator.Current.GetInstance<RegisterTextBoxViewModel>();
        public VisibilityFuncs VisibilityFuncs => ServiceLocator.Current.GetInstance<VisibilityFuncs>();
        public AddDynamicClassViewModel AddDynamicClassView => ServiceLocator.Current.GetInstance<AddDynamicClassViewModel>();
        public AddDynamicClassViewModel AddDynamicClass => ServiceLocator.Current.GetInstance<AddDynamicClassViewModel>();
        public ListViewViewMode ListViewViewModel => ServiceLocator.Current.GetInstance<ListViewViewMode>();
        public RegisterViewModel RegisterViewModelInstance => ServiceLocator.Current.GetInstance<RegisterViewModel>();
        public ReportsViewModel ReportsViewModel => ServiceLocator.Current.GetInstance<ReportsViewModel>();

        public static void Cleanup()
        {
        }
    }
}