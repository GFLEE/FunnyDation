using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Base.ViewModel.Charts
{
    /// <summary>
    /// Simple Line
    /// </summary>
    public class LineVm : ChartBase
    {
        public LineVm() : base()
        {


        }
        public LineVm(string x_param, string y_param, string title, 
            string x_label, string y_label, int marker_size = 10) : base()
        {
            this.XParam = x_param;
            this.YParam = y_param;
            this.ChartTitle = title;
            this.XLabel = x_label;
            this.yLabel = y_label;
            this.MarkerSize = marker_size;
        }

        /// <summary>
        /// 标记圆点大小
        /// </summary>
        public int markerSize = 5;
        public int MarkerSize
        {
            get
            {
                return markerSize;
            }

            set
            {
                markerSize = value;
                SetProperty(ref markerSize, value);

            }
        }

        /// <summary>
        /// X轴参数
        /// </summary>
        public string xParam;
        public string XParam
        {
            get
            {
                return xParam;
            }

            set
            {
                xParam = value;
                SetProperty(ref xParam, value);

            }
        }

        /// <summary>
        /// Y轴参数
        /// </summary>
        public string yParam;
        public string YParam
        {
            get
            {
                return yParam;
            }

            set
            {
                yParam = value;
                SetProperty(ref yParam, value);

            }
        }









    }
}
