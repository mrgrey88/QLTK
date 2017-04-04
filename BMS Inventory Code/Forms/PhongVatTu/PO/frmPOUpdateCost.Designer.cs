namespace BMS
{
    partial class frmPOUpdateCost
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOUpdateCost));
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeliveryCost = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiffCost = new DevExpress.XtraEditors.TextEdit();
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.txtVAT = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnDelete = new System.Windows.Forms.Button();
            this.grdYC = new DevExpress.XtraGrid.GridControl();
            this.grvYC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPayPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalYC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colTotalTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequirePaymentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colStatusText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTranVAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.txtTotalNCC = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.chkIsTranferAfterVAT = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeliveryCost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiffCost.Properties)).BeginInit();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVAT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdYC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvYC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalNCC.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 205;
            this.label2.Text = "Chi phí vận chuyển";
            // 
            // txtDeliveryCost
            // 
            this.txtDeliveryCost.Location = new System.Drawing.Point(115, 48);
            this.txtDeliveryCost.Name = "txtDeliveryCost";
            this.txtDeliveryCost.Properties.DisplayFormat.FormatString = "n2";
            this.txtDeliveryCost.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDeliveryCost.Properties.Mask.EditMask = "n2";
            this.txtDeliveryCost.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDeliveryCost.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDeliveryCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDeliveryCost.Size = new System.Drawing.Size(175, 20);
            this.txtDeliveryCost.TabIndex = 203;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 208;
            this.label4.Text = "Chi phí khác";
            // 
            // txtDiffCost
            // 
            this.txtDiffCost.Location = new System.Drawing.Point(115, 76);
            this.txtDiffCost.Name = "txtDiffCost";
            this.txtDiffCost.Properties.DisplayFormat.FormatString = "{0:n2}";
            this.txtDiffCost.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDiffCost.Properties.Mask.EditMask = "n2";
            this.txtDiffCost.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDiffCost.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDiffCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDiffCost.Size = new System.Drawing.Size(175, 20);
            this.txtDiffCost.TabIndex = 206;
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
            this.mnuMenu.Size = new System.Drawing.Size(1036, 41);
            this.mnuMenu.TabIndex = 210;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(29, 33);
            this.btnSave.Tag = "";
            this.btnSave.Text = "Ghi";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtVAT
            // 
            this.txtVAT.Location = new System.Drawing.Point(407, 48);
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Properties.DisplayFormat.FormatString = "{0:n2}";
            this.txtVAT.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtVAT.Properties.Mask.EditMask = "n2";
            this.txtVAT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtVAT.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtVAT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtVAT.Size = new System.Drawing.Size(175, 20);
            this.txtVAT.TabIndex = 206;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(375, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 208;
            this.label1.Text = "VAT";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(649, 51);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(380, 45);
            this.txtDescription.TabIndex = 213;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(601, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 208;
            this.label7.Text = "Ghi chú";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.btnDelete);
            this.groupControl2.Controls.Add(this.grdYC);
            this.groupControl2.Location = new System.Drawing.Point(0, 127);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1036, 336);
            this.groupControl2.TabIndex = 215;
            this.groupControl2.Text = "Danh sách các lần yêu cầu thanh toán";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(975, 26);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(54, 22);
            this.btnDelete.TabIndex = 152;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // grdYC
            // 
            this.grdYC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdYC.Location = new System.Drawing.Point(4, 53);
            this.grdYC.MainView = this.grvYC;
            this.grdYC.Name = "grdYC";
            this.grdYC.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemMemoEdit2,
            this.repositoryItemLookUpEdit1,
            this.repositoryItemLookUpEdit2,
            this.repositoryItemTextEdit1,
            this.repositoryItemCheckEdit1});
            this.grdYC.Size = new System.Drawing.Size(1029, 278);
            this.grdYC.TabIndex = 150;
            this.grdYC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvYC});
            // 
            // grvYC
            // 
            this.grvYC.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvYC.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvYC.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvYC.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvYC.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvYC.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvYC.ColumnPanelRowHeight = 40;
            this.grvYC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colSTT,
            this.colPayPercent,
            this.colTotalYC,
            this.colTotalTT,
            this.colRequirePaymentDate,
            this.colPaymentDate,
            this.colPaymentType,
            this.colStatusText,
            this.colStatus,
            this.colTranVAT});
            this.grvYC.GridControl = this.grdYC;
            this.grvYC.Name = "grvYC";
            this.grvYC.OptionsMenu.EnableFooterMenu = false;
            this.grvYC.OptionsMenu.EnableGroupPanelMenu = false;
            this.grvYC.OptionsView.ColumnAutoWidth = false;
            this.grvYC.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.grvYC.OptionsView.RowAutoHeight = true;
            this.grvYC.OptionsView.ShowGroupPanel = false;
            this.grvYC.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colRequirePaymentDate, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvYC.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvYC_CellValueChanged);
            // 
            // colID
            // 
            this.colID.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colID.AppearanceHeader.Options.UseFont = true;
            this.colID.AppearanceHeader.Options.UseTextOptions = true;
            this.colID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colSTT
            // 
            this.colSTT.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colSTT.AppearanceHeader.Options.UseFont = true;
            this.colSTT.AppearanceHeader.Options.UseTextOptions = true;
            this.colSTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSTT.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSTT.Caption = "STT";
            this.colSTT.FieldName = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.Width = 41;
            // 
            // colPayPercent
            // 
            this.colPayPercent.AppearanceCell.Options.UseTextOptions = true;
            this.colPayPercent.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPayPercent.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPayPercent.AppearanceHeader.Options.UseFont = true;
            this.colPayPercent.AppearanceHeader.Options.UseTextOptions = true;
            this.colPayPercent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPayPercent.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPayPercent.Caption = "%TT";
            this.colPayPercent.FieldName = "PayPercent";
            this.colPayPercent.Name = "colPayPercent";
            this.colPayPercent.OptionsColumn.AllowSize = false;
            this.colPayPercent.Visible = true;
            this.colPayPercent.VisibleIndex = 0;
            this.colPayPercent.Width = 74;
            // 
            // colTotalYC
            // 
            this.colTotalYC.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalYC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalYC.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalYC.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTotalYC.AppearanceHeader.Options.UseFont = true;
            this.colTotalYC.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalYC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalYC.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalYC.Caption = "Tổng tiền YCTT";
            this.colTotalYC.ColumnEdit = this.repositoryItemTextEdit1;
            this.colTotalYC.DisplayFormat.FormatString = "n0";
            this.colTotalYC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalYC.FieldName = "TotalPay";
            this.colTotalYC.Name = "colTotalYC";
            this.colTotalYC.OptionsColumn.AllowEdit = false;
            this.colTotalYC.Visible = true;
            this.colTotalYC.VisibleIndex = 1;
            this.colTotalYC.Width = 121;
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
            // colTotalTT
            // 
            this.colTotalTT.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalTT.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalTT.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTotalTT.AppearanceHeader.Options.UseFont = true;
            this.colTotalTT.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalTT.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalTT.Caption = "Tổng tiền TT";
            this.colTotalTT.FieldName = "Currency";
            this.colTotalTT.Name = "colTotalTT";
            this.colTotalTT.OptionsColumn.AllowEdit = false;
            this.colTotalTT.Visible = true;
            this.colTotalTT.VisibleIndex = 4;
            this.colTotalTT.Width = 127;
            // 
            // colRequirePaymentDate
            // 
            this.colRequirePaymentDate.AppearanceCell.Options.UseTextOptions = true;
            this.colRequirePaymentDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colRequirePaymentDate.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colRequirePaymentDate.AppearanceHeader.Options.UseFont = true;
            this.colRequirePaymentDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colRequirePaymentDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRequirePaymentDate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colRequirePaymentDate.Caption = "Ngày YC";
            this.colRequirePaymentDate.FieldName = "RequirePaymentDate";
            this.colRequirePaymentDate.Name = "colRequirePaymentDate";
            this.colRequirePaymentDate.Visible = true;
            this.colRequirePaymentDate.VisibleIndex = 3;
            this.colRequirePaymentDate.Width = 114;
            // 
            // colPaymentDate
            // 
            this.colPaymentDate.AppearanceCell.Options.UseTextOptions = true;
            this.colPaymentDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPaymentDate.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPaymentDate.AppearanceHeader.Options.UseFont = true;
            this.colPaymentDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colPaymentDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPaymentDate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPaymentDate.Caption = "Ngày TT";
            this.colPaymentDate.FieldName = "TransferDate";
            this.colPaymentDate.Name = "colPaymentDate";
            this.colPaymentDate.OptionsColumn.AllowEdit = false;
            this.colPaymentDate.Visible = true;
            this.colPaymentDate.VisibleIndex = 6;
            this.colPaymentDate.Width = 98;
            // 
            // colPaymentType
            // 
            this.colPaymentType.AppearanceCell.Options.UseTextOptions = true;
            this.colPaymentType.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPaymentType.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPaymentType.AppearanceHeader.Options.UseFont = true;
            this.colPaymentType.AppearanceHeader.Options.UseTextOptions = true;
            this.colPaymentType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPaymentType.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPaymentType.Caption = "Kiểu TT";
            this.colPaymentType.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colPaymentType.FieldName = "PaymentType";
            this.colPaymentType.Name = "colPaymentType";
            this.colPaymentType.Visible = true;
            this.colPaymentType.VisibleIndex = 2;
            this.colPaymentType.Width = 138;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            // 
            // colStatusText
            // 
            this.colStatusText.AppearanceCell.Options.UseTextOptions = true;
            this.colStatusText.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStatusText.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colStatusText.AppearanceHeader.Options.UseFont = true;
            this.colStatusText.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatusText.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatusText.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStatusText.Caption = "Trạng thái";
            this.colStatusText.ColumnEdit = this.repositoryItemLookUpEdit2;
            this.colStatusText.FieldName = "StatusText";
            this.colStatusText.Name = "colStatusText";
            this.colStatusText.OptionsColumn.AllowEdit = false;
            this.colStatusText.Visible = true;
            this.colStatusText.VisibleIndex = 5;
            this.colStatusText.Width = 139;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.NullText = "";
            // 
            // colStatus
            // 
            this.colStatus.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colStatus.AppearanceHeader.Options.UseFont = true;
            this.colStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            // 
            // colTranVAT
            // 
            this.colTranVAT.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTranVAT.AppearanceHeader.Options.UseFont = true;
            this.colTranVAT.AppearanceHeader.Options.UseTextOptions = true;
            this.colTranVAT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTranVAT.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTranVAT.Caption = "Chi phí vận chuyển theo VAT";
            this.colTranVAT.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colTranVAT.FieldName = "IsTranVAT";
            this.colTranVAT.Name = "colTranVAT";
            this.colTranVAT.Width = 114;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // txtTotalNCC
            // 
            this.txtTotalNCC.Location = new System.Drawing.Point(407, 76);
            this.txtTotalNCC.Name = "txtTotalNCC";
            this.txtTotalNCC.Properties.DisplayFormat.FormatString = "{0:n2}";
            this.txtTotalNCC.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalNCC.Properties.Mask.EditMask = "n2";
            this.txtTotalNCC.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalNCC.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalNCC.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalNCC.Size = new System.Drawing.Size(175, 20);
            this.txtTotalNCC.TabIndex = 206;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(353, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 208;
            this.label3.Text = "Giá NCC";
            // 
            // chkIsTranferAfterVAT
            // 
            this.chkIsTranferAfterVAT.AutoSize = true;
            this.chkIsTranferAfterVAT.Location = new System.Drawing.Point(9, 103);
            this.chkIsTranferAfterVAT.Name = "chkIsTranferAfterVAT";
            this.chkIsTranferAfterVAT.Size = new System.Drawing.Size(232, 17);
            this.chkIsTranferAfterVAT.TabIndex = 216;
            this.chkIsTranferAfterVAT.Text = "Chi phí vận chuyển tính sau VAT tiền hàng";
            this.chkIsTranferAfterVAT.UseVisualStyleBackColor = true;
            // 
            // frmPOUpdateCost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 466);
            this.Controls.Add(this.chkIsTranferAfterVAT);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotalNCC);
            this.Controls.Add(this.txtVAT);
            this.Controls.Add(this.txtDiffCost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDeliveryCost);
            this.Name = "frmPOUpdateCost";
            this.Text = "Thêm thông tin PO";
            this.Load += new System.EventHandler(this.frmPOUpdateCost_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDeliveryCost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiffCost.Properties)).EndInit();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVAT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdYC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvYC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalNCC.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtDeliveryCost;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtDiffCost;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtVAT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Button btnDelete;
        private DevExpress.XtraGrid.GridControl grdYC;
        private DevExpress.XtraGrid.Views.Grid.GridView grvYC;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT;
        private DevExpress.XtraGrid.Columns.GridColumn colPayPercent;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalYC;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalTT;
        private DevExpress.XtraGrid.Columns.GridColumn colRequirePaymentDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusText;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraEditors.TextEdit txtTotalNCC;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colTranVAT;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.CheckBox chkIsTranferAfterVAT;
    }
}