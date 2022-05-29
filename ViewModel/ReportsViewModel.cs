using BookLibary;
using BookLibary.LibaryItemsClasses;
using CommunityToolkit.Mvvm.Input;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DimitryProject.ViewModel
{
    public class ReportsViewModel : ViewModelBase
    {
        public string FilterText { get; set; }

        #region RelayCommand
        public RelayCommand NewReportsCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand FilterCommand { get; set; }
        public RelayCommand ShowAllItemsCommand { get; set; }
        #endregion RelayCommand

        #region DataTable
        DataTable dataTable = new DataTable();
        DataTable CopydataTable = new DataTable();
        public DataTable DataTableCollection { get; set; }
        #endregion DataTable

        public ReportsViewModel()
        {
            DataTableCollection = GetDataTable();
            SaveCommand = new RelayCommand(Save);
            NewReportsCommand = new RelayCommand(NewReportsFunc);
            FilterCommand = new RelayCommand(FilterReportsFunc);
            ShowAllItemsCommand = new RelayCommand(ShowAllItems);
        }

        #region Funcs
        public void ConvertToDataTable(string filePath)
        {
            dataTable.Clear();
            string[] lines = System.IO.File.ReadAllLines(filePath);
            string[] value;
            for (int i = 1; i < lines.Length; i++)
            {
                value = lines[i].Split(',');
                string[] row = new string[value.Length];
                for (int j = 1; j < value.Length; j++)
                {
                    row[j] = value[j];
                }
                dataTable.Rows.Add(row);
            }
        }
        public void AddRows(ClassInstance ClassInstanceToAdd)
        {
            dataTable.Rows.Add("Added to libary", $"{ClassInstanceToAdd.ClassName}", $"{ClassInstanceToAdd["Item Price"].Value}", $"{ClassInstanceToAdd["Item ISBN"].Value}", DateTime.Now);
            CopydataTable.Rows.Add("Added to libary", $"{ClassInstanceToAdd.ClassName}", $"{ClassInstanceToAdd["Item Price"].Value}", $"{ClassInstanceToAdd["Item ISBN"].Value}", DateTime.Now);
        }
        public void AddRowsRented(ClassInstance ClassInstanceToAdd)
        {
            dataTable.Rows.Add("Rented From libary", $"{ClassInstanceToAdd.ClassName}", $"{ClassInstanceToAdd["Item Price"].Value}", $"{ClassInstanceToAdd["Item ISBN"].Value}", DateTime.Now);
            CopydataTable.Rows.Add("Rented From libary", $"{ClassInstanceToAdd.ClassName}", $"{ClassInstanceToAdd["Item Price"].Value}", $"{ClassInstanceToAdd["Item ISBN"].Value}", DateTime.Now);
        }
        public void AddRowsReturned(ClassInstance ClassInstanceToAdd)
        {
            dataTable.Rows.Add("Returned To libary", $"{ClassInstanceToAdd.ClassName}", $"{ClassInstanceToAdd["Item Price"].Value}", $"{ClassInstanceToAdd["Item ISBN"].Value}", DateTime.Now);
            CopydataTable.Rows.Add("Returned To libary", $"{ClassInstanceToAdd.ClassName}", $"{ClassInstanceToAdd["Item Price"].Value}", $"{ClassInstanceToAdd["Item ISBN"].Value}", DateTime.Now);
        }
        private DataTable GetDataTable()
        {
            dataTable.Columns.Add("Action", typeof(string));
            dataTable.Columns.Add("Item Name", typeof(string));
            dataTable.Columns.Add("Item Price", typeof(string));
            dataTable.Columns.Add("Item ISBN", typeof(string));
            dataTable.Columns.Add("Action Date", typeof(DateTime));
            CopydataTable = dataTable.Copy();
            return dataTable;
        }
        private void FilterReportsFunc()
        {
            DataTable filteredTable = dataTable.Copy();
            dataTable.Clear();
            foreach (DataRow row in filteredTable.Rows)
            {
                if (row.ItemArray.Contains($"{FilterText}"))
                {
                    dataTable.ImportRow(row);
                }
            }
        }
        private void ShowAllItems()
        {
            ImportTxtFile();        
        }
        private void NewReportsFunc()
        {
            dataTable.Clear();
        }
        private void ImportTxtFile()
        {
            ConvertToDataTable(@"\\Mac\Home\Desktop\ObjectOriented\DimitryProject\UserControlFolder\Reports\reports.txt");
        }
        private void Save()
        {
            var result = new StringBuilder();
            result.Append($"Report Date:{DateTime.Now}\n");
            foreach (DataRow row in dataTable.Rows)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    result.Append(row[i].ToString());
                    result.Append(i == dataTable.Columns.Count - 1 ? "\n" : ",");
                }
                result.AppendLine();
            }
            StreamWriter objWriter = new StreamWriter("//Mac/Home/Desktop/ObjectOriented/DimitryProject/UserControlFolder/Reports/reports.txt", false);
            objWriter.WriteLine(result.ToString());
            objWriter.Close();
        }
        #endregion Funcs
    }
}
