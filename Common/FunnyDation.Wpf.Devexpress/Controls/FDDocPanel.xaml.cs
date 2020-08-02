using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FunnyDation.Wpf.Devexpress.Controls
{
    /// <summary>
    /// FDDocPanel.xaml 的交互逻辑
    /// </summary>
    public partial class FDDocPanel : UserControl
    {
        public FDDocPanel()
        {
            InitializeComponent();
        }

        
    }
    public class DocVM : GalaSoft.MvvmLight.ViewModelBase
    {

        #region  Property=ListOfCollages  -  Type=ObservableCollection<MDIitem>  -  InitialValue=null
        /// <summary>
        /// The <see cref="ListOfCollages" /> property's name.
        /// </summary>
        public const string ListOfCollagesPropertyName = "ListOfCollages";

        private ObservableCollection<MDIitem> _ListOfCollages = null;

        /// <summary>
        /// Sets and gets the ListOfCollages property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<MDIitem> ListOfCollages
        {
            get
            {
                return _ListOfCollages;
            }

            set
            {
                if (_ListOfCollages == value)
                {
                    return;
                }

                _ListOfCollages = value;
                RaisePropertyChanged(() => ListOfCollages);
            }
        }
        #endregion  Property=ListOfCollages




        public DocVM()
        {

            if (ListOfCollages == null)
                ListOfCollages = new ObservableCollection<MDIitem>();

            ListOfCollages.Clear();

            ListOfCollages.Add(new MDIitem() { WindowID = 1, WindowName = "Doc A", WindowContent = "Text a" });
            ListOfCollages.Add(new MDIitem() { WindowID = 2, WindowName = "Doc B", WindowContent = "Text b" });
            ListOfCollages.Add(new MDIitem() { WindowID = 3, WindowName = "Doc C", WindowContent = "Text c" });

        }



    }



    public class MDIitem : GalaSoft.MvvmLight.ViewModelBase
    {


        #region  Property=WindowID  -  Type=int  -  InitialValue=0
        /// <summary>
        /// The <see cref="WindowID" /> property's name.
        /// </summary>
        public const string WindowIDPropertyName = "WindowID";

        private int _WindowID = 0;

        /// <summary>
        /// Sets and gets the WindowID property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int WindowID
        {
            get
            {
                return _WindowID;
            }

            set
            {
                if (_WindowID == value)
                {
                    return;
                }

                _WindowID = value;
                RaisePropertyChanged(() => WindowID);
            }
        }
        #endregion  Property=WindowID

        #region  Property=WindowName  -  Type=string  -  InitialValue=""
        /// <summary>
        /// The <see cref="WindowName" /> property's name.
        /// </summary>
        public const string WindowNamePropertyName = "WindowName";

        private string _WindowName = "";

        /// <summary>
        /// Sets and gets the WindowName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WindowName
        {
            get
            {
                return _WindowName;
            }

            set
            {
                if (_WindowName == value)
                {
                    return;
                }

                _WindowName = value;
                RaisePropertyChanged(() => WindowName);
            }
        }
        #endregion  Property=WindowName

        #region  Property=WindowContent   -  Type=string   -  InitialValue=""
        /// <summary>
        /// The <see cref="WindowContent " /> property's name.
        /// </summary>
        public const string WindowContentPropertyName = "WindowContent";

        private string _WindowContent = "";

        /// <summary>
        /// Sets and gets the WindowContent  property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WindowContent
        {
            get
            {
                return _WindowContent;
            }

            set
            {
                if (_WindowContent == value)
                {
                    return;
                }

                _WindowContent = value;
                RaisePropertyChanged(() => WindowContent);
            }
        }
        #endregion  Property=WindowContent 



    }


    public class zStringToStringConverter : IValueConverter
    {



        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string ret = value.ToString();



            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {



            return value;
        }
    }
}
