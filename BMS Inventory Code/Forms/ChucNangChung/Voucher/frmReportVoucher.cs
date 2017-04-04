using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Model;
using TPA.Business;
using DevExpress.XtraGrid.Views.Grid;
using System.Diagnostics;
using DevExpress.Utils;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace BMS
{
    public partial class frmReportVoucher : _Forms
    {
        DataTable _dtData = new DataTable();
        int _rownIndex = 0;
        public frmReportVoucher()
        {
            InitializeComponent();
        }

        private void frmReportVoucher_Load(object sender, EventArgs e)
        {
            loadUser();
            loadData();

            hideControl(true);
        }

        void loadUser()
        {
            DataTable dt = LibQLSX.Select("Select * from [vUser] WITH(NOLOCK)");
            cboUser.Properties.DataSource = dt;
            cboUser.Properties.DisplayMember = "UserName";
            cboUser.Properties.ValueMember = "UserId";
            grvCboUser.BestFitColumns();
        }

        void loadData()
        {
            string userId = TextUtils.ToString(cboUser.EditValue);
            string[] _paraName = new string[2];
            object[] _paraValue = new object[2];

            _paraName[0] = "@UserId"; _paraValue[0] = userId;
            _paraName[1] = "@Type"; _paraValue[1] = TextUtils.ToInt(cboType.SelectedIndex);

            _dtData = PaymentTableBO.Instance.LoadDataFromSP("spGetVoucherDebtReport", "Source", _paraName, _paraValue);
            grdData.DataSource = _dtData;
            if (_rownIndex >= grvData.RowCount)
                _rownIndex = 0;
            if (_rownIndex > 0)
                grvData.FocusedRowHandle = _rownIndex;
            grvData.SelectRow(_rownIndex);
            grvData.BestFitColumns();
        }

        private void cboUser_EditValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnExeclReport_Click(object sender, EventArgs e)
        {
            //string path = "";
            //FolderBrowserDialog fbd = new FolderBrowserDialog();
            //if (fbd.ShowDialog() == DialogResult.OK)
            //{
            //    path = fbd.SelectedPath;
            //}
            //else
            //{
            //    return;
            //}

            //string filePath = Application.StartupPath + "\\Templates\\PhongKeToan\\BangTheoDoiChungTu.xlsx";
            //string currentPath = path + "\\BangTheoDoiChungTu.xlsx";
            //try
            //{
            //    File.Copy(filePath, currentPath, true);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Có lỗi khi tạo báo cáo!" + Environment.NewLine + ex.Message,
            //        TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

            //using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo báo cáo..."))
            //{
            //    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            //    Excel.Application app = default(Excel.Application);
            //    Excel.Workbook workBoook = default(Excel.Workbook);
            //    Excel.Worksheet workSheet = default(Excel.Worksheet);
            //    try
            //    {
            //        app = new Excel.Application();
            //        app.Workbooks.Open(currentPath);
            //        workBoook = app.Workbooks[1];
            //        workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

            //        for (int i = grvData.RowCount - 1; i >= 0; i--)
            //        {
            //            string number = TextUtils.ToString(grvData.GetRowCellValue(i, colNumber));
            //            workSheet.Cells[6, 1] = i + 1;
            //            workSheet.Cells[6, 2] = number;
            //            workSheet.Cells[6, 3] = TextUtils.ToString(grvData.GetRowCellValue(i, colItemCode));
            //            workSheet.Cells[6, 4] = TextUtils.ToString(grvData.GetRowCellValue(i, colItemName));
            //            workSheet.Cells[6, 5] = TextUtils.ToString(grvData.GetRowCellValue(i, colVoucherName));
            //            workSheet.Cells[6, 6] = TextUtils.ToString(grvData.GetRowCellValue(i, colUserName));
            //            workSheet.Cells[6, 7] = TextUtils.ToString(grvData.GetRowCellDisplayText(i, colCreatedDate));
            //            workSheet.Cells[6, 8] = TextUtils.ToString(grvData.GetRowCellDisplayText(i, colCompletedDateDK));
            //            if (number != "")
            //            {
            //                ((Excel.Range)workSheet.Rows[6]).Insert();
            //            }
            //        }
            //        ((Excel.Range)workSheet.Rows[5]).Delete();
            //        ((Excel.Range)workSheet.Rows[5]).Delete();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    finally
            //    {
            //        if (app != null)
            //        {
            //            app.ActiveWorkbook.Save();
            //            app.Workbooks.Close();
            //            app.Quit();
            //        }
            //    }
            //    Process.Start(currentPath);
            //}

            TextUtils.ExportExcel(grvData);
        }

        private void grvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;
            GridView View = sender as GridView;
            DateTime completeDateDK = TextUtils.ToDate(View.GetRowCellValue(e.RowHandle, colCompletedDateDK).ToString());
            string completeDate = TextUtils.ToString(View.GetRowCellValue(e.RowHandle, colCompletedDate));
            if (completeDateDK.Date <= DateTime.Now.Date && completeDate == "")
            {
                e.Appearance.BackColor = Color.Yellow;
            }
        }

        private void cboType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadData();
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            //long paymentTableID = TextUtils.ToInt64(grvData.GetFocusedRowCellValue(colPaymentTableID));
            //if (paymentTableID == 0) return;
            //PaymentTableModel model = (PaymentTableModel)PaymentTableBO.Instance.FindByPK(paymentTableID);

            //frmPaymentTableItem frm = new frmPaymentTableItem();
            //frm.PaymentTable = model;
            ////frm.LoadDataChange += main_LoadDataChange;
            //frm.Show();
        }

        void hideControl(bool hide)
        {
            lblDateOut.Visible = lblReason.Visible = dtpDateOut.Visible = txtReason.Visible = btnSaveHistory.Visible = !hide;
        }

        private void btnDateOut_Click(object sender, EventArgs e)
        {                
            hideControl(false);
        }

        private void btnSaveHistory_Click(object sender, EventArgs e)
        {
            int caseVoucherDebtID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (caseVoucherDebtID == 0) return;
            string completedDate = TextUtils.ToString(grvData.GetFocusedRowCellDisplayText(colCompletedDate));
            if (completedDate != "") return;

            if (dtpDateOut.EditValue == null)
            {
                MessageBox.Show("Bạn phải chọn ngày trả dự kiến.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (txtReason.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập nguyên nhân gia hạn.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            CaseVoucherDebtHistoryModel model = new CaseVoucherDebtHistoryModel();
            model.CaseVoucherDebtID = caseVoucherDebtID;
            model.DateOut = (DateTime?)dtpDateOut.EditValue;
            model.Reason = txtReason.Text.Trim();
            CaseVoucherDebtHistoryBO.Instance.Insert(model);

            CaseVoucherDebtModel cModel = (CaseVoucherDebtModel)CaseVoucherDebtBO.Instance.FindByPK(caseVoucherDebtID);
            cModel.CompletedDateDK = model.DateOut;
            cModel.Reason = model.Reason;
            CaseVoucherDebtBO.Instance.Update(cModel);

            MessageBox.Show("Gia hạn thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

            dtpDateOut.EditValue = null;
            txtReason.Text = "";

            grvData.SetFocusedRowCellValue(colReason, model.Reason);
            grvData.SetFocusedRowCellValue(colCompletedDateDK, model.DateOut);
            hideControl(true);

            //_rownIndex = grvData.FocusedRowHandle;
            //loadData();
        }

        private void btnDaTra_Click(object sender, EventArgs e)
        {
            if (grvData.SelectedRowsCount < 0) return;
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xác nhận những chứng từ này đã trả", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            foreach (int i in grvData.GetSelectedRows())
            {
                int caseVoucherDebtID = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                if (caseVoucherDebtID == 0) return;
                CaseVoucherDebtModel cModel = (CaseVoucherDebtModel)CaseVoucherDebtBO.Instance.FindByPK(caseVoucherDebtID);
                cModel.CompletedDate = DateTime.Now;
                CaseVoucherDebtBO.Instance.Update(cModel);
            }
            loadData();
        }

        private void hủyĐãTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grvData.SelectedRowsCount < 0) return;
            DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy xác nhận những chứng từ này đã trả", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            foreach (int i in grvData.GetSelectedRows())
            {
                int caseVoucherDebtID = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                if (caseVoucherDebtID == 0) return;
                CaseVoucherDebtModel cModel = (CaseVoucherDebtModel)CaseVoucherDebtBO.Instance.FindByPK(caseVoucherDebtID);
                cModel.CompletedDate = null;
                CaseVoucherDebtBO.Instance.Update(cModel);
            }
            loadData();
        }
    }
}
