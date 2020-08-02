using Prism.Mvvm;
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
    public class PanelItem : BindableBase
    {

        public PanelItem(int id, string name, UserControl obj)
        {
            this.ID = id;
            this.name = name;
            this.Content = obj; 
        }


        public const string WindowIDPropertyName = "ID";

        public int id = 0;
        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                SetProperty(ref id, value);
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
                name = value;
                SetProperty(ref name, value);
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
                SetProperty(ref content, value);
            }
        }

    }

}
