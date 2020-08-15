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
        public LineVm()
        {



        }

        /// <summary>
        /// 标记圆点大小
        /// </summary>
        public int markerSize;
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
        public int xParam;
        public int XParam
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
        public int yParam;
        public int YParam
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
