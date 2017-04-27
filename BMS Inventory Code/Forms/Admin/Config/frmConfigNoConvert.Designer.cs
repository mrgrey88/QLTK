﻿namespace BMS
{
    partial class frmConfigNoConvert
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigNoConvert));
            this.grdVL = new DevExpress.XtraGrid.GridControl();
            this.grvVL = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitQLSX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colUnitTK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdVL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.mnuMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdVL
            // 
            this.grdVL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdVL.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdVL.Location = new System.Drawing.Point(0, 46);
            this.grdVL.MainView = this.grvVL;
            this.grdVL.Name = "grdVL";
            this.grdVL.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemCheckEdit1});
            this.grdVL.Size = new System.Drawing.Size(857, 411);
            this.grdVL.TabIndex = 186;
            this.grdVL.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVL});
            // 
            // grvVL
            // 
            this.grvVL.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvVL.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvVL.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVL.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvVL.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvVL.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvVL.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvVL.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvVL.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVL.ColumnPanelRowHeight = 40;
            this.grvVL.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colCode,
            this.colName,
            this.colUnitQLSX,
            this.colUnitTK});
            this.grvVL.GridControl = this.grdVL;
            this.grvVL.Name = "grvVL";
            this.grvVL.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvVL.OptionsCustomization.AllowRowSizing = true;
            this.grvVL.OptionsView.AllowHtmlDrawHeaders = true;
            this.grvVL.OptionsView.ColumnAutoWidth = false;
            this.grvVL.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.grvVL.OptionsView.RowAutoHeight = true;
            this.grvVL.OptionsView.ShowFooter = true;
            this.grvVL.OptionsView.ShowGroupPanel = false;
            this.grvVL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvVL_KeyDown);
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colCode
            // 
            this.colCode.AppearanceCell.Options.UseTextOptions = true;
            this.colCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCode.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCode.AppearanceHeader.Options.UseFont = true;
            this.colCode.Caption = "Mã vật liệu";
            this.colCode.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colCode.FieldName = "MaterialCode";
            this.colCode.Name = "colCode";
            this.colCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 159;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colName
            // 
            this.colName.AppearanceCell.Options.UseTextOptions = true;
            this.colName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colName.AppearanceHeader.Options.UseFont = true;
            this.colName.Caption = "Tên vật liệu";
            this.colName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colName.FieldName = "MaterialName";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 173;
            // 
            // colUnitQLSX
            // 
            this.colUnitQLSX.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colUnitQLSX.AppearanceHeader.Options.UseFont = true;
            this.colUnitQLSX.AppearanceHeader.Options.UseTextOptions = true;
            this.colUnitQLSX.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUnitQLSX.Caption = "Đơn vị QLSX";
            this.colUnitQLSX.FieldName = "UnitQLSX";
            this.colUnitQLSX.Name = "colUnitQLSX";
            this.colUnitQLSX.Visible = true;
            this.colUnitQLSX.VisibleIndex = 3;
            this.colUnitQLSX.Width = 112;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.DisplayFormat.FormatString = "n0";
            this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.EditFormat.FormatString = "n0";
            this.repositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.Mask.EditMask = "n0";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // colUnitTK
            // 
            this.colUnitTK.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colUnitTK.AppearanceHeader.Options.UseFont = true;
            this.colUnitTK.AppearanceHeader.Options.UseTextOptions = true;
            this.colUnitTK.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUnitTK.Caption = "Đơn vị TK";
            this.colUnitTK.FieldName = "UnitTK";
            this.colUnitTK.Name = "colUnitTK";
            this.colUnitTK.Visible = true;
            this.colUnitTK.VisibleIndex = 2;
            this.colUnitTK.Width = 175;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.toolStripSeparator1,
            this.btnDelete});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(857, 42);
            this.mnuMenu.TabIndex = 185;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(29, 33);
            this.btnSave.Text = "Ghi";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(32, 33);
            this.btnDelete.Tag = "frmConfigSystem_Delete";
            this.btnDelete.Text = "Xóa";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmConfigNoConvert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 457);
            this.Controls.Add(this.grdVL);
            this.Controls.Add(this.mnuMenu);
            this.Name = "frmConfigNoConvert";
            this.Text = "CẤU HÌNH VẬT TƯ NGUỒN KHÔNG CẦN CHUYỂN ĐỔI";
            this.Load += new System.EventHandler(this.frmConfigNoConvert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdVL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdVL;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVL;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitQLSX;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitTK;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnDelete;
    }
}