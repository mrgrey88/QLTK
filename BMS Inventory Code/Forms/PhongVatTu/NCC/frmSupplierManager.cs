using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using TPA.Business;
using TPA.Model;
using TPA.Utils;

namespace BMS
{
    public partial class frmSupplierManager : _Forms
    {
        int _rownIndex = 0;

        public frmSupplierManager()
        {
            InitializeComponent();
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            loadHangFind();
            LoadInfoSearch();            
        }

        void loadHangFind()
        {
            DataTable dt = LibQLSX.Select("Select * from [Manufacturer] WITH(NOLOCK)");
            cboHang.Properties.DataSource = dt;
            cboHang.Properties.DisplayMember = "MName";
            cboHang.Properties.ValueMember = "ManufacturerId";
        }      

        private void LoadInfoSearch()
        {
            try
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ giây lát...", "Đang load danh sách NCC..."))
                {
                    DataTable dt = new DataTable();
                    if (cboHang.EditValue == null)
                    {
                        dt = LibQLSX.Select("select * from vSuppliers with(nolock) where SupplierCode not like 'nv%' order by SupplierId desc");
                    }
                    else
                    {
                        dt = LibQLSX.Select("select * from vSuppliers with(nolock) where SupplierCode not like 'nv%' and Hang like '%"
                            + TextUtils.ToString(grvCboHang.GetFocusedRowCellValue(colMCode)) + "%' order by SupplierId desc");
                    }
                    
                    grdData.DataSource = dt;
                    if (_rownIndex >= grvData.RowCount)
                        _rownIndex = 0;
                    if (_rownIndex > 0)
                        grvData.FocusedRowHandle = _rownIndex;
                    grvData.SelectRow(_rownIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        
        void main_LoadDataChange(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSupplier frm = new frmSupplier();
            frm.IsNew = true;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = TextUtils.ToString(grvData.GetFocusedRowCellValue(colSupplierId));
            if (id == "") return;
            SuppliersModel model = (SuppliersModel)SuppliersBO.Instance.FindByPKStringID("SupplierId", id);
            _rownIndex = grvData.FocusedRowHandle;

            frmSupplier frm = new frmSupplier();
            frm.Supplier = model;
            frm.IsNew = false;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string id = TextUtils.ToString(grvData.GetFocusedRowCellValue(colSupplierId));
            if (id == "") return;
            if (MessageBox.Show("Bạn có chắc muốn xóa nhà CC [" + grvData.GetFocusedRowCellValue(colName).ToString() + "] không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            SuppliersModel model = (SuppliersModel)SuppliersBO.Instance.FindByPKStringID("SupplierId", id);
            model.StatusDisable = 1;
            SuppliersBO.Instance.UpdateQLSX(model);
            LoadInfoSearch();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvData.RowCount > 0)
                {
                    TextUtils.ExportExcel(grvData);
                }
            }
            catch
            {
            }
        }
     
        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void grvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(grvData.GetFocusedRowCellValue(grvData.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch
                {
                }
            }
        }

        private void xemDanhSáchVậtTưCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierParts frm = new frmSupplierParts();
            frm.NCCcode = TextUtils.ToString(grvData.GetFocusedRowCellValue(colCode));
            frm.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        private void btnFindWithHang_Click(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        private void btnListContract_Click(object sender, EventArgs e)
        {
            frmListContract frm = new frmListContract();
            TextUtils.OpenForm(frm);
        }
    }
}
