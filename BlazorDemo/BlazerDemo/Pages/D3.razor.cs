using BlazorDemo.Models;

namespace BlazorDemo.Pages
{
    public partial class D3
    {
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (pieChartRecords.Loaded)
                return;
            
            pieChartRecords.Records.Add(new D3PieChartRecordViewModel() { BrowserName = "IE", Value = 40, Color = "lightgreen" });
            pieChartRecords.Records.Add(new D3PieChartRecordViewModel() { BrowserName = "Chrome", Value = 30, Color = "lightblue" });
            pieChartRecords.Records.Add(new D3PieChartRecordViewModel() { BrowserName = "Firefox", Value = 50, Color = "pink" });
            pieChartRecords.Records.Add(new D3PieChartRecordViewModel() { BrowserName = "Opera", Value = 20, Color = "orange" });
            pieChartRecords.Records.Add(new D3PieChartRecordViewModel() { BrowserName = "Safari", Value = 25, Color = "aqua" });
            
            pieChartRecords.Loaded = true;
        }
    }
}