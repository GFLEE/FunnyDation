﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Base.ViewModel.ToolBars
{
    public class ToolBarBaseVm : NodeContainerVm
    {
        public ToolBarBaseVm(object hostVm, string key) : base(hostVm)
        {
            this.Key = key;

        }


        public string Key { get; set; }

    }
}
