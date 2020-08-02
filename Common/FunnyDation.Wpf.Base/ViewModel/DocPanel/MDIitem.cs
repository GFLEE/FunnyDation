using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FunnyDation.Wpf.Base.ViewModel.DocPanel
{
    /// <summary>
    /// panel： 唯一ID，名称，内容
    /// </summary>
    public class PanelItem : NotifyPropertyChangedBase
    {

        public PanelItem(int id, string name, UserControl obj)
        {
            this.ID = id;
            this.name = name;
            this.Content = obj; 
        }


        public const string WindowIDPropertyName = "ID";

        private int id = 0;
        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                if (id == value)
                {
                    return;
                }

                id = value;
                NotifyPropertyChanged("ID");
            }
        }

        public const string WindowNamePropertyName = "Name";



        public string name;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (name == value)
                {
                    return;
                }

                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public const string WindowContentPropertyName = "Content";

        public UserControl content;
        public UserControl Content
        {
            get
            {
                return content;
            }

            set
            {
                content = value;
                NotifyPropertyChanged("Content");
            }
        }

    }

}
