using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Base
{
    public class VmLinkVm : BindableBase, IVmLinkVm
    {

        public VmViewIdentity viewIdentity;
        public VmViewIdentity ViewIdentity
        {
            get
            {
                if (viewIdentity == null)
                {
                    viewIdentity = new VmViewIdentity();
                }
                return viewIdentity;
            }

            set
            {
                viewIdentity = value;
                SetProperty(ref viewIdentity, value);

            }
        }


        public object vmData;
        public object VmData
        {
            get
            {
                return vmData;
            }

            set
            {
                if (!object.Equals(VmData, value))
                {

                    vmData = value;
                    OnVmDataChanged();
                    SetProperty(ref vmData, value);
                }

            }
        }

        public virtual void OnVmDataChanged()
        {


        }


        public string GetVmDataKeyString()
        {
            var result = GetVmDataKey();
            if (result == null)
            {
                return null;
            }

            return result.ToString();

        }

        public object GetVmDataKey()
        {
            if (VmData == null)
            {
                return null;
            }

            return GetVmDataKeyImpl();
        }

        public object GetVmDataKeyImpl()
        {
            throw new NotImplementedException();
        }

        public object sourceVm;
        public object SourceVm
        {
            get
            {
                return sourceVm;
            }

            set
            {
                if (!object.Equals(sourceVm, value))
                {
                    sourceVm = value;
                    OnSourceVmChanged();
                    SetProperty(ref sourceVm, value);
                }

                 
            }
        }

        public virtual void OnSourceVmChanged()
        {

        }
    }
}
