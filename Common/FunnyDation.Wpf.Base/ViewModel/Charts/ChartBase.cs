using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FunnyDation.Wpf.Base.ViewModel.Charts
{
    public class ChartBase : CrlVm
    {
        public ChartBase()
        {
            DataSource = new ObservableCollection<ChartDataBase>();


        }



        /// <summary>
        /// DataSource
        /// </summary>
        public ObservableCollection<ChartDataBase> dataSource;
        public ObservableCollection<ChartDataBase> DataSource
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
        /// 数据主键
        /// </summary>
        public string primaryKey;
        public string PrimaryKey
        {
            get
            {
                return primaryKey;
            }

            set
            {
                primaryKey = value;
                SetProperty(ref primaryKey, value);

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
