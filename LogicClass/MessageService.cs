using BookLibary.LibaryItemsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DimitryProject.LogicClass
{
    public class MessageService
    {
        private MessageService() { }
        private static MessageService instance = null;
        public static MessageService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MessageService();
                }
                return instance;
            }
        }
        public void DisplayMessageItemAlreadyAdded() => MessageBox.Show("The Book Already Added, you can update the amount if you want");
        public void DisplayItemIsNotValidMessage() => throw new Exception("Item Is not valid pls enter valid info");
        public void DisplayItemWasAddedMessage(ClassInstance ClassInstanceAdded) => MessageBox.Show($"{ClassInstanceAdded.ClassName} was added");

    }
}
