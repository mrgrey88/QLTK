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
using TPA.Utils;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using DevExpress.Utils;
using System.Diagnostics;

namespace BMS
{
    public partial class frmQuotationReportKD : _Forms
    {
        public C_Quotation_KDModel Quotation = new C_Quotation_KDModel();

        public frmQuotationReportKD()
        {
            InitializeComponent();
        }

        private void frmQuotationReportKD_Load(object sender, EventArgs e)
        {
            this.Location = new Point(this.Width / 4, 0);
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Text += ": " + Quotation.Code + " - " + Quotation.ProjectCode;

            loadText();
            loadGrid();
        }

        void loadText()
        {
            string[] paraName = new string[2];
            object[] paraValue = new object[2];
            paraName[0] = "@Year"; paraValue[0] = 0;
            paraName[1] = "@QuotationID"; paraValue[1] = Quotation.ID;

            DataTable dtQuotation = C_CostBO.Instance.LoadDataFromSP("spReportQuotationKD", "Source", paraName, paraValue);
            if (dtQuotation.Rows.Count > 0)
            {
                txtTotalHD.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalHD"]);
                txtTotalTPA.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalTPA"]);
                txtTotalTPA_PreVAT.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalTPA_PreVAT"]);
                txtTotalVAT.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalVAT_HD"]);
                //txtTotalVAT.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalVAT_HD"]);
                txtTotalVT.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalVT"]);

                txtTotalNC.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalNC"]);
                txtTotalPB.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalPB"]);
                txtTotalDP.EditValue = Quotation.TotalDP_KD;
                txtTotalXL.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalXL"]);
                txtTotalCustomer.EditValue = Quotation.CustomerCash;

                txtTotalNC_KD.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalNC_KD"]);
                txtTotalReal.EditValue = TextUtils.ToDecimal(txtTotalHD.EditValue) - TextUtils.ToDecimal(txtTotalXL.EditValue);
                txtTotalProfitTT.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalProfitTT"]);
                txtTotalProfitQD.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalProfitQD"]);
            }
        }

        void loadGrid()
        {
            string[] paraName = new string[1];
            object[] paraValue = new object[1];

            paraName[0] = "@QuotationID"; paraValue[0] = Quotation.ID;

            DataTable dtCost = C_CostBO.Instance.LoadDataFromSP("spReportCostWithQuotationKD", "Source", paraName, paraValue);

            grdSP.DataSource = dtCost;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadText();
            loadGrid();
        }

        private void btnFCM_Click(object sender, EventArgs e)
        {
            string localPath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                localPath = fbd.SelectedPath + "\\FCM-KD- " + Quotation.Code + ".xlsx";
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\PhongKinhDoanh\\FCM-KD-TEMPLATE.xlsx";

            try
            {
                File.Copy(filePath, localPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: File excel đang được mở." + Environment.NewLine + ex.Message);
                return;
            }

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo FCM..."))
            {
                DataTable dtQuotation = LibQLSX.Select("exec spGetQuotation @QuotationID = " + Quotation.ID);
                DataTable dtAllCost = LibQLSX.Select("exec [spReportCostWithQuotationKD] " + Quotation.ID);
                DataTable dtGroup = TextUtils.GetDistinctDatatable(dtAllCost, "GroupCode");

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

                    workSheet.Cells[4, 4] = "KD";
                    workSheet.Cells[4, 6] = Quotation.DeliveryTime;

                    workSheet.Cells[5, 4] = TextUtils.ToString(Quotation.ProjectCode);
                    workSheet.Cells[6, 4] = TextUtils.ToString(Quotation.ProjectName);
                    workSheet.Cells[7, 4] = TextUtils.ToString(Quotation.CustomerName);
                    workSheet.Cells[9, 4] = TextUtils.ToString(dtQuotation.Rows[0]["DName"]);                    
                    workSheet.Cells[8, 7] = TextUtils.ToString(dtQuotation.Rows[0]["StatusText"]);
                    workSheet.Cells[9, 7] = TextUtils.ToString(Quotation.POnumber);
                    //Lợi nhuận
                    workSheet.Cells[13, 7] = TextUtils.ToDecimal(txtTotalProfitTT.EditValue);
                    workSheet.Cells[14, 7] = TextUtils.ToDecimal(txtTotalProfitQD.EditValue);
                    //Giá bán
                    workSheet.Cells[16, 7] = TextUtils.ToDecimal(txtTotalReal.EditValue);//Giá thực thu
                    workSheet.Cells[17, 7] = TextUtils.ToDecimal(txtTotalHD.EditValue);//Giá có VAT thực tế bán trên HĐ
                    workSheet.Cells[18, 7] = TextUtils.ToDecimal(txtTotalHD.EditValue);//Giá chưa VAT thực tế bán trên HĐ
                    workSheet.Cells[19, 7] = TextUtils.ToDecimal(txtTotalTPA.EditValue);//Giá có VAT theo quy định phải bán
                    workSheet.Cells[20, 7] = TextUtils.ToDecimal(txtTotalTPA_PreVAT.EditValue);//Giá chưa VAT theo quy định phải bán
                    //Chi phí
                    workSheet.Cells[22, 7] = TextUtils.ToDecimal(txtTotalVAT.EditValue);//Thuế GTGT phải nộp
                    //workSheet.Cells[23, 7] = TextUtils.ToDecimal(txtTotalXL.EditValue);//Xử lí phần gửi
                    workSheet.Cells[24, 7] = TextUtils.ToDecimal(txtTotalCustomer.EditValue);//Khách hàng gửi
                    workSheet.Cells[25, 7] = Quotation.TotalVC_KD;//Chi phí vận chuyển
                    workSheet.Cells[26, 7] = Quotation.TotalBX_KD;//Chi phí bốc xếp
                    workSheet.Cells[27, 7] = TextUtils.ToDecimal(txtTotalVT.EditValue);//Tổng chi phí Mua vào
                    workSheet.Cells[28, 7] = TextUtils.ToDecimal(txtTotalNC.EditValue);//Chi phí cố định - Nhân công gián tiếp 
                    workSheet.Cells[29, 7] = TextUtils.ToDecimal(txtTotalNC_KD.EditValue);//Chi phí cố định - Nhân công KD
                    workSheet.Cells[30, 7] = TextUtils.ToDecimal(dtAllCost.Compute("Sum(TotalPrice)", "GroupCode = 'N08'"));//Chi phí quản lí N08
                    workSheet.Cells[31, 7] = TextUtils.ToDecimal(txtTotalDP.EditValue);//Chi phí dự phòng
                    workSheet.Cells[32, 7] = TextUtils.ToDecimal(dtAllCost.Compute("Sum(TotalPrice)", "GroupCode = 'N11'"));//Chi phí bảo hành
                    workSheet.Cells[33, 7] = TextUtils.ToDecimal(dtAllCost.Compute("Sum(TotalPrice)", "GroupCode = 'N09'"));//Chi phí lãi vay

                    for (int i = dtGroup.Rows.Count - 1; i >= 0; i--)
                    {
                        string groupCode = TextUtils.ToString(dtGroup.Rows[i]["GroupCode"]);

                        DataRow[] listCost = dtAllCost.AsEnumerable()
                            .Where(y => y.Field<string>("GroupCode") == groupCode)
                            .ToArray();

                        for (int k = listCost.Length - 1; k >= 0; k--)
                        {
                            workSheet.Cells[36, 2] = TextUtils.ToString(listCost[k]["Code"]);
                            workSheet.Cells[36, 3] = TextUtils.ToString(listCost[k]["Name"]);
                            //workSheet.Cells[36, 4] = TextUtils.ToString(listCost[k]["Name"]);
                            workSheet.Cells[36, 5] = "Đồng";
                            //workSheet.Cells[36, 6] = TextUtils.ToDecimal(listCost[k]["Qty"]);
                            workSheet.Cells[36, 7] = TextUtils.ToDecimal(listCost[k]["TotalPrice"]);                            

                            ((Excel.Range)workSheet.Rows[36]).Insert();
                            Excel.Range range = workSheet.get_Range(workSheet.Cells[36, 3], workSheet.Cells[36, 4]);
                            range.Merge(true);
                        }

                        workSheet.Cells[36, 2] = TextUtils.ToString(dtGroup.Rows[i]["GroupCode"]);
                        workSheet.Cells[36, 3] = TextUtils.ToString(dtGroup.Rows[i]["GroupName"]);

                        ((Excel.Range)workSheet.Rows[36]).Font.Bold = true;
                        ((Excel.Range)workSheet.Rows[36]).Insert();
                        Excel.Range range1 = workSheet.get_Range(workSheet.Cells[36, 3], workSheet.Cells[36, 4]);
                        range1.Merge(true);
                    }

                    ((Excel.Range)workSheet.Rows[35]).Delete();
                    ((Excel.Range)workSheet.Rows[35]).Delete();
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

                Process.Start(localPath);
            }
        }
       
    }
}
