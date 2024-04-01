using Syncfusion.Data;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SfDatagridDemo
{
    public partial class Form1 : Form
    {
        private DataTable dataTableCollection;
        private ObservableCollection<dynamic> dynamicCollection;
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            //Gets the data for DataTable object.
            dataTableCollection = GetGridData();

            //Convert DataTable collection as Dyanamic collection.
            dynamicCollection = new ObservableCollection<dynamic>();
            foreach (System.Data.DataRow row in dataTableCollection.Rows)
            {
                dynamic dyn = new ExpandoObject();
                dynamicCollection.Add(dyn);
                foreach (DataColumn column in dataTableCollection.Columns)
                {
                    var dic = (IDictionary<string, object>)dyn;
                    dic[column.ColumnName] = row[column];
                }
            }

            DynamicOrders = dynamicCollection;
            sfDataPager1.DataSource = DynamicOrders;
            sfDataPager1.PageSize = 10;
            sfDataGrid1.DataSource = sfDataPager1.PagedSource;
        }


        private ObservableCollection<dynamic> _dynamicOrders;

        /// <summary>
        /// Gets or sets the dynamic orders.
        /// </summary>
        /// <value>The dynamic orders.</value>
        public ObservableCollection<dynamic> DynamicOrders
        {
            get
            {
                return _dynamicOrders;
            }
            set
            {
                _dynamicOrders = value;
            }
        }

        public DataTable DataTableCollection
        {
            get { return dataTableCollection; }
            set { dataTableCollection = value; }
        }

        private DataTable GetGridData()
        {
            var myDataTable = new DataTable();

            // Add columns to DataTable.

            myDataTable.Columns.Add("Employee ID", typeof(int));
            myDataTable.Columns.Add("Employee Name", typeof(string));
            myDataTable.Columns.Add("Employee Age", typeof(double));
            myDataTable.Columns.Add("Employee Designation", typeof(string));
            myDataTable.Columns.Add("Employee Country", typeof(string));

            // Add some rows to the DataTable.
            myDataTable.Rows.Add(1001, "Sean Jacobson", 21,  "Junior Architect", "Argentina");
            myDataTable.Rows.Add(1002, "Phyllis Allen", 33,  "Team Lead",  "Austria");
            myDataTable.Rows.Add(1003, "Marvin Allen", 42, "Team Lead", "Denmark");
            myDataTable.Rows.Add(1004, "Michael Allen", 22, "Junior Architect",  "Canada");
            myDataTable.Rows.Add(1005, "Cecil Allison", 33,"Team Lead",  "Mexico");
            myDataTable.Rows.Add(1006, "Tom Johnston", 44,"Senior Architect", "USA");
            myDataTable.Rows.Add(1007, "Thomas Armstrong", 21, "Junior Architect",  "UK");
            myDataTable.Rows.Add(1008, "John Arthur", 33,   "Team Lead",  "Ireland");
            myDataTable.Rows.Add(1009, "Chris Ashton", 42, "Junior Architect", "Denmark");
            myDataTable.Rows.Add(1010, "Teresa Atkinson", 22,"Junior Architect", "France");
            myDataTable.Rows.Add(1011, "John Ault", 33,"Sales Engineer",  "Argentina");
            myDataTable.Rows.Add(1012, "Robert Avalos", 44, "Team Lead",  "Austria");
            myDataTable.Rows.Add(1013, "Cecil Allison", 21,"Junior Architect",  "Switzerland");
            myDataTable.Rows.Add(1014, "Stephen Ayers", 33,"Junior Architect", "Ireland");
            myDataTable.Rows.Add(1015, "Selena Alvarad", 42, "Team Lead", "Canada");
            myDataTable.Rows.Add(1016, "Phyllis Allen", 22,"Junior Architect", "Mexico");
            myDataTable.Rows.Add(1017, "Maxwell Amland", 33,"Senior Architect", "Austria");
            myDataTable.Rows.Add(1018, "Gustavo Achong", 44,"Engineer", "USA");
            myDataTable.Rows.Add(1019, "Hannah Arakawa", 21,"Sales Engineer", "Denmark");
            myDataTable.Rows.Add(1020, "Stephen Ayers", 33,"Senior Architect", "Spain");
            myDataTable.Rows.Add(1021, "Mae Anderson", 42,"Engineer", "Switzerland");
            myDataTable.Rows.Add(1022, "ames Aguilar", 22,"Junior Architect", "Argentina");
            myDataTable.Rows.Add(1023, "Sean Jacobson", 33,"Team Lead", "Canada");
            myDataTable.Rows.Add(1024, "Marvin Allen", 44,"Sales Engineer", "France");
            myDataTable.Rows.Add(1025, "Michael Allen", 21,"Junior Architect", "Italy");
            myDataTable.Rows.Add(1026, "Frances Adams", 33,"Team Lead", "Germany");
            myDataTable.Rows.Add(1027, "Gustavo Achong", 42,"Engineer", "Argentina");
            myDataTable.Rows.Add(1028, "Chris Ashton", 22, "Junior Architect", "Denmark");
            myDataTable.Rows.Add(1029, "Robert Avalos", 33, "Senior Architect", "Canada");
            myDataTable.Rows.Add(1030, "John Arthur", 44, "Sales Engineer", "Austria");
            myDataTable.Rows.Add(1031, "Stephen Ayers", 21, "Junior Architect", "France");
            myDataTable.Rows.Add(1032, "Teresa Atkinson", 33, "Team Lead", "Argentina");
            myDataTable.Rows.Add(1033, "Thomas Armstrong", 42,"Senior Architect", "Ireland");
            myDataTable.Rows.Add(1034, "Kyley Arbelaez", 22,"Junior Architect", "Austria");
            myDataTable.Rows.Add(1035, "Maxwell Amland", 33,"Senior Architect", "Denmark");
            myDataTable.Rows.Add(1036, "Frances Adams", 44,"Sales Engineer", "France");
            myDataTable.Rows.Add(1037, "Hannah Arakawa", 21,"Sales Engineer", "Canada");
            myDataTable.Rows.Add(1038, "Kyley Arbelaez", 33,"Senior Architect", "Italy");
            myDataTable.Rows.Add(1039, "Maxwell Amland", 42,"Engineer", "Mexico");
            myDataTable.Rows.Add(1040, "Stephen Ayers", 22,"Junior Architect", "Argentina");
            myDataTable.Rows.Add(1041, "John Ault", 33,"Team Lead", "France");
            myDataTable.Rows.Add(1042, "Teresa Atkinson", 44,"Senior Architect", "UK");
            myDataTable.Rows.Add(1043, "Michael Allen", 21,"Sales Engineer", "Austria");
            myDataTable.Rows.Add(1044, "Tom Johnston", 33,"Team Lead", "Canada");
            myDataTable.Rows.Add(1045, "John Arthur", 42, "Engineer", "Denmark");
            myDataTable.Rows.Add(1046, "Chris Ashton", 22, "Sales Engineer", "Argentina");
            myDataTable.Rows.Add(1047, "Phyllis Allen", 33,"Senior Architect", "Germany");
            myDataTable.Rows.Add(1048, "Thomas Armstrong", 44,"Engineer", "Canada");
            myDataTable.Rows.Add(1049, "Cecil Allison", 33,"Senior Architect", "France");
            myDataTable.Rows.Add(1050, "Sean Jacobson", 42,"Engineer", "Austria");
            return myDataTable;
        }
    }
}
