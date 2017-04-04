namespace BMS
{
    partial class frmShowKcsNG
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowKcsNG));
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnShowDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowĐNNKkhacPhuc = new System.Windows.Forms.ToolStripMenuItem();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalNG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalOK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModuleCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserNameKCS1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProposalCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImportId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHSX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductPartsImportId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplierName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplierCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThanhPham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colBanThanhPham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContentError = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImportCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateCreate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateKCS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiPhuTrach1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExeclGroup = new DevExpress.XtraEditors.SimpleButton();
            this.mnuMenu.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.toolStripSeparator1});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(1196, 42);
            this.mnuMenu.TabIndex = 18;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 34);
            this.btnSave.Tag = "frmShowKcsNG_Complete";
            this.btnSave.Text = "Đã hoàn thành";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowDetail,
            this.btnShowĐNNKkhacPhuc});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(214, 48);
            // 
            // btnShowDetail
            // 
            this.btnShowDetail.Name = "btnShowDetail";
            this.btnShowDetail.Size = new System.Drawing.Size(213, 22);
            this.btnShowDetail.Text = "Xem chi tiết lỗi";
            this.btnShowDetail.Click += new System.EventHandler(this.btnShowDetail_Click);
            // 
            // btnShowĐNNKkhacPhuc
            // 
            this.btnShowĐNNKkhacPhuc.Name = "btnShowĐNNKkhacPhuc";
            this.btnShowĐNNKkhacPhuc.Size = new System.Drawing.Size(213, 22);
            this.btnShowĐNNKkhacPhuc.Text = "Xem các ĐNNK khắc phục";
            this.btnShowĐNNKkhacPhuc.Click += new System.EventHandler(this.btnShowĐNNKkhacPhuc_Click);
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.ContextMenuStrip = this.contextMenuStrip1;
            this.grdData.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.Location = new System.Drawing.Point(0, 45);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoEdit1});
            this.grdData.Size = new System.Drawing.Size(1196, 427);
            this.grdData.TabIndex = 20;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // grvData
            // 
            this.grvData.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvData.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvData.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvData.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvData.ColumnPanelRowHeight = 40;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colCode,
            this.colTotalNG,
            this.colTotal,
            this.colTotalOK,
            this.colProjectCode,
            this.colModuleCode,
            this.colUserNameKCS1,
            this.colProposalCode,
            this.colImportId,
            this.colUnit,
            this.colHSX,
            this.colProductPartsImportId,
            this.colOrderCode,
            this.colGroup,
            this.colSupplierName,
            this.colSupplierCode,
            this.colThanhPham,
            this.colBanThanhPham,
            this.colNote,
            this.colContentError,
            this.colYear,
            this.colMonth,
            this.colImportCode,
            this.colDateCreate,
            this.colDateKCS,
            this.colNguoiPhuTrach1,
            this.colStatus});
            this.grvData.GridControl = this.grdData;
            this.grvData.GroupCount = 2;
            this.grvData.HorzScrollStep = 5;
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvData.OptionsCustomization.AllowRowSizing = true;
            this.grvData.OptionsFind.AlwaysVisible = true;
            this.grvData.OptionsFind.ShowCloseButton = false;
            this.grvData.OptionsSelection.MultiSelect = true;
            this.grvData.OptionsView.ColumnAutoWidth = false;
            this.grvData.OptionsView.RowAutoHeight = true;
            this.grvData.OptionsView.ShowAutoFilterRow = true;
            this.grvData.OptionsView.ShowFooter = true;
            this.grvData.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colYear, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMonth, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colName
            // 
            this.colName.AppearanceCell.Options.UseTextOptions = true;
            this.colName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colName.AppearanceHeader.Options.UseFont = true;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colName.Caption = "Tên vật tư";
            this.colName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colName.FieldName = "PartsName";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowSize = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 151;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colCode
            // 
            this.colCode.AppearanceCell.Options.UseTextOptions = true;
            this.colCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCode.AppearanceHeader.Options.UseFont = true;
            this.colCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCode.Caption = "Mã vật tư";
            this.colCode.FieldName = "PartsCode";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "PartsCode", "{0:n0}")});
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 163;
            // 
            // colTotalNG
            // 
            this.colTotalNG.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalNG.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalNG.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalNG.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalNG.AppearanceHeader.Options.UseFont = true;
            this.colTotalNG.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalNG.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalNG.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalNG.Caption = "Không đạt";
            this.colTotalNG.DisplayFormat.FormatString = "n0";
            this.colTotalNG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalNG.FieldName = "TotalNG";
            this.colTotalNG.Name = "colTotalNG";
            this.colTotalNG.OptionsColumn.AllowEdit = false;
            this.colTotalNG.OptionsColumn.AllowSize = false;
            this.colTotalNG.Visible = true;
            this.colTotalNG.VisibleIndex = 9;
            this.colTotalNG.Width = 52;
            // 
            // colTotal
            // 
            this.colTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colTotal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotal.AppearanceHeader.Options.UseFont = true;
            this.colTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotal.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotal.Caption = "Số lượng";
            this.colTotal.DisplayFormat.FormatString = "n0";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 7;
            this.colTotal.Width = 50;
            // 
            // colTotalOK
            // 
            this.colTotalOK.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalOK.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalOK.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalOK.AppearanceHeader.Options.UseFont = true;
            this.colTotalOK.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalOK.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalOK.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalOK.Caption = "Đạt";
            this.colTotalOK.DisplayFormat.FormatString = "n0";
            this.colTotalOK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalOK.FieldName = "TotalOK";
            this.colTotalOK.Name = "colTotalOK";
            this.colTotalOK.OptionsColumn.AllowEdit = false;
            this.colTotalOK.Visible = true;
            this.colTotalOK.VisibleIndex = 8;
            this.colTotalOK.Width = 45;
            // 
            // colProjectCode
            // 
            this.colProjectCode.AppearanceCell.Options.UseTextOptions = true;
            this.colProjectCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProjectCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colProjectCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colProjectCode.AppearanceHeader.Options.UseFont = true;
            this.colProjectCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colProjectCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProjectCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProjectCode.Caption = "Dự án";
            this.colProjectCode.FieldName = "ProjectCode";
            this.colProjectCode.Name = "colProjectCode";
            this.colProjectCode.OptionsColumn.AllowEdit = false;
            this.colProjectCode.Visible = true;
            this.colProjectCode.VisibleIndex = 5;
            // 
            // colModuleCode
            // 
            this.colModuleCode.AppearanceCell.Options.UseTextOptions = true;
            this.colModuleCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colModuleCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colModuleCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colModuleCode.AppearanceHeader.Options.UseFont = true;
            this.colModuleCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colModuleCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colModuleCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colModuleCode.Caption = "Module";
            this.colModuleCode.FieldName = "ProjectModuleCode";
            this.colModuleCode.Name = "colModuleCode";
            this.colModuleCode.OptionsColumn.AllowEdit = false;
            this.colModuleCode.Visible = true;
            this.colModuleCode.VisibleIndex = 6;
            // 
            // colUserNameKCS1
            // 
            this.colUserNameKCS1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colUserNameKCS1.AppearanceHeader.Options.UseFont = true;
            this.colUserNameKCS1.AppearanceHeader.Options.UseTextOptions = true;
            this.colUserNameKCS1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserNameKCS1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUserNameKCS1.Caption = "Nhân viên KCS";
            this.colUserNameKCS1.FieldName = "UserNameKCS";
            this.colUserNameKCS1.Name = "colUserNameKCS1";
            this.colUserNameKCS1.OptionsColumn.AllowEdit = false;
            this.colUserNameKCS1.Visible = true;
            this.colUserNameKCS1.VisibleIndex = 10;
            this.colUserNameKCS1.Width = 93;
            // 
            // colProposalCode
            // 
            this.colProposalCode.AppearanceCell.Options.UseTextOptions = true;
            this.colProposalCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colProposalCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colProposalCode.AppearanceHeader.Options.UseFont = true;
            this.colProposalCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colProposalCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProposalCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProposalCode.Caption = "Số YCMVT";
            this.colProposalCode.FieldName = "ProposalCode";
            this.colProposalCode.Name = "colProposalCode";
            this.colProposalCode.OptionsColumn.AllowEdit = false;
            this.colProposalCode.Visible = true;
            this.colProposalCode.VisibleIndex = 12;
            this.colProposalCode.Width = 119;
            // 
            // colImportId
            // 
            this.colImportId.AppearanceCell.Options.UseTextOptions = true;
            this.colImportId.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colImportId.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colImportId.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colImportId.AppearanceHeader.Options.UseFont = true;
            this.colImportId.AppearanceHeader.Options.UseTextOptions = true;
            this.colImportId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colImportId.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colImportId.Caption = "ImportId";
            this.colImportId.FieldName = "ImportId";
            this.colImportId.Name = "colImportId";
            this.colImportId.OptionsColumn.AllowEdit = false;
            this.colImportId.OptionsColumn.AllowSize = false;
            this.colImportId.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colImportId.Width = 43;
            // 
            // colUnit
            // 
            this.colUnit.AppearanceCell.Options.UseTextOptions = true;
            this.colUnit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUnit.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colUnit.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colUnit.AppearanceHeader.Options.UseFont = true;
            this.colUnit.AppearanceHeader.Options.UseTextOptions = true;
            this.colUnit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUnit.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUnit.Caption = "Đơn vị";
            this.colUnit.FieldName = "Unit";
            this.colUnit.Name = "colUnit";
            this.colUnit.OptionsColumn.AllowEdit = false;
            this.colUnit.OptionsColumn.AllowSize = false;
            this.colUnit.Width = 52;
            // 
            // colHSX
            // 
            this.colHSX.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colHSX.AppearanceHeader.Options.UseFont = true;
            this.colHSX.AppearanceHeader.Options.UseTextOptions = true;
            this.colHSX.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHSX.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHSX.Caption = "Hãng sản xuất";
            this.colHSX.FieldName = "ManufacturerCode";
            this.colHSX.Name = "colHSX";
            this.colHSX.OptionsColumn.AllowEdit = false;
            this.colHSX.Visible = true;
            this.colHSX.VisibleIndex = 16;
            // 
            // colProductPartsImportId
            // 
            this.colProductPartsImportId.AppearanceCell.Options.UseTextOptions = true;
            this.colProductPartsImportId.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colProductPartsImportId.AppearanceHeader.Options.UseTextOptions = true;
            this.colProductPartsImportId.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProductPartsImportId.Caption = "ID";
            this.colProductPartsImportId.FieldName = "ProductPartsImportId";
            this.colProductPartsImportId.Name = "colProductPartsImportId";
            this.colProductPartsImportId.OptionsColumn.AllowEdit = false;
            // 
            // colOrderCode
            // 
            this.colOrderCode.AppearanceCell.Options.UseTextOptions = true;
            this.colOrderCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colOrderCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colOrderCode.AppearanceHeader.Options.UseFont = true;
            this.colOrderCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colOrderCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOrderCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colOrderCode.Caption = "PO";
            this.colOrderCode.FieldName = "OrderCode";
            this.colOrderCode.Name = "colOrderCode";
            this.colOrderCode.OptionsColumn.AllowEdit = false;
            this.colOrderCode.Visible = true;
            this.colOrderCode.VisibleIndex = 4;
            this.colOrderCode.Width = 110;
            // 
            // colGroup
            // 
            this.colGroup.AppearanceCell.Options.UseTextOptions = true;
            this.colGroup.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colGroup.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroup.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colGroup.Caption = "Nhóm";
            this.colGroup.FieldName = "ModuleGroupID";
            this.colGroup.Name = "colGroup";
            this.colGroup.OptionsColumn.AllowEdit = false;
            // 
            // colSupplierName
            // 
            this.colSupplierName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colSupplierName.AppearanceHeader.Options.UseFont = true;
            this.colSupplierName.AppearanceHeader.Options.UseTextOptions = true;
            this.colSupplierName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSupplierName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSupplierName.Caption = "Nhà cung cấp";
            this.colSupplierName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colSupplierName.FieldName = "SupplierName";
            this.colSupplierName.Name = "colSupplierName";
            this.colSupplierName.OptionsColumn.AllowEdit = false;
            this.colSupplierName.OptionsColumn.AllowSize = false;
            this.colSupplierName.Visible = true;
            this.colSupplierName.VisibleIndex = 15;
            this.colSupplierName.Width = 200;
            // 
            // colSupplierCode
            // 
            this.colSupplierCode.Caption = "SupplierCode";
            this.colSupplierCode.FieldName = "SupplierCode";
            this.colSupplierCode.Name = "colSupplierCode";
            this.colSupplierCode.OptionsColumn.AllowEdit = false;
            // 
            // colThanhPham
            // 
            this.colThanhPham.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colThanhPham.AppearanceHeader.Options.UseFont = true;
            this.colThanhPham.AppearanceHeader.Options.UseTextOptions = true;
            this.colThanhPham.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colThanhPham.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colThanhPham.Caption = "Thành phẩm";
            this.colThanhPham.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colThanhPham.FieldName = "IsFull";
            this.colThanhPham.Name = "colThanhPham";
            this.colThanhPham.OptionsColumn.AllowEdit = false;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.DisplayValueChecked = "\"1\"";
            this.repositoryItemCheckEdit1.DisplayValueUnchecked = "\"0\"";
            this.repositoryItemCheckEdit1.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colBanThanhPham
            // 
            this.colBanThanhPham.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colBanThanhPham.AppearanceHeader.Options.UseFont = true;
            this.colBanThanhPham.AppearanceHeader.Options.UseTextOptions = true;
            this.colBanThanhPham.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBanThanhPham.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colBanThanhPham.Caption = "Bán thành phẩm";
            this.colBanThanhPham.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colBanThanhPham.FieldName = "IsHalf";
            this.colBanThanhPham.Name = "colBanThanhPham";
            this.colBanThanhPham.OptionsColumn.AllowEdit = false;
            // 
            // colNote
            // 
            this.colNote.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNote.AppearanceHeader.Options.UseFont = true;
            this.colNote.AppearanceHeader.Options.UseTextOptions = true;
            this.colNote.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNote.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNote.Caption = "Ghi chú";
            this.colNote.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.OptionsColumn.AllowEdit = false;
            this.colNote.Width = 300;
            // 
            // colContentError
            // 
            this.colContentError.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colContentError.AppearanceHeader.Options.UseFont = true;
            this.colContentError.AppearanceHeader.Options.UseTextOptions = true;
            this.colContentError.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colContentError.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colContentError.Caption = "Nội dung lỗi";
            this.colContentError.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colContentError.Name = "colContentError";
            this.colContentError.OptionsColumn.AllowEdit = false;
            this.colContentError.OptionsColumn.AllowSize = false;
            this.colContentError.Width = 134;
            // 
            // colYear
            // 
            this.colYear.AppearanceCell.Options.UseTextOptions = true;
            this.colYear.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colYear.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colYear.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colYear.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colYear.AppearanceHeader.Options.UseFont = true;
            this.colYear.AppearanceHeader.Options.UseTextOptions = true;
            this.colYear.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colYear.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colYear.Caption = "Năm";
            this.colYear.FieldName = "Year";
            this.colYear.Name = "colYear";
            this.colYear.OptionsColumn.AllowEdit = false;
            this.colYear.Width = 60;
            // 
            // colMonth
            // 
            this.colMonth.AppearanceCell.Options.UseTextOptions = true;
            this.colMonth.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMonth.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMonth.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMonth.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMonth.AppearanceHeader.Options.UseFont = true;
            this.colMonth.AppearanceHeader.Options.UseTextOptions = true;
            this.colMonth.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMonth.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMonth.Caption = "Tháng";
            this.colMonth.FieldName = "Month";
            this.colMonth.Name = "colMonth";
            this.colMonth.OptionsColumn.AllowEdit = false;
            this.colMonth.Width = 60;
            // 
            // colImportCode
            // 
            this.colImportCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colImportCode.AppearanceHeader.Options.UseFont = true;
            this.colImportCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colImportCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colImportCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colImportCode.Caption = "ĐNNK";
            this.colImportCode.FieldName = "ImportCode";
            this.colImportCode.Name = "colImportCode";
            this.colImportCode.OptionsColumn.AllowEdit = false;
            this.colImportCode.Visible = true;
            this.colImportCode.VisibleIndex = 3;
            this.colImportCode.Width = 90;
            // 
            // colDateCreate
            // 
            this.colDateCreate.AppearanceCell.Options.UseTextOptions = true;
            this.colDateCreate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDateCreate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDateCreate.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDateCreate.AppearanceHeader.Options.UseFont = true;
            this.colDateCreate.AppearanceHeader.Options.UseTextOptions = true;
            this.colDateCreate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDateCreate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDateCreate.Caption = "Ngày tạo";
            this.colDateCreate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colDateCreate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDateCreate.FieldName = "DateCreate";
            this.colDateCreate.Name = "colDateCreate";
            this.colDateCreate.OptionsColumn.AllowEdit = false;
            this.colDateCreate.Visible = true;
            this.colDateCreate.VisibleIndex = 13;
            // 
            // colDateKCS
            // 
            this.colDateKCS.AppearanceCell.Options.UseTextOptions = true;
            this.colDateKCS.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDateKCS.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDateKCS.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDateKCS.AppearanceHeader.Options.UseFont = true;
            this.colDateKCS.AppearanceHeader.Options.UseTextOptions = true;
            this.colDateKCS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDateKCS.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDateKCS.Caption = "Ngày KCS";
            this.colDateKCS.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colDateKCS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDateKCS.FieldName = "DateKCS";
            this.colDateKCS.Name = "colDateKCS";
            this.colDateKCS.OptionsColumn.AllowEdit = false;
            this.colDateKCS.Visible = true;
            this.colDateKCS.VisibleIndex = 14;
            this.colDateKCS.Width = 104;
            // 
            // colNguoiPhuTrach1
            // 
            this.colNguoiPhuTrach1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNguoiPhuTrach1.AppearanceHeader.Options.UseFont = true;
            this.colNguoiPhuTrach1.AppearanceHeader.Options.UseTextOptions = true;
            this.colNguoiPhuTrach1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNguoiPhuTrach1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNguoiPhuTrach1.Caption = "Người phụ trách";
            this.colNguoiPhuTrach1.FieldName = "UserNameDNNK";
            this.colNguoiPhuTrach1.Name = "colNguoiPhuTrach1";
            this.colNguoiPhuTrach1.OptionsColumn.AllowEdit = false;
            this.colNguoiPhuTrach1.Visible = true;
            this.colNguoiPhuTrach1.VisibleIndex = 11;
            this.colNguoiPhuTrach1.Width = 109;
            // 
            // colStatus
            // 
            this.colStatus.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colStatus.AppearanceHeader.Options.UseFont = true;
            this.colStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStatus.Caption = "Đã hoàn thành";
            this.colStatus.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colStatus.FieldName = "IsCompleted";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 2;
            this.colStatus.Width = 59;
            // 
            // btnExeclGroup
            // 
            this.btnExeclGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExeclGroup.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnExeclGroup.Appearance.Options.UseFont = true;
            this.btnExeclGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnExeclGroup.Image")));
            this.btnExeclGroup.Location = new System.Drawing.Point(1072, 52);
            this.btnExeclGroup.Name = "btnExeclGroup";
            this.btnExeclGroup.Size = new System.Drawing.Size(104, 32);
            this.btnExeclGroup.TabIndex = 28;
            this.btnExeclGroup.Text = "Xuất excel";
            this.btnExeclGroup.Click += new System.EventHandler(this.btnExeclGroup_Click);
            // 
            // frmShowKcsNG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 474);
            this.Controls.Add(this.btnExeclGroup);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.mnuMenu);
            this.Name = "frmShowKcsNG";
            this.Text = "BÁO CÁO LỖI KCS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmShowKcsNG_Load);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnShowDetail;
        private System.Windows.Forms.ToolStripMenuItem btnShowĐNNKkhacPhuc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalNG;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalOK;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn colModuleCode;
        private DevExpress.XtraGrid.Columns.GridColumn colUserNameKCS1;
        private DevExpress.XtraGrid.Columns.GridColumn colProposalCode;
        private DevExpress.XtraGrid.Columns.GridColumn colImportId;
        private DevExpress.XtraGrid.Columns.GridColumn colUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colHSX;
        private DevExpress.XtraGrid.Columns.GridColumn colProductPartsImportId;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderCode;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierName;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierCode;
        private DevExpress.XtraGrid.Columns.GridColumn colThanhPham;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colBanThanhPham;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colContentError;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colImportCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDateCreate;
        private DevExpress.XtraGrid.Columns.GridColumn colDateKCS;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiPhuTrach1;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.SimpleButton btnExeclGroup;
    }
}