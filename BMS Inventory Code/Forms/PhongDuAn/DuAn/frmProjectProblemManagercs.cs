using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using TPA.Model;
using TPA.Business;
using DevExpress.XtraGrid.Views.Grid;

namespace BMS
{
    public partial class frmProjectProblemManagercs : _Forms
    {
        int _rownIndex = 0;

        public frmProjectProblemManagercs()
        {
            InitializeComponent();
        }

        private void frmProjectProblemManagercs_Load(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        void LoadInfoSearch()
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            {
                try
                {
                    string sql = "select * from vProjectProblem with(nolock) where Status = 0";
                    if (chkIsDeleted.Checked)
                    {
                        sql = "select * from vProjectProblem with(nolock)";
                    }

                    DataTable Source = LibQLSX.Select(sql);

                    DataTable dtError = TextUtils.Select("select * from vModuleError with(nolock) where Status = 0 and ProjectCode is not null and ProjectCode <> ''");
                    foreach (DataRow r in dtError.Rows)
                    {
                        DataRow row = Source.NewRow();
                        row["ProjectName"] = TextUtils.ToString("");
                        row["ProjectCode"] = TextUtils.ToString(r["ProjectCode"]);
                        row["ModuleCode"] = TextUtils.ToString(r["ModuleCode"]);
                        row["UserName"] = TextUtils.ToString(r["Author"]);
                        row["IsTonDong"] = true;
                        row["DName"] = TextUtils.ToString(r["DepartmentGL"]);
                        //row["DatePhatSinh"] = TextUtils.ToDate2(r["CreatedDate"]);
                        row["Content"] = TextUtils.ToString(r["Description"]);
                        row["Reason"] = TextUtils.ToString(r["Reason"]);
                        row["Year"] = TextUtils.ToString(r["YearCreate"]);
                        Source.Rows.Add(row);
                    }

                    grdData.DataSource = Source;
                    if (_rownIndex >= grvData.RowCount)
                        _rownIndex = 0;
                    if (_rownIndex > 0)
                        grvData.FocusedRowHandle = _rownIndex;
                    grvData.SelectRow(_rownIndex);
                    //grvData.BestFitColumns();
                }
                catch
                {
                    grdData.DataSource = null;
                }
            }
        }

        void main_LoadDataChange(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProjectProblem frm = new frmProjectProblem();
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            ProjectProblemModel model = (ProjectProblemModel)ProjectProblemBO.Instance.FindByPK(id);

            //if (Global.AppUserName != model.UpdatedBy)
            //{
            //    MessageBox.Show("Bạn không có quyền sửa vấn đề này!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

            _rownIndex = grvData.FocusedRowHandle;
            frmProjectProblem frm = new frmProjectProblem();
            frm.ProjectProblem = model;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            ProjectProblemModel model = (ProjectProblemModel)ProjectProblemBO.Instance.FindByPK(id);
            if (Global.AppUserName != model.UpdatedBy)
            {
                MessageBox.Show("Bạn không có quyền xóa vấn đề này!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa hoàn toàn yêu cầu [" + grvData.GetFocusedRowCellValue(colProjectName).ToString() + "] không?"
                , TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            
            ProjectProblemBO.Instance.Delete(id);
            LoadInfoSearch();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            TextUtils.ExportExcel(grvData);
        }

        private void grvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C)
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

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmProjectProblemReport frm = new frmProjectProblemReport();
            frm.Show();
        }

        private void chkIsDeleted_CheckedChanged(object sender, EventArgs e)
        {            
            LoadInfoSearch();            
        }

        private void khôiPhụcXóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (int i in grvData.GetSelectedRows())
            {
                int id = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                int isDeleted = TextUtils.ToInt(grvData.GetRowCellValue(i, colIsDeleted));

                if (id == 0) continue;
                if (isDeleted == 0) continue;

                ProjectProblemModel model = (ProjectProblemModel)ProjectProblemBO.Instance.FindByPK(id);
                model.IsDeleted = 0;
                ProjectProblemBO.Instance.Update(model);
                count++;
            }
            if (count > 0)
            {
                LoadInfoSearch();
            }
        }

        private void grvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;
            GridView View = sender as GridView;
            int isDeleted = TextUtils.ToInt(View.GetRowCellValue(e.RowHandle, colIsDeleted));

            if (isDeleted == 1)
            {
                e.Appearance.ForeColor = Color.Red;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            ProjectProblemModel model = (ProjectProblemModel)ProjectProblemBO.Instance.FindByPK(id);
            //_rownIndex = grvData.FocusedRowHandle;
            model.ID = 0;
            frmProjectProblem frm = new frmProjectProblem();
            frm.ProjectProblem = model;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            ProjectProblemModel model = (ProjectProblemModel)ProjectProblemBO.Instance.FindByPK(id);
            //_rownIndex = grvData.FocusedRowHandle;
            model.ID = 0;
            frmProjectProblem frm = new frmProjectProblem();
            frm.ProjectProblem = model;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnReportUser_Click(object sender, EventArgs e)
        {
            frmProjectProblemReportUser frm = new frmProjectProblemReportUser();
            frm.Show();
        }
    }
}
