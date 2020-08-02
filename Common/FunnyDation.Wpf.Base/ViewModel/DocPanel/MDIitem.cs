using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Base.ViewModel.DocPanel
{
    public class MDIitem : NotifyPropertyChangedBase
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
                NotifyPropertyChanged("WindowID");
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
                NotifyPropertyChanged("WindowName");
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
                NotifyPropertyChanged("WindowContent");
            }
        }
        #endregion  Property=WindowContent 



    }

}
