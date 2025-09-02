# How to Use SfDataPager with DataTable as ItemSource for WinForms DataGrid?

By default, In [WinForms DataGrid](https://www.syncfusion.com/winforms-ui-controls/datagrid) (SfDataGrid), [SfDataPager](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataPager.SfDataPager.html) doesn’t accept DataTable as a source, and we have documented this as a limitation in below user guide documentation.
 
**UG Link:** [Winforms DataGrid Paging Limitation](https://help.syncfusion.com/windowsforms/datagrid/paging#limitations)

However, we can provide a workaround to achieve your requirement by converting the DataTable to an ExpandoObject. Then, you can set the ExpandoObject collection as the DataSource for SfDataPager, as demonstrated below:

 
 ```csharp
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
    get 
    { 
       return dataTableCollection; 
    }
    set 
    { 
       dataTableCollection = value; 
    }
}
 ```


**Image Reference:**
    
  
 ![DataPager_Image.png](https://support.syncfusion.com/kb/agent/attachment/article/15655/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjIwNjc3Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.k2ExhaJ4xQdYsMIo1gj_ch1tzw5cTEiyTFGe7CaZBc0)

Take a moment to peruse the   [Winforms DataGrid - Paging](https://help.syncfusion.com/windowsforms/datagrid/paging) documentation, to learn more about paging with examples.
