﻿using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace AntPanel
{
    partial class PluginUI
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private String[] dropFiles = null;
        private bool preventExpand = false;
        private DateTime lastMouseDown = DateTime.Now;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginUI));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.add = new System.Windows.Forms.ToolStripButton();
            this.refresh = new System.Windows.Forms.ToolStripButton();
            this.run = new System.Windows.Forms.ToolStripButton();
            this.tree = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.add,
            this.refresh,
            this.run});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(279, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // addButton
            // 
            this.add.Image = ((System.Drawing.Image)(resources.GetObject("addButton.Image")));
            this.add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.add.Name = "addButton";
            this.add.Size = new System.Drawing.Size(49, 22);
            this.add.Text = "Add";
            this.add.ToolTipText = "Add build file";
            this.add.Click += new System.EventHandler(this.AddClick);
            // 
            // refreshButton
            // 
            this.refresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refresh.Image = ((System.Drawing.Image)(resources.GetObject("refreshButton.Image")));
            this.refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refresh.Name = "refreshButton";
            this.refresh.Size = new System.Drawing.Size(23, 22);
            this.refresh.Text = "toolStripButton2";
            this.refresh.ToolTipText = "Refresh";
            this.refresh.Click += new System.EventHandler(this.RefreshClick);
            // 
            // runButton
            // 
            this.run.Image = ((System.Drawing.Image)(resources.GetObject("runButton.Image")));
            this.run.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.run.Name = "runButton";
            this.run.Size = new System.Drawing.Size(48, 22);
            this.run.Text = "Run";
            this.run.Click += new System.EventHandler(this.RunClick);
            // 
            // treeView
            // 
            this.tree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.HideSelection = false;
            this.tree.ImageIndex = 0;
            this.tree.ImageList = this.imageList;
            this.tree.Location = new System.Drawing.Point(0, 25);
            this.tree.Name = "treeView";
            this.tree.SelectedImageIndex = 0;
            this.tree.ShowNodeToolTips = true;
            this.tree.Size = new System.Drawing.Size(279, 285);
            this.tree.TabIndex = 1;
            this.tree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeNodeMouseDoubleClick);
            this.tree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeBeforeExpand);
            this.tree.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeBeforeCollapse);
            this.tree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeMouseDown);
            this.tree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeNodeMouseClick);
            this.tree.KeyUp += TreeNodeKeyUp;
            this.tree.KeyPress += TreeNodeKeyPress;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "ant_buildfile.png");
            this.imageList.Images.SetKeyName(1, "defaulttarget_obj.png");
            this.imageList.Images.SetKeyName(2, "targetinternal_obj.png");
            this.imageList.Images.SetKeyName(3, "targetpublic_obj.png");
            // 
            // PluginUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tree);
            this.Controls.Add(this.toolStrip);
            this.Name = "PluginUI";
            this.Size = new System.Drawing.Size(279, 310);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.ToolStripButton add;
        private System.Windows.Forms.ToolStripButton refresh;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripButton run;

        internal void StartDragHandling()
        {
            this.tree.AllowDrop = true;
            this.tree.DragEnter += new DragEventHandler(TreeDragEnter);
            this.tree.DragDrop += new DragEventHandler(TreeDragDrop);
            this.tree.DragOver += new DragEventHandler(TreeDragOver);
        }

        private void TreeMouseDown(object sender, MouseEventArgs e)
        {
            int delta = (int)DateTime.Now.Subtract(lastMouseDown).TotalMilliseconds;
            preventExpand = (delta < SystemInformation.DoubleClickTime);
            lastMouseDown = DateTime.Now;
        }

        private void TreeBeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = preventExpand;
            preventExpand = false;
        }

        private void TreeBeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = preventExpand;
            preventExpand = false;
        }

        private void TreeDragEnter(object sender, DragEventArgs e)
        {
            String[] s = (String[])e.Data.GetData(DataFormats.FileDrop);
            List<String> xmls = new List<String>();
            for (Int32 i = 0; i < s.Length; i++)
            {
                if (s[i].EndsWith(".xml", true, null))
                {
                    xmls.Add(s[i]);
                }
            }
            if (xmls.Count > 0)
            {
                e.Effect = DragDropEffects.Copy;
                this.dropFiles = xmls.ToArray();
            }
            else this.dropFiles = null;
        }

        private void TreeDragOver(object sender, DragEventArgs e)
        {
            if (this.dropFiles != null)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void TreeDragDrop(object sender, DragEventArgs e)
        {
            if (this.dropFiles != null)
            {
                this.pluginMain.AddBuildFiles(this.dropFiles);
            }
        }

    }
}