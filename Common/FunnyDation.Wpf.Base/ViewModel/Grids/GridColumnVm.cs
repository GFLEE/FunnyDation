using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Events;
using FunnyDation.Wpf.Selectors;
using DevExpress.Xpf.Editors.Internal;

namespace FunnyDation.Wpf.Base.ViewModel.Grids
{
    public class GridColumnVm : BindableBase, ITemplateItem
    {

        public GridColumnVm(string fieldName, string header)
            : this(fieldName, header, "")
        {

        }
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="header"></param>
        /// <param name="templateName"></param>
        public GridColumnVm(string fieldName, string header, string templateName)
        {
            this.Visible = true;
            this.FieldName = fieldName;
            this.Header = header;
            this.TemplateName = templateName;
            if (string.IsNullOrEmpty(header))
            {
                this.Header = header;
            }

        }
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public static GridColumnVm Create(string fieldName, string header)
        {
            return Create(fieldName, header, GridColumnType.String, null, null);

        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="header"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static GridColumnVm Create(string fieldName, string header, object width)
        {
            return Create(fieldName, header, GridColumnType.String, null, width);

        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="header"></param>
        /// <param name="gridColumnType"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static GridColumnVm Create(string fieldName, string header, GridColumnType gridColumnType, object width)
        {

            return Create(fieldName, header, gridColumnType, null, width);
        }
        /// <summary>
        /// 添加Column
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="header"></param>
        /// <param name="type"></param>
        /// <param name="setting"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static GridColumnVm Create(string fieldName, string header, GridColumnType type, IColumnSetting setting, object width)
        {
            var result = new GridColumnVm(fieldName, header)
            {
                Width = width,
                GridColumnType = type
            };
            if (setting == null)
            {

            }
            result.ColumnSetting = setting;
            return result;
        }


        /// <summary>
        /// 宽度
        /// </summary>
        public object Width { get; set; }

        public GridColumnVm(string fieldName) : this(fieldName, "", "")
        {



        }

        /// <summary>
        /// 字段名
        /// </summary>
        public string fieldName;
        public string FieldName
        {
            get
            {
                return fieldName;
            }

            set
            {
                fieldName = value;
                SetProperty(ref fieldName, value);

            }
        }

        /// <summary>
        /// 列显示文字
        /// </summary>
        public string header;
        public string Header
        {
            get
            {
                return header;
            }

            set
            {
                header = value;
                SetProperty(ref header, value);

            }
        }

        /// <summary>
        /// 模板名
        /// </summary>
        public string templateName;
        public string TemplateName
        {
            get
            {
                return templateName;
            }

            set
            {
                templateName = value;
                SetProperty(ref templateName, value);

            }
        }
        /// <summary>
        /// Column是否可见
        /// </summary>
        public bool visible;
        public bool Visible
        {
            get
            {
                return visible;
            }

            set
            {
                visible = value;
                SetProperty(ref visible, value);

            }
        }
        public GridColumnType GridColumnType { get; set; }
        public IColumnSetting ColumnSetting { get; set; }


    }
}
