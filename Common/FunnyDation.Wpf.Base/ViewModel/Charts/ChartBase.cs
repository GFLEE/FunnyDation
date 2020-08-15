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
    public class ChartBase : BindableBase
    {
        public ChartBase()
        {
            DataSource = new ObservableCollection<ChartDataBase>();


        }

        public ObservableCollection<ChartDataBase> DataSource { get; set; }



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
    }
}
