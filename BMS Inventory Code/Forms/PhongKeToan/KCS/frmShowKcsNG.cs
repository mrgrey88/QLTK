using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Diagnostics;

namespace BMS
{
    public partial class frmShowKcsNG : _Forms
    {
        public frmShowKcsNG()
        {
            InitializeComponent();
        }

        private void frmShowKcsNG_Load(object sender, EventArgs e)
        {
            loadData();
        }

        void loadData()
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            {
                DataTable dt =
                    LibQLSX.Select(
                        "select * from vImportMaterial a with(nolock) where (a.TotalNG > 0) AND (a.Status >= 3) and a.DateKCS is not null order by a.Year");
                grdData.DataSource = dt;
            }
        }

        private void btnShowDetail_Click(object sender, EventArgs e)
        {
            string id = TextUtils.ToString(grvData.GetFocusedRowCellValue(colProductPartsImportId));
            if (id == "") return;

            frmShowNGdetail frm = new frmShowNGdetail();
            frm.ProductPartsImportId = id;
            frm.Show();
        }

        private void btnShowĐNNKkhacPhuc_Click(object sender, EventArgs e)
        {
            string importId = TextUtils.ToString(grvData.GetFocusedRowCellValue(colImportId));
            string proposalCode = TextUtils.ToString(grvData.GetFocusedRowCellValue(colProposalCode));
            string partsCode = TextUtils.ToString(grvData.GetFocusedRowCellValue(colCode));
            string dateCreate = TextUtils.ToDate(grvData.GetFocusedRowCellValue(colDateCreate).ToString()).ToString("yyyy/MM/dd");
            string projectCode = TextUtils.ToString(grvData.GetFocusedRowCellValue(colProjectCode));
            string projectModuleCode = TextUtils.ToString(grvData.GetFocusedRowCellValue(colModuleCode));
            // '"++"'
            string sql = "select * from  vImportMaterial b with(nolock) where b.ImportId <> '" + importId + "' "
                            + " and b.ProposalCode = '" + proposalCode + "' and b.PartsCode = '" + partsCode 
                            + "' and b.DateCreate > convert(datetime,'" + dateCreate + "') "
                            + " and b.ProjectCode = '" + projectCode + "' and b.ProjectModuleCode = '" + projectModuleCode + "' ";//and b.Status >= 3";
            DataTable dt = LibQLSX.Select(sql);

            if (dt.Rows.Count == 0) return;

            frmShowDNNKkhacPhuc frm = new frmShowDNNKkhacPhuc();
            frm.DtData = dt;
            frm.Show();
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
                catch (Exception)
                {
                }
            }
        }

        private void btnExeclGroup_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount == 0) return;

            string path = "";

            bool isQtyTotal = false;

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\PhongVT\\BaoCaoVatTuLoi.xls";
            string currentPath = path + "\\BaoCaoVatTuLoi-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" +
                                 DateTime.Now.Year + ".xls";

            try
            {
                File.Copy(filePath, currentPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tạo biểu mẫu!" + Environment.NewLine + ex.Message,
                    TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            grvData.ExpandAllGroups();

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu..."))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Application app = default(Excel.Application);
                Excel.Workbook workBoook = default(Excel.Workbook);
                Excel.Worksheet workSheet = default(Excel.Worksheet);
                try
                {
                    app = new Excel.Application();
                    app.Workbooks.Open(currentPath);
                    workBoook = app.Workbooks[1];
                    workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                    for (int i = grvData.RowCount - 1; i >= 0; i--)
                    {
                        string productPartsImportId = TextUtils.ToString(grvData.GetRowCellValue(i, colProductPartsImportId));
                        if (productPartsImportId == "") continue;
                        DataTable dt = LibQLSX.Select("select * from [CriteriaImport] with(nolock) where [Status] = 0 and [ProductPartsImportId] = '"
                        + productPartsImportId + "' order by [CriteriaIndex]");
                        
                        for (int j = dt.Rows.Count - 1; j >= 0; j--)
                        {
                            string content = TextUtils.ToString(dt.Rows[j]["ValueResult"]);
                            string index = TextUtils.ToString(dt.Rows[j]["CriteriaIndex"]);

                            workSheet.Cells[12, 1] = "";
                            workSheet.Cells[12, 2] = index;
                            workSheet.Cells[12, 3] = content == "" ? "Lỗi" : content;
                            workSheet.Cells[12, 4] = TextUtils.ToString(grvData.GetRowCellValue(i, colCode));
                           
                            workSheet.Cells[12, 5] = TextUtils.ToString(grvData.GetRowCellValue(i, colOrderCode));
                            workSheet.Cells[12, 6] = TextUtils.ToString(grvData.GetRowCellValue(i, colImportCode));
                            workSheet.Cells[12, 7] = TextUtils.ToString(grvData.GetRowCellValue(i, colProposalCode));
                            workSheet.Cells[12, 8] = TextUtils.ToString(grvData.GetRowCellValue(i, colProjectCode));
                            workSheet.Cells[12, 9] = TextUtils.ToString(grvData.GetRowCellValue(i, colModuleCode));

                            workSheet.Cells[12, 16] = TextUtils.ToString(grvData.GetRowCellValue(i, colSupplierCode)) 
                                + " - " + TextUtils.ToString(grvData.GetRowCellValue(i, colSupplierName));

                            ((Excel.Range) workSheet.Rows[12]).Font.Italic = true;
                            ((Excel.Range)workSheet.Rows[12]).Insert();
                        }

                        workSheet.Cells[12, 1] = i + 1;
                        workSheet.Cells[12, 2] = "";
                        workSheet.Cells[12, 3] = TextUtils.ToString(grvData.GetRowCellValue(i, colName));
                        workSheet.Cells[12, 4] = TextUtils.ToString(grvData.GetRowCellValue(i, colCode));
                        workSheet.Cells[12, 5] = TextUtils.ToString(grvData.GetRowCellValue(i, colOrderCode));
                        workSheet.Cells[12, 6] = TextUtils.ToString(grvData.GetRowCellValue(i, colImportCode));
                        workSheet.Cells[12, 7] = TextUtils.ToString(grvData.GetRowCellValue(i, colProposalCode));
                        workSheet.Cells[12, 8] = TextUtils.ToString(grvData.GetRowCellValue(i, colProjectCode));
                        workSheet.Cells[12, 9] = TextUtils.ToString(grvData.GetRowCellValue(i, colModuleCode));
                        workSheet.Cells[12, 10] = TextUtils.ToString(grvData.GetRowCellValue(i, colTotal));
                        workSheet.Cells[12, 11] = TextUtils.ToString(grvData.GetRowCellValue(i, colTotalOK));
                        workSheet.Cells[12, 12] = TextUtils.ToString(grvData.GetRowCellValue(i, colTotalNG));
                        workSheet.Cells[12, 13] = TextUtils.ToString(grvData.GetRowCellValue(i, colUserNameKCS1));
                        workSheet.Cells[12, 14] = TextUtils.ToString(grvData.GetRowCellValue(i, colNguoiPhuTrach1));
                        workSheet.Cells[12, 15] = TextUtils.ToString(grvData.GetRowCellValue(i, colHSX));
                        workSheet.Cells[12, 16] = TextUtils.ToString(grvData.GetRowCellValue(i, colSupplierCode))
                                                  + " - " +
                                                  TextUtils.ToString(grvData.GetRowCellValue(i, colSupplierName));
                        workSheet.Cells[12, 17] = TextUtils.ToString(grvData.GetRowCellDisplayText(i, colDateCreate));
                        workSheet.Cells[12, 18] = TextUtils.ToString(grvData.GetRowCellDisplayText(i, colDateKCS));

                        ((Excel.Range)workSheet.Rows[12]).Font.Bold = true;
                        ((Excel.Range)workSheet.Rows[12]).Insert();
                    }
                    ((Excel.Range)workSheet.Rows[11]).Delete();
                    ((Excel.Range)workSheet.Rows[11]).Delete();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (app != null)
                    {
                        app.ActiveWorkbook.Save();
                        app.Workbooks.Close();
                        app.Quit();
                    }
                }
                Process.Start(currentPath);
            }
        }
    }
}
