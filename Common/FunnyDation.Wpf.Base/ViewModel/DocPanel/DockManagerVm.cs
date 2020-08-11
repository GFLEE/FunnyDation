using Prism.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FunnyDation.Wpf.Base.ViewModel.DocPanel
{
    /// <summary>
    /// Doc ManagerVm
    /// </summary>
    public class DockManagerVm
    {
        public DockManagerVm()
        {
            Panels = new ObservableCollection<DockPanelVm>();

            DmvService.Instance.AddDockManagerVm(this);
        }
        public ObservableCollection<DockPanelVm> Panels { get; set; }


        public DockPanelVm GetPanel(string key)
        {
            var panel = Panels.FirstOrDefault(p => p.Key.Equals(key));
            return panel;
        }

        public DockPanelVm CreataOrActiveDocumentPanel(DockPanelParam dockPanelParam)
        {
            var result = CreatePanel(dockPanelParam, "DocumentHost", "DocumentTemplate");
            return result;
        }

        public DockPanelVm CreataOrActiveLayoutPanel(DockPanelParam dockPanelParam, string TargetName)
        {
            var result = CreatePanel(dockPanelParam, TargetName, "LayoutPanelTemplate");
            return result;
        }

        public DockPanelVm CreataOrActivePanel(DockPanelParam dockPanelParam)
        {
            var result = CreatePanel(dockPanelParam, dockPanelParam.TargetName, dockPanelParam.TemplateName);
            return result;
        }



        private DockPanelVm CreatePanel(DockPanelParam dockPanelParam, string targetName, string templateName)
        {

            if (dockPanelParam.ProcessStyle.Equals(EuProcessStyle.New))
            {
                dockPanelParam.CrlVm.ViewIdentity.ReKey();
            }
            var key = dockPanelParam.CrlVm.ViewIdentity.Key;
            var pane = Panels.FirstOrDefault(p => p.Key.Equals(key));
            if (pane != null)
            {
                if (dockPanelParam.ProcessStyle.Equals(EuProcessStyle.Open))
                {
                    return pane;
                }
                if (dockPanelParam.ProcessStyle.Equals(EuProcessStyle.CloseAndNew))
                {
                    pane.Close();
                    if (pane.Crl != null)
                    {
                        return pane;
                    }
                }
                else
                {
                    pane.IsClosed = false;
                    pane.IsActive = true;
                    pane.Caption = dockPanelParam.Caption;
                    pane.ToolTip = dockPanelParam.ToolTip;
                    if (dockPanelParam.ProcessStyle.Equals(EuProcessStyle.Active))
                    {
                        return pane;
                    }
                    if (dockPanelParam.ProcessStyle.Equals(EuProcessStyle.UpdateVm))
                    {
                        pane.CrlVm.ActionClose = null;
                        pane.Crl = dockPanelParam.Crl;
                        return pane;
                    }

                    if (dockPanelParam.ProcessStyle.Equals(EuProcessStyle.UpdateVmData))
                    {
                        pane.CrlVm.VmData = dockPanelParam.CrlVm.VmData;
                        pane.CrlVm.SourceVm = dockPanelParam.CrlVm.SourceVm;
                        pane.CrlVm.ViewIdentity = dockPanelParam.CrlVm.ViewIdentity;
                        return pane;
                    }
                }
            }

            DockPanelVm dockPanelVm = null;
            dockPanelVm = new DockPanelVm(targetName)
            {
                Caption = dockPanelParam.Caption,
                ToolTip = dockPanelParam.ToolTip,
                DockManager = this,
                TemplateName = templateName,
                Crl = dockPanelParam.Crl,
                IsActive = true
            };
            dockPanelVm.CrlVm.ActionClose = (crl) => GetPanel(crl.ViewIdentity.Key).Close();
            Panels.Add(dockPanelVm);

            return dockPanelVm;

        }

        public void TryClosePanel(string key)
        {
            var panel = this.GetPanel(key);
            if (panel == null)
            {
                return;
            }
            panel.Close();
        }

        internal void ClosePanel(DockPanelVm panel)
        {
            if (panel == null || panel.CrlVm == null)
            {
                return;
            }
            panel.CrlVm.ActionClose = null;
            panel.Crl = null;
            Panels.Remove(panel);
        }



        public void ClosePanel()
        {
            Panels.ToList().ForEach(p =>
            {
                ClosePanel(p);
            });
        }

        public void Dispose()
        {
            DmvService.Instance.RemoveDockManagerVm(this);
        }




    }
}
