using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using DevExpress.Utils;

namespace BMS
{
    public partial class frmProjectProblemReport : _Forms
    {
        DataTable _dtProjectProblem = new DataTable();

        public frmProjectProblemReport()
        {
            InitializeComponent();
        }

        private void frmProjectProblemReport_Load(object sender, EventArgs e)
        {
            loadProject();
            _dtProjectProblem = LibQLSX.Select("exec spGetProblemOfProject ''");
            grdData.DataSource = _dtProjectProblem;
        }

        void loadProject()
        {
            DataTable tbl = LibQLSX.Select("SELECT distinct [ProjectId],[ProjectName],[ProjectCode],[Year],[Month],convert(bit,0) as [check] FROM [vProjectProblem]");
            grdProject.DataSource = null;
            grdProject.DataSource = tbl;
        }

        void addItem(string projectId)
        {
            DataTable dtRi1 = LibQLSX.Select("spGetProblemOfProject '" + projectId + "'");
            _dtProjectProblem.Merge(dtRi1);
            grdData.DataSource = _dtProjectProblem;
        }

        private void repositoryItemCheckEdit2_EditValueChanged(object sender, EventArgs e)
        {
            grvProject.PostEditor();
        }

        private void grvProject_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colCheck)
            {
                bool check = TextUtils.ToBoolean(grvProject.GetFocusedRowCellValue(colCheck));
                string projectId = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colPProjectId));
                if (check)
                {
                    addItem(projectId);
                }
                else
                {
                    DataRow[] drs = _dtProjectProblem.Select("ProjectId <> '" + projectId + "'");
                    if (drs.Length > 0)
                    {
                        _dtProjectProblem = drs.CopyToDataTable();
                    }
                    else
                    {
                        _dtProjectProblem.Rows.Clear();
                    }
                    grdData.DataSource = _dtProjectProblem;
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount == 0) return;
            string localPath = "";

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                localPath = fbd.SelectedPath + "\\BaoCaoDuAn.xlsx";
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\PhongDuAn\\BAO CAO DU AN.xlsx";

            try
            {
                File.Copy(filePath, localPath, true);
            }
            catch
            {
                MessageBox.Show("Lỗi: File excel đang được mở.");
                return;
            }

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu..."))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Application app = default(Excel.Application);
                Excel.Workbook workBoook = default(Excel.Workbook);
                Excel.Worksheet workSheet = default(Excel.Worksheet);
                try
                {
                    app = new Excel.Application();
                    app.Workbooks.Open(localPath);
                    workBoook = app.Workbooks[1];
                    workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                    for (int i = grvData.RowCount - 1; i >= 0; i--)
                    {
                        workSheet.Cells[4, 1] = i + 1;
                        workSheet.Cells[4, 2] = TextUtils.ToString(grvData.GetRowCellValue(i,colProjectCode));
                        workSheet.Cells[4, 3] = TextUtils.ToString(grvData.GetRowCellValue(i, colNguoiPhuTrach));
                        workSheet.Cells[4, 4] = TextUtils.ToString(grvData.GetRowCellValue(i, colTonDong));
                        workSheet.Cells[4, 5] = TextUtils.ToString(grvData.GetRowCellValue(i, colTinhTrang));
                        workSheet.Cells[4, 6] = "";
                        workSheet.Cells[4, 6] = "";

                        ((Excel.Range)workSheet.Rows[4]).Insert();
                    }

                    ((Excel.Range)workSheet.Rows[3]).Delete();
                    ((Excel.Range)workSheet.Rows[3]).Delete();
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
            }

            Process.Start(localPath);

        }
    }
}
