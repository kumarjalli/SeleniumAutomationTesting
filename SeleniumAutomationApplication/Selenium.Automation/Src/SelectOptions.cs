using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Selenium.Automation
{
    public partial class SelectOptions : Form
    {
        List<PanelStyle> designs;
        public SelectOptions(string line, List<PanelStyle> styles)
        {
            designs = styles;
            InitializeComponent();
            PopulateData(line);
        }

        private void PopulateData(string line)
        {
            try
            {
                tvwOptions.Nodes.Clear();
                TreeNode rootnode = tvwOptions.Nodes.Add(line);
                foreach (PanelStyle design in designs)
                {

                    TreeNode designNode = rootnode.Nodes.Add(design.ItemName.ToString());
                    designNode.Tag = design;

                    if (line == "Coachman")
                    {
                        foreach (Construction construction in design.Constructions)
                        {
                            foreach (MydoorColor color in construction.Colors)
                            {
                                Claddingoverlay overlay = new Claddingoverlay();
                                overlay.ItemId = color.ItemId;
                                overlay.ItemName = color.ItemName;
                                construction.Claddingoverlays.Add(overlay);
                            }
                        }
                    }

                    if (line == "CanyonRidge" || line == "Coachman")
                    {
                        foreach (Construction construction in design.Constructions)
                        {
                            TreeNode constructionNode = designNode.Nodes.Add(construction.ItemName.ToString());
                            constructionNode.Tag = construction;
                            foreach (Claddingoverlay overlay in construction.Claddingoverlays)
                            {
                                TreeNode overlayNode = constructionNode.Nodes.Add(overlay.ItemName.ToString());
                                overlayNode.Tag = overlay;
                                foreach (MydoorColor color in construction.Colors)
                                {
                                    TreeNode colorNode = overlayNode.Nodes.Add(color.ItemName.ToString());
                                    colorNode.Tag = color;
                                    foreach (TopSection topSection in color.TopSections)
                                    {
                                        TreeNode topSectionNode = colorNode.Nodes.Add(topSection.ItemName.ToString());
                                        topSectionNode.Tag = topSection;
                                        foreach (GlassType glassType in topSection.Glasstypes)
                                        {
                                            TreeNode glassTypeNode = topSectionNode.Nodes.Add(glassType.ItemName.ToString());
                                            glassTypeNode.Tag = glassType;
                                        }//glassTypes
                                    }//topSection
                                }//color
                            }//overlay
                        }//construction
                    }
                    else
                    {
                        foreach (Construction construction in design.Constructions)
                        {
                            TreeNode constructionNode = designNode.Nodes.Add(construction.ItemName.ToString());
                            constructionNode.Tag = construction;
                            foreach (MydoorColor color in construction.Colors)
                            {
                                TreeNode colorNode = constructionNode.Nodes.Add(color.ItemName.ToString());
                                colorNode.Tag = color;
                                foreach (TopSection topSection in color.TopSections)
                                {
                                    TreeNode topSectionNode = colorNode.Nodes.Add(topSection.ItemName.ToString());
                                    topSectionNode.Tag = topSection;
                                    foreach (GlassType glassType in topSection.Glasstypes)
                                    {
                                        TreeNode glassTypeNode = topSectionNode.Nodes.Add(glassType.ItemName.ToString());
                                        glassTypeNode.Tag = glassType;
                                    }//glassTypes
                                }//topSection
                            }//color
                        }//construction

                    }
                    //Hardware
                    if (design.Hardware != null)
                    {
                        TreeNode hardwareNode = designNode.Nodes.Add("Hardware");
                        Hardware hardware = design.Hardware;

                        if (hardware.LHDKs != null && hardware.LHDKs.Count > 0)
                        {
                            TreeNode handleNode = hardwareNode.Nodes.Add("Handles");
                            foreach (LHDK handles in hardware.LHDKs)
                            {
                                TreeNode handlesNode = handleNode.Nodes.Add(handles.ItemName.ToString());
                                handlesNode.Tag = handles;
                            }
                        }

                        if (hardware.LockOptions != null && hardware.LockOptions.Count > 0)
                        {
                            TreeNode lockOptionNode = hardwareNode.Nodes.Add("Lock Options");
                            foreach (LockOption lockOptions in hardware.LockOptions)
                            {
                                TreeNode lockOptionsNode = lockOptionNode.Nodes.Add(lockOptions.ItemName.ToString());
                                lockOptionsNode.Tag = lockOptions;
                            }
                        }

                        if (hardware.Locks != null && hardware.Locks.Count > 0)
                        {
                            TreeNode lockNode = hardwareNode.Nodes.Add("Locks");
                            foreach (Lock locks in hardware.Locks)
                            {
                                TreeNode locksNode = lockNode.Nodes.Add(locks.ItemName.ToString());
                                locksNode.Tag = locks;
                            }
                        }

                        if (hardware.OtherItems != null && hardware.OtherItems.Count > 0)
                        {
                            TreeNode OtherItemNode = hardwareNode.Nodes.Add("Other Items");
                            foreach (OtherItem otherItems in hardware.OtherItems)
                            {
                                TreeNode otherItemsNode = OtherItemNode.Nodes.Add(otherItems.ItemName.ToString());
                                otherItemsNode.Tag = otherItems;
                            }
                        }

                        if (hardware.StepPlates != null && hardware.StepPlates.Count > 0)
                        {
                            TreeNode stepPlateNode = hardwareNode.Nodes.Add("Step Plates");
                            foreach (StepPlate stepPlates in hardware.StepPlates)
                            {
                                TreeNode stepPlatesNode = stepPlateNode.Nodes.Add(stepPlates.ItemName.ToString());
                                stepPlatesNode.Tag = stepPlates;
                            }
                        }

                        if (hardware.StrapHinges != null && hardware.StrapHinges.Count > 0)
                        {
                            TreeNode strapHingeNode = hardwareNode.Nodes.Add("Strap Hinges");
                            foreach (StrapHinx strapHinges in hardware.StrapHinges)
                            {
                                TreeNode strapHingesNode = strapHingeNode.Nodes.Add(strapHinges.ItemName.ToString());
                                strapHingesNode.Tag = strapHinges;
                            }
                        }

                        if (hardware.Struts != null && hardware.Struts.Count > 0)
                        {
                            TreeNode strutNode = hardwareNode.Nodes.Add("Struts");
                            foreach (Strut struts in hardware.Struts)
                            {
                                TreeNode strutsNode = strutNode.Nodes.Add(struts.ItemName.ToString());
                                strutsNode.Tag = struts;
                            }
                        }
                        hardwareNode.Tag = design.Hardware;
                    }// Hardware
                }//design
            }
            catch (Exception ex)
            {
                //ignore
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveOptions(tvwOptions.TopNode);
            // Console.WriteLine(xDocument.ToString());
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        private void SaveOptions(TreeNode parentNode)
        {
            //if (parentNode.Checked && (parentNode.Tag != null))
            //{
            //  ((XElement)parentNode.Tag).SetAttributeValue("Selected", "true");
            //}
            //foreach (TreeNode node in parentNode.Nodes)
            //{

            //  if (node.Nodes.Count > 0)
            //  {
            //    SaveOptions(node);
            //  }
            //  else
            //  {
            //    if (node.Checked && (node.Tag != null))
            //    {
            //      ((XElement)parentNode.Tag).SetAttributeValue("Selected", "true");
            //    }
            //  }
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void tvwOptions_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                //((XElement)e.Node.Tag).SetAttributeValue("Selected", e.Node.Checked.ToString().ToLower());
                //((JObject)e.Node.Tag).Property("Selected").Value = "true";

                switch (e.Node.Tag.GetType().Name)
                {
                    case "GlassType":
                        ((GlassType)e.Node.Tag).Selected = true;
                        break;
                    case "TopSection":
                        ((TopSection)e.Node.Tag).Selected = true;
                        break;
                    case "Claddingoverlay":
                        ((Claddingoverlay)e.Node.Tag).Selected = true;
                        break;
                    case "MydoorColor":
                        ((MydoorColor)e.Node.Tag).Selected = true;
                        break;
                    case "Construction":
                        ((Construction)e.Node.Tag).Selected = true;
                        break;
                    case "PanelStyle":
                        ((PanelStyle)e.Node.Tag).Selected = true;
                        break;
                    case "Hardware":
                        ((Hardware)e.Node.Tag).Selected = true;
                        break;
                    case "LHDK":
                        ((LHDK)e.Node.Tag).Selected = true;
                        break;
                    case "StepPlate":
                        ((StepPlate)e.Node.Tag).Selected = true;
                        break;
                    case "StrapHinx":
                        ((StrapHinx)e.Node.Tag).Selected = true;
                        break;
                    case "Lock":
                        ((Lock)e.Node.Tag).Selected = true;
                        break;
                    case "LockOption":
                        ((LockOption)e.Node.Tag).Selected = true;
                        break;
                    case "OtherItems":
                        ((OtherItem)e.Node.Tag).Selected = true;
                        break;
                    default:
                        break;
                }

                if (e.Node.Checked && !e.Node.Parent.Checked)
                {
                    e.Node.Parent.Checked = true;
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvwOptions.Nodes)
            {
                CheckNodes(node, true);
            }
        }

        private void CheckNodes(TreeNode node, bool check)
        {
            foreach (TreeNode child in node.Nodes)
            {
                child.Checked = check;
                CheckNodes(child, check);
            }
        }

        private void btnUnSelect_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvwOptions.Nodes)
            {
                CheckNodes(node, false);
            }
        }
    }
}
