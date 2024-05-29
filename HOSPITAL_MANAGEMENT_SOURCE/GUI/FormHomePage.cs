using LiveCharts.Wpf;
using LiveCharts;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace HOSPITAL_MANAGEMENT_SOURCE.GUI
{
    public partial class FormHomePage : MaterialForm
    {
        public FormHomePage()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800,
                Primary.BlueGrey900,
                Primary.BlueGrey500,
                Accent.LightBlue200,
                TextShade.WHITE);
            LiveChartsColumn();
        }
        private void LiveChartsColumn()
        {
            //// Tạo dữ liệu ngẫu nhiên cho từng tháng
            Random rand = new Random();
            var data = new ChartValues<int>
            {
                rand.Next(20, 100), // Tháng 7 2023
                rand.Next(20, 100), // Tháng 8 2023
                rand.Next(20, 100), // Tháng 9 2023
                rand.Next(20, 100), // Tháng 10 2023
                rand.Next(20, 100), // Tháng 11 2023
                rand.Next(20, 100), // Tháng 12 2023
                rand.Next(20, 100), // Tháng 1 2024
                rand.Next(20, 100), // Tháng 2 2024
                rand.Next(20, 100), // Tháng 3 2024
                rand.Next(20, 100), // Tháng 4 2024
                rand.Next(20, 100), // Tháng 5 2024
                rand.Next(20, 100)  // Tháng 6 2024
            };

            cartesianChart1.Series = new SeriesCollection();
            for (int i = 0; i < 6; ++i)
            {
                string monthYear = (i + 7).ToString() + "/2023";
                cartesianChart1.Series.Add(
                    new ColumnSeries
                    {
                        Title = (i + 7).ToString() + "/2023",
                        Values = new ChartValues<int> { data[i] },
                        Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 99, 132)),
                        ColumnPadding = 8,
                    }
                );
            }
            
            for (int i = 6; i < 12; i++)
            {
                string monthYear = (i - 5).ToString() + "/2024";
               
                cartesianChart1.Series.Add(
                    new ColumnSeries
                    {
                        Title = (i - 5).ToString() + "/2024",
                        Values = new ChartValues<int> { data[i] },
                        Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(54, 162, 235)),
                        ColumnPadding = 8,
                    }
                 );
            }

            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis
            {
                Labels = new[]
                {
                    "07/2023 → 06/2024"
                },
            });
            cartesianChart1.AxisY.Clear();  
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Số lượng bệnh nhân",
                LabelFormatter = value => value.ToString("N")
            });

        }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        private void FormHomePage_Load(object sender, EventArgs e)
        {

        }
    }
}
