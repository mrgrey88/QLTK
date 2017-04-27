﻿namespace BMS
{
    partial class frmImportErrorPart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportErrorPart));
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValueResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colIsHalf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colError = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colCriteriaImportId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdFile = new DevExpress.XtraGrid.GridControl();
            this.grvFile = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFileID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colFileSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFilePath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileLocalPath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStripFile = new System.Windows.Forms.ToolStrip();
            this.btnAddFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDeleteFile = new System.Windows.Forms.ToolStripButton();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            this.toolStripFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(910, 42);
            this.mnuMenu.TabIndex = 19;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 34);
            this.btnSave.Tag = "frmImportRequrieManager_CompletedKCS";
            this.btnSave.Text = "Hoàn thành KCS";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.Location = new System.Drawing.Point(0, 45);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemHyperLinkEdit1});
            this.grdData.Size = new System.Drawing.Size(578, 383);
            this.grdData.TabIndex = 20;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // grvData
            // 
            this.grvData.ColumnPanelRowHeight = 40;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTT,
            this.colValueResult,
            this.colStatus,
            this.colIsHalf,
            this.colError,
            this.colCriteriaImportId});
            this.grvData.GridControl = this.grdData;
            this.grvData.Name = "grvData";
            this.grvData.OptionsSelection.MultiSelect = true;
            this.grvData.OptionsView.ColumnAutoWidth = false;
            this.grvData.OptionsView.RowAutoHeight = true;
            this.grvData.OptionsView.ShowFooter = true;
            this.grvData.OptionsView.ShowGroupPanel = false;
            this.grvData.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvData_FocusedRowChanged);
            // 
            // colSTT
            // 
            this.colSTT.AppearanceCell.Options.UseTextOptions = true;
            this.colSTT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSTT.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSTT.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSTT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colSTT.AppearanceHeader.Options.UseFont = true;
            this.colSTT.AppearanceHeader.Options.UseTextOptions = true;
            this.colSTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSTT.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSTT.Caption = "STT";
            this.colSTT.FieldName = "CriteriaIndex";
            this.colSTT.Name = "colSTT";
            this.colSTT.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CriteriaIndex", "{0:n0}")});
            this.colSTT.Visible = true;
            this.colSTT.VisibleIndex = 0;
            this.colSTT.Width = 39;
            // 
            // colValueResult
            // 
            this.colValueResult.AppearanceCell.Options.UseTextOptions = true;
            this.colValueResult.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colValueResult.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValueResult.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colValueResult.AppearanceHeader.Options.UseFont = true;
            this.colValueResult.AppearanceHeader.Options.UseTextOptions = true;
            this.colValueResult.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValueResult.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValueResult.Caption = "Nội dung";
            this.colValueResult.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colValueResult.FieldName = "ValueResult";
            this.colValueResult.Name = "colValueResult";
            this.colValueResult.Visible = true;
            this.colValueResult.VisibleIndex = 1;
            this.colValueResult.Width = 297;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colStatus
            // 
            this.colStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colStatus.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStatus.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStatus.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colStatus.AppearanceHeader.Options.UseFont = true;
            this.colStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStatus.Caption = "Kết quả";
            this.colStatus.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colStatus.FieldName = "Status1";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 2;
            this.colStatus.Width = 43;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colIsHalf
            // 
            this.colIsHalf.AppearanceCell.Options.UseTextOptions = true;
            this.colIsHalf.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colIsHalf.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colIsHalf.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colIsHalf.AppearanceHeader.Options.UseFont = true;
            this.colIsHalf.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsHalf.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsHalf.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colIsHalf.Caption = "Bán thành phẩm";
            this.colIsHalf.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colIsHalf.FieldName = "IsHalf";
            this.colIsHalf.Name = "colIsHalf";
            this.colIsHalf.Width = 76;
            // 
            // colError
            // 
            this.colError.AppearanceCell.Options.UseTextOptions = true;
            this.colError.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colError.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colError.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colError.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colError.AppearanceHeader.Options.UseFont = true;
            this.colError.AppearanceHeader.Options.UseTextOptions = true;
            this.colError.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colError.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colError.Caption = "Báo lỗi";
            this.colError.ColumnEdit = this.repositoryItemHyperLinkEdit1;
            this.colError.FieldName = "Error";
            this.colError.Name = "colError";
            this.colError.Visible = true;
            this.colError.VisibleIndex = 3;
            this.colError.Width = 69;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.repositoryItemHyperLinkEdit1.DoubleClick += new System.EventHandler(this.repositoryItemHyperLinkEdit1_DoubleClick);
            // 
            // colCriteriaImportId
            // 
            this.colCriteriaImportId.Caption = "CriteriaImportId";
            this.colCriteriaImportId.FieldName = "CriteriaImportId";
            this.colCriteriaImportId.Name = "colCriteriaImportId";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Báo lỗi";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 69;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.grdFile);
            this.groupBox1.Controls.Add(this.toolStripFile);
            this.groupBox1.Location = new System.Drawing.Point(581, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 383);
            this.groupBox1.TabIndex = 192;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách ảnh lỗi";
            // 
            // grdFile
            // 
            this.grdFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFile.Location = new System.Drawing.Point(3, 57);
            this.grdFile.MainView = this.grvFile;
            this.grdFile.Name = "grdFile";
            this.grdFile.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit2});
            this.grdFile.Size = new System.Drawing.Size(320, 326);
            this.grdFile.TabIndex = 3;
            this.grdFile.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFile});
            // 
            // grvFile
            // 
            this.grvFile.ColumnPanelRowHeight = 40;
            this.grvFile.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFileID,
            this.colFileName,
            this.colFileSize,
            this.colFileCreatedDate,
            this.colFilePath,
            this.colFileLocalPath});
            this.grvFile.GridControl = this.grdFile;
            this.grvFile.Name = "grvFile";
            this.grvFile.OptionsView.ColumnAutoWidth = false;
            this.grvFile.OptionsView.RowAutoHeight = true;
            this.grvFile.OptionsView.ShowGroupPanel = false;
            this.grvFile.DoubleClick += new System.EventHandler(this.grvFile_DoubleClick);
            // 
            // colFileID
            // 
            this.colFileID.Caption = "ID";
            this.colFileID.FieldName = "ID";
            this.colFileID.Name = "colFileID";
            // 
            // colFileName
            // 
            this.colFileName.AppearanceCell.Options.UseTextOptions = true;
            this.colFileName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colFileName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colFileName.AppearanceHeader.Options.UseFont = true;
            this.colFileName.AppearanceHeader.Options.UseTextOptions = true;
            this.colFileName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFileName.Caption = "Tên file";
            this.colFileName.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colFileName.FieldName = "FileName";
            this.colFileName.Name = "colFileName";
            this.colFileName.OptionsColumn.AllowEdit = false;
            this.colFileName.OptionsColumn.AllowFocus = false;
            this.colFileName.OptionsColumn.AllowSize = false;
            this.colFileName.Visible = true;
            this.colFileName.VisibleIndex = 0;
            this.colFileName.Width = 145;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // colFileSize
            // 
            this.colFileSize.AppearanceCell.Options.UseTextOptions = true;
            this.colFileSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFileSize.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colFileSize.AppearanceHeader.Options.UseFont = true;
            this.colFileSize.AppearanceHeader.Options.UseTextOptions = true;
            this.colFileSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFileSize.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colFileSize.Caption = "Dung lượng";
            this.colFileSize.FieldName = "Size";
            this.colFileSize.Name = "colFileSize";
            this.colFileSize.OptionsColumn.AllowEdit = false;
            this.colFileSize.OptionsColumn.AllowFocus = false;
            this.colFileSize.OptionsColumn.AllowSize = false;
            this.colFileSize.Visible = true;
            this.colFileSize.VisibleIndex = 1;
            this.colFileSize.Width = 68;
            // 
            // colFileCreatedDate
            // 
            this.colFileCreatedDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colFileCreatedDate.AppearanceHeader.Options.UseFont = true;
            this.colFileCreatedDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colFileCreatedDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFileCreatedDate.Caption = "Ngày tạo";
            this.colFileCreatedDate.FieldName = "DateCreated";
            this.colFileCreatedDate.Name = "colFileCreatedDate";
            this.colFileCreatedDate.OptionsColumn.AllowEdit = false;
            this.colFileCreatedDate.OptionsColumn.AllowFocus = false;
            this.colFileCreatedDate.OptionsColumn.AllowSize = false;
            this.colFileCreatedDate.Visible = true;
            this.colFileCreatedDate.VisibleIndex = 2;
            // 
            // colFilePath
            // 
            this.colFilePath.Caption = "Path";
            this.colFilePath.FieldName = "FilePath";
            this.colFilePath.Name = "colFilePath";
            // 
            // colFileLocalPath
            // 
            this.colFileLocalPath.Caption = "LocalPath";
            this.colFileLocalPath.FieldName = "FileLocalPath";
            this.colFileLocalPath.Name = "colFileLocalPath";
            // 
            // toolStripFile
            // 
            this.toolStripFile.AutoSize = false;
            this.toolStripFile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripFile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripFile.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddFile,
            this.toolStripSeparator5,
            this.btnDeleteFile});
            this.toolStripFile.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStripFile.Location = new System.Drawing.Point(3, 16);
            this.toolStripFile.Name = "toolStripFile";
            this.toolStripFile.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStripFile.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripFile.Size = new System.Drawing.Size(323, 35);
            this.toolStripFile.TabIndex = 166;
            this.toolStripFile.Text = "toolStrip2";
            // 
            // btnAddFile
            // 
            this.btnAddFile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFile.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFile.Image")));
            this.btnAddFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(63, 33);
            this.btnAddFile.Tag = "frmImportRequrieManager_CompletedKCS";
            this.btnAddFile.Text = "Thêm file";
            this.btnAddFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteFile.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteFile.Image")));
            this.btnDeleteFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(52, 33);
            this.btnDeleteFile.Tag = "frmImportRequrieManager_CompletedKCS";
            this.btnDeleteFile.Text = "Xóa file";
            this.btnDeleteFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // chkAll
            // 
            this.chkAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(835, 12);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(63, 17);
            this.chkAll.TabIndex = 193;
            this.chkAll.Text = "Kết quả";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // frmImportErrorPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 429);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.mnuMenu);
            this.Name = "frmImportErrorPart";
            this.Text = "HOÀN THÀNH KCS";
            this.Load += new System.EventHandler(this.frmImportError_Load);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            this.toolStripFile.ResumeLayout(false);
            this.toolStripFile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnSave;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT;
        private DevExpress.XtraGrid.Columns.GridColumn colValueResult;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colIsHalf;
        private DevExpress.XtraGrid.Columns.GridColumn colError;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl grdFile;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFile;
        private DevExpress.XtraGrid.Columns.GridColumn colFileID;
        private DevExpress.XtraGrid.Columns.GridColumn colFileName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colFileSize;
        private DevExpress.XtraGrid.Columns.GridColumn colFileCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colFilePath;
        private DevExpress.XtraGrid.Columns.GridColumn colFileLocalPath;
        private System.Windows.Forms.ToolStrip toolStripFile;
        private System.Windows.Forms.ToolStripButton btnAddFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnDeleteFile;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colCriteriaImportId;
        private System.Windows.Forms.CheckBox chkAll;
    }
}