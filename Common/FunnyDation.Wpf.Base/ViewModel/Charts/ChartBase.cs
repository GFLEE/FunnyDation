using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FunnyDation.Wpf.Base.ViewModel.Charts
{
    public class ChartBase : BindableBase
    {
        public ChartBase()
        {

            DataSource = new List<ChartDataBase>();

        }



        public string lineColor;
        public string LineColor
        {
            get
            {
                return lineColor;
            }

            set
            {
                lineColor = value;
                SetProperty(ref lineColor, value);

            }
        }

        /// <summary>
        /// DataSource
        /// </summary>
        public List<ChartDataBase> dataSource;
        public List<ChartDataBase> DataSource
        {
            get
            {
                return dataSource;
            }

            set
            {
                dataSource = value;
                SetProperty(ref dataSource, value);

            }
        }


        /// <summary>
        /// X轴标签 
        /// </summary>
        public string xLabel;
        public string XLabel
        {
            get
            {
                return xLabel;
            }

            set
            {
                xLabel = value;
                SetProperty(ref xLabel, value);

            }
        }

        /// <summary>
        /// Y轴标签
        /// </summary>
        public string yLabel;
        public string YLabel
        {
            get
            {
                return yLabel;
            }

            set
            {
                yLabel = value;
                SetProperty(ref yLabel, value);

            }
        }


        /// <summary>
        /// 表格标题
        /// </summary>
        public string chartTitle;
        public string ChartTitle
        {
            get
            {
                return chartTitle;
            }

            set
            {
                chartTitle = value;
                SetProperty(ref chartTitle, value);

            }
        }


    }
}
