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
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using DevExpress.Utils;
using System.Diagnostics;

namespace BMS
{
    public partial class frmProjectDirection : _Forms
    {
        public int ProjectDirectionID = 0;
        ProjectDirectionModel _projectDirection;
        DataTable _dtData = new DataTable();
        public frmProjectDirection()
        {
            InitializeComponent();
        }

        private void frmProjectDirection_Load(object sender, EventArgs e)
        {            
            _projectDirection = (ProjectDirectionModel)ProjectDirectionBO.Instance.FindByPK(ProjectDirectionID);
            this.Text += ": " + _projectDirection.ID + "- Dự án: " + _projectDirection.ProjectCode;
            loadProjectDirectionType();
            loadUser();
            loadGrid();
            loadUser1();
        }

        void loadProjectDirectionType()
        {
            DataTable dt = LibQLSX.Select("select * from ProjectDirectionType with(nolock)");
            repositoryItemSearchLookUpEdit2.DataSource = dt;
            repositoryItemSearchLookUpEdit2.DisplayMember = "Code";
            repositoryItemSearchLookUpEdit2.ValueMember = "ID";
        }

        void loadUser()
        {
            DataTable dt = LibQLSX.Select("select * from Users with(nolock)");
            repositoryItemSearchLookUpEdit1.DataSource = dt;
            repositoryItemSearchLookUpEdit1.DisplayMember = "UserName";
            repositoryItemSearchLookUpEdit1.ValueMember = "UserId";

            repositoryItemSearchLookUpEdit3.DataSource = dt;
            repositoryItemSearchLookUpEdit3.DisplayMember = "UserName";
            repositoryItemSearchLookUpEdit3.ValueMember = "UserId";

            repositoryItemSearchLookUpEdit5.DataSource = dt;
            repositoryItemSearchLookUpEdit5.DisplayMember = "UserName";
            repositoryItemSearchLookUpEdit5.ValueMember = "UserId";

            repositoryItemSearchLookUpEdit7.DataSource = dt;
            repositoryItemSearchLookUpEdit7.DisplayMember = "UserName";
            repositoryItemSearchLookUpEdit7.ValueMember = "UserId";

            repositoryItemSearchLookUpEdit9.DataSource = dt;
            repositoryItemSearchLookUpEdit9.DisplayMember = "UserName";
            repositoryItemSearchLookUpEdit9.ValueMember = "UserId";

            repositoryItemSearchLookUpEdit11.DataSource = dt;
            repositoryItemSearchLookUpEdit11.DisplayMember = "UserName";
            repositoryItemSearchLookUpEdit11.ValueMember = "UserId";

        }

        void loadUser1()
        {
            DataTable dt = LibQLSX.Select("select * from vUser with(nolock) order by Code");
            cboUser.Properties.DataSource = dt;
            cboUser.Properties.ValueMember = "UserId";
            cboUser.Properties.DisplayMember = "UserName";
        }

        void loadGrid()
        {
            string sql = "select * from vProjectDirectionDetail where ProjectDirectionID = " + ProjectDirectionID;
            _dtData = LibQLSX.Select(sql);
            grdTong.DataSource = _dtData;

            grdCNC.DataSource = LibQLSX.Select(sql + " and ProjectDirectionTypeID = 1");
            grdIN.DataSource = LibQLSX.Select(sql + " and ProjectDirectionTypeID = 2");
            grdAL.DataSource = LibQLSX.Select(sql + " and ProjectDirectionTypeID = 3");
            grdDT.DataSource = LibQLSX.Select(sql + " and ProjectDirectionTypeID = 4");
            grdLR.DataSource = LibQLSX.Select(sql + " and ProjectDirectionTypeID > 4");
        }

        void exportIn(string selectFolder)
        {
            string fileSourcePath = Application.StartupPath + "\\Templates\\PhongSXLR\\ChiThi.xls";
            string localPath = selectFolder + "/" + _projectDirection.ProjectCode + ".CTSX." + _projectDirection.ID + "/" + _projectDirection.ProjectCode + "-CTSX.IN";
            Directory.CreateDirectory(localPath);
            //string filePath = localPath + "/Chi_Thi_In.xls";
            string filePath = localPath + "/" + _projectDirection.ProjectCode + "-CTSX.IN.xls";
            try
            {
                File.Copy(fileSourcePath, filePath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: File excel đang được mở." + Environment.NewLine + ex.Message);
                return;
            }

            DocUtils.InitFTPQLSX();
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo chỉ thị IN..."))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Application app = default(Excel.Application);
                Excel.Workbook workBoook = default(Excel.Workbook);
                Excel.Worksheet workSheet = default(Excel.Worksheet);
                try
                {
                    app = new Excel.Application();
                    app.Workbooks.Open(filePath);
                    workBoook = app.Workbooks[1];
                    workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                    workSheet.Cells[5, 3] = _projectDirection.ID;
                    workSheet.Cells[2, 7] = _projectDirection.ProjectCode;
                    workSheet.Cells[4, 2] = "PHÒNG/ TỔ: CNC";

                    DataRow[] drsIn = _dtData.Select("ProjectDirectionTypeID = 2 and IsDeleted = 0", "PartsCode ASC");
                    for (int i = 0; i < drsIn.Length; i++)
                    {
                        string moduleCode = TextUtils.ToString(drsIn[i]["ModuleCode"]);
                        string moduleGroup = moduleCode.Substring(0, 6);
                        //string serverPathMat = string.Format(@"/Thietke.Ck/{0}/{1}.Ck/MAT.{1}", moduleGroup, moduleCode);
                        //string serverPathCad = string.Format(@"/Thietke.Ck/{0}/{1}.Ck/CAD.{1}", moduleGroup, moduleCode);

                        string stt = TextUtils.ToString(drsIn[i]["STT"]);
                        string partsCode = TextUtils.ToString(drsIn[i]["PartsCode"]);
                        string partsName = TextUtils.ToString(drsIn[i]["PartsName"]);
                        decimal qty = TextUtils.ToDecimal(drsIn[i]["Qty"]);
                        decimal makeTime = TextUtils.ToDecimal(drsIn[i]["MakeTime"]);
                        string userName = TextUtils.ToString(drsIn[i]["UserName"]);
                        DateTime? startDateDK = TextUtils.ToDate2(drsIn[i]["StartDateDK"]);
                        DateTime? endDateDK = TextUtils.ToDate2(drsIn[i]["EndDateDK"]);
                        string vatLieu = TextUtils.ToString(drsIn[i]["Material"]);
                        //string fileName = TextUtils.ToString(drsIn[i]["FileName"]);
                        string filePath1 = TextUtils.ToString(drsIn[i]["FilePath"]);
                        string note = TextUtils.ToString(drsIn[i]["Note"]);

                        DocUtils.DownloadFile(localPath, Path.GetFileName(filePath1), filePath1);

                        workSheet.Cells[10, 1] = stt;
                        workSheet.Cells[10, 2] = partsName;
                        workSheet.Cells[10, 3] = partsCode;
                        workSheet.Cells[10, 4] = moduleCode;
                        workSheet.Cells[10, 5] = qty;
                        workSheet.Cells[10, 6] = makeTime;
                        workSheet.Cells[10, 8] = userName;
                        workSheet.Cells[10, 9] = startDateDK != null ? startDateDK.Value.ToString("dd/MM/yyyy") : "";
                        workSheet.Cells[10, 10] = endDateDK != null ? endDateDK.Value.ToString("dd/MM/yyyy") : "";
                        workSheet.Cells[10, 18] = vatLieu;
                        workSheet.Cells[10, 24] = note;
                        if (note != "")
                        {
                            ((Excel.Range)workSheet.Rows[10]).Interior.Color = Excel.XlRgbColor.rgbLightBlue;
                        }
                        ((Excel.Range)workSheet.Rows[10]).Insert();
                    }
                    ((Excel.Range)workSheet.Rows[9]).Delete();
                    ((Excel.Range)workSheet.Rows[9]).Delete();
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
        }
        void exportCnc(string selectFolder)
        {
            string fileSourcePath = Application.StartupPath + "\\Templates\\PhongSXLR\\ChiThi.xls";
            string localPath = selectFolder + "/" + _projectDirection.ProjectCode + ".CTSX." + _projectDirection.ID + "/" + _projectDirection.ProjectCode + "-CTSX.CNC";
            //string localPath = selectFolder + "/CNC";
            Directory.CreateDirectory(localPath);
            //string filePath = localPath + "/Chi_Thi_CNC.xls";
            string filePath = localPath + "/" + _projectDirection.ProjectCode + "-CTSX.CNC.xls";
            try
            {
                File.Copy(fileSourcePath, filePath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: File excel đang được mở." + Environment.NewLine + ex.Message);
                return;
            }

            DocUtils.InitFTPQLSX();
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo chỉ thị CNC..."))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Application app = default(Excel.Application);
                Excel.Workbook workBoook = default(Excel.Workbook);
                Excel.Worksheet workSheet = default(Excel.Worksheet);
                try
                {
                    app = new Excel.Application();
                    app.Workbooks.Open(filePath);
                    workBoook = app.Workbooks[1];
                    workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                    workSheet.Cells[5, 3] = _projectDirection.ID;
                    workSheet.Cells[2, 7] = _projectDirection.ProjectCode;
                    workSheet.Cells[4, 2] = "PHÒNG/ TỔ: CNC";

                    DataRow[] drsIn = _dtData.Select("ProjectDirectionTypeID = 1 and IsDeleted = 0", "PartsCode ASC");
                    for (int i = 0; i < drsIn.Length; i++)
                    {
                        string moduleCode = TextUtils.ToString(drsIn[i]["ModuleCode"]);
                        string moduleGroup = moduleCode.Substring(0, 6);
                        //string serverPathMat = string.Format(@"/Thietke.Ck/{0}/{1}.Ck/MAT.{1}", moduleGroup, moduleCode);
                        //string serverPathCad = string.Format(@"/Thietke.Ck/{0}/{1}.Ck/CAD.{1}", moduleGroup, moduleCode);

                        string stt = TextUtils.ToString(drsIn[i]["STT"]);
                        string partsCode = TextUtils.ToString(drsIn[i]["PartsCode"]);
                        string partsName = TextUtils.ToString(drsIn[i]["PartsName"]);
                        decimal qty = TextUtils.ToDecimal(drsIn[i]["Qty"]);
                        decimal makeTime = TextUtils.ToDecimal(drsIn[i]["MakeTime"]);
                        string userName = TextUtils.ToString(drsIn[i]["UserName"]);
                        DateTime? startDateDK = TextUtils.ToDate2(drsIn[i]["StartDateDK"]);
                        DateTime? endDateDK = TextUtils.ToDate2(drsIn[i]["EndDateDK"]);
                        string vatLieu = TextUtils.ToString(drsIn[i]["Material"]);
                        //string fileName = TextUtils.ToString(drsIn[i]["FileName"]);
                        string filePath1 = TextUtils.ToString(drsIn[i]["FilePath"]);
                        string note = TextUtils.ToString(drsIn[i]["Note"]);
                        DocUtils.DownloadFile(localPath, Path.GetFileName(filePath1), filePath1);

                        workSheet.Cells[10, 1] = stt;
                        workSheet.Cells[10, 2] = partsName;
                        workSheet.Cells[10, 3] = partsCode;
                        workSheet.Cells[10, 4] = moduleCode;
                        workSheet.Cells[10, 5] = qty;
                        workSheet.Cells[10, 6] = makeTime;
                        //workSheet.Cells[10, 6] = stt;
                        workSheet.Cells[10, 8] = userName;
                        workSheet.Cells[10, 9] = startDateDK != null ? startDateDK.Value.ToString("dd/MM/yyyy") : "";
                        workSheet.Cells[10, 10] = endDateDK != null ? endDateDK.Value.ToString("dd/MM/yyyy") : "";
                        workSheet.Cells[10, 18] = vatLieu;
                        workSheet.Cells[10, 24] = note;
                        if (note != "")
                        {
                            ((Excel.Range)workSheet.Rows[10]).Interior.Color = Excel.XlRgbColor.rgbLightBlue;
                        }
                        ((Excel.Range)workSheet.Rows[10]).Insert();
                    }
                    ((Excel.Range)workSheet.Rows[9]).Delete();
                    ((Excel.Range)workSheet.Rows[9]).Delete();
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
        }
        void exportAl(string selectFolder)
        {
            string fileSourcePath = Application.StartupPath + "\\Templates\\PhongSXLR\\ChiThi.xls";
            string localPath = selectFolder + "/" + _projectDirection.ProjectCode + ".CTSX." + _projectDirection.ID + "/" + _projectDirection.ProjectCode + "-CTSX.GCAL";
            //string localPath = selectFolder + "/GCAL";
            Directory.CreateDirectory(localPath);
            //string filePath = localPath + "/Chi_Thi_GCAL.xls";
            string filePath = localPath + "/" + _projectDirection.ProjectCode + "-CTSX.GCAL.xls";
            try
            {
                File.Copy(fileSourcePath, filePath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: File excel đang được mở." + Environment.NewLine + ex.Message);
                return;
            }

            DocUtils.InitFTPQLSX();
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo chỉ thị Gia công nhôm..."))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Application app = default(Excel.Application);
                Excel.Workbook workBoook = default(Excel.Workbook);
                Excel.Worksheet workSheet = default(Excel.Worksheet);
                try
                {
                    app = new Excel.Application();
                    app.Workbooks.Open(filePath);
                    workBoook = app.Workbooks[1];
                    workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                    workSheet.Cells[5, 3] = _projectDirection.ID;
                    workSheet.Cells[2, 7] = _projectDirection.ProjectCode;
                    workSheet.Cells[4, 2] = "PHÒNG/ TỔ: Gia công AL";

                    DataRow[] drsIn = _dtData.Select("ProjectDirectionTypeID = 3 and IsDeleted = 0", "PartsCode ASC");
                    for (int i = 0; i < drsIn.Length; i++)
                    {
                        string moduleCode = TextUtils.ToString(drsIn[i]["ModuleCode"]);
                        string moduleGroup = moduleCode.Substring(0, 6);
                        //string serverPathMat = string.Format(@"/Thietke.Ck/{0}/{1}.Ck/MAT.{1}", moduleGroup, moduleCode);
                        //string serverPathCad = string.Format(@"/Thietke.Ck/{0}/{1}.Ck/CAD.{1}", moduleGroup, moduleCode);

                        string stt = TextUtils.ToString(drsIn[i]["STT"]);
                        string partsCode = TextUtils.ToString(drsIn[i]["PartsCode"]);
                        string partsName = TextUtils.ToString(drsIn[i]["PartsName"]);
                        decimal qty = TextUtils.ToDecimal(drsIn[i]["Qty"]);
                        decimal makeTime = TextUtils.ToDecimal(drsIn[i]["MakeTime"]);
                        string userName = TextUtils.ToString(drsIn[i]["UserName"]);
                        DateTime? startDateDK = TextUtils.ToDate2(drsIn[i]["StartDateDK"]);
                        DateTime? endDateDK = TextUtils.ToDate2(drsIn[i]["EndDateDK"]);
                        string vatLieu = TextUtils.ToString(drsIn[i]["Material"]);
                        //string fileName = TextUtils.ToString(drsIn[i]["FileName"]);
                        string filePath1 = TextUtils.ToString(drsIn[i]["FilePath"]);
                        string note = TextUtils.ToString(drsIn[i]["Note"]);

                        DocUtils.DownloadFile(localPath, Path.GetFileName(filePath1), filePath1);

                        workSheet.Cells[10, 1] = stt;
                        workSheet.Cells[10, 2] = partsName;
                        workSheet.Cells[10, 3] = partsCode;
                        workSheet.Cells[10, 4] = moduleCode;
                        workSheet.Cells[10, 5] = qty;
                        workSheet.Cells[10, 6] = makeTime;
                        //workSheet.Cells[10, 6] = stt;
                        workSheet.Cells[10, 8] = userName;
                        workSheet.Cells[10, 9] = startDateDK != null ? startDateDK.Value.ToString("dd/MM/yyyy") : "";
                        workSheet.Cells[10, 10] = endDateDK != null ? endDateDK.Value.ToString("dd/MM/yyyy") : "";
                        workSheet.Cells[10, 18] = vatLieu;
                        workSheet.Cells[10, 24] = note;
                        //workSheet.Cells[10, 18] = moduleCode;
                        if (note != "")
                        {
                            ((Excel.Range)workSheet.Rows[10]).Interior.Color = Excel.XlRgbColor.rgbLightBlue;
                        }
                        ((Excel.Range)workSheet.Rows[10]).Insert();
                    }
                    ((Excel.Range)workSheet.Rows[9]).Delete();
                    ((Excel.Range)workSheet.Rows[9]).Delete();
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
        }
        void exportDT(string selectFolder)
        {
            string fileSourcePath = Application.StartupPath + "\\Templates\\PhongSXLR\\ChiThi.xls";
            string localPath = selectFolder + "/" + _projectDirection.ProjectCode + ".CTSX." + _projectDirection.ID + "/" + _projectDirection.ProjectCode + "-CTSX.DIENTU";
            //string localPath = selectFolder + "/DT";
            Directory.CreateDirectory(localPath);
            //string filePath = localPath + "/Chi_Thi_DT.xls";
            string filePath = localPath + "/" + _projectDirection.ProjectCode + "-CTSX.DIENTU.xls";
            try
            {
                File.Copy(fileSourcePath, filePath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: File excel đang được mở." + Environment.NewLine + ex.Message);
                return;
            }

            DocUtils.InitFTPQLSX();
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo chỉ thị Điện tử..."))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Application app = default(Excel.Application);
                Excel.Workbook workBoook = default(Excel.Workbook);
                Excel.Worksheet workSheet = default(Excel.Worksheet);
                try
                {
                    app = new Excel.Application();
                    app.Workbooks.Open(filePath);
                    workBoook = app.Workbooks[1];
                    workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                    workSheet.Cells[5, 3] = _projectDirection.ID;
                    workSheet.Cells[2, 7] = _projectDirection.ProjectCode;
                    workSheet.Cells[4, 2] = "PHÒNG/ TỔ: Điện tử";

                    DataRow[] drsIn = _dtData.Select("ProjectDirectionTypeID = 4 and IsDeleted = 0", "PartsCode ASC");
                    for (int i = 0; i < drsIn.Length; i++)
                    {
                        string moduleCode = TextUtils.ToString(drsIn[i]["ModuleCode"]);
                        string moduleGroup = moduleCode.Substring(0, 6);
                        //string serverPathMat = string.Format(@"/Thietke.Ck/{0}/{1}.Ck/MAT.{1}", moduleGroup, moduleCode);
                        //string serverPathCad = string.Format(@"/Thietke.Ck/{0}/{1}.Ck/CAD.{1}", moduleGroup, moduleCode);

                        string stt = TextUtils.ToString(drsIn[i]["STT"]);
                        string partsCode = TextUtils.ToString(drsIn[i]["PartsCode"]);
                        string partsName = TextUtils.ToString(drsIn[i]["PartsName"]);
                        decimal qty = TextUtils.ToDecimal(drsIn[i]["Qty"]);
                        decimal makeTime = TextUtils.ToDecimal(drsIn[i]["MakeTime"]);
                        string userName = TextUtils.ToString(drsIn[i]["UserName"]);
                        DateTime? startDateDK = TextUtils.ToDate2(drsIn[i]["StartDateDK"]);
                        DateTime? endDateDK = TextUtils.ToDate2(drsIn[i]["EndDateDK"]);
                        string vatLieu = TextUtils.ToString(drsIn[i]["Material"]);
                        //string fileName = TextUtils.ToString(drsIn[i]["FileName"]);
                        string filePath1 = TextUtils.ToString(drsIn[i]["FilePath"]);
                        string note = TextUtils.ToString(drsIn[i]["Note"]);

                        DocUtils.DownloadFile(localPath, Path.GetFileName(filePath1), filePath1);

                        workSheet.Cells[10, 1] = stt;
                        workSheet.Cells[10, 2] = partsName;
                        workSheet.Cells[10, 3] = partsCode;
                        workSheet.Cells[10, 4] = moduleCode;
                        workSheet.Cells[10, 5] = qty;
                        workSheet.Cells[10, 6] = makeTime;
                        //workSheet.Cells[10, 6] = stt;
                        workSheet.Cells[10, 8] = userName;
                        workSheet.Cells[10, 9] = startDateDK != null ? startDateDK.Value.ToString("dd/MM/yyyy") : "";
                        workSheet.Cells[10, 10] = endDateDK != null ? endDateDK.Value.ToString("dd/MM/yyyy") : "";
                        workSheet.Cells[10, 18] = vatLieu;
                        workSheet.Cells[10, 24] = note;
                        //workSheet.Cells[10, 18] = moduleCode;
                        if (note != "")
                        {
                            ((Excel.Range)workSheet.Rows[10]).Interior.Color = Excel.XlRgbColor.rgbLightBlue;
                        }
                        ((Excel.Range)workSheet.Rows[10]).Insert();
                    }
                    ((Excel.Range)workSheet.Rows[9]).Delete();
                    ((Excel.Range)workSheet.Rows[9]).Delete();
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
        }
        void exportLR(string selectFolder)
        {
            string fileSourcePath = Application.StartupPath + "\\Templates\\PhongSXLR\\ChiThi.xls";
            string localPath = selectFolder + "/" + _projectDirection.ProjectCode + ".CTSX." + _projectDirection.ID + "/" + _projectDirection.ProjectCode + "-CTSX.LR";
            Directory.CreateDirectory(localPath);
            string filePath = localPath + "/" + _projectDirection.ProjectCode + "-CTSX.LR.xls";
            try
            {
                File.Copy(fileSourcePath, filePath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: File excel đang được mở." + Environment.NewLine + ex.Message);
                return;
            }

            DocUtils.InitFTPQLSX();

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo chỉ thị LR..."))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Application app = default(Excel.Application);
                Excel.Workbook workBoook = default(Excel.Workbook);
                Excel.Worksheet workSheet = default(Excel.Worksheet);
                try
                {
                    app = new Excel.Application();
                    app.Workbooks.Open(filePath);
                    workBoook = app.Workbooks[1];
                    workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                    workSheet.Cells[5, 3] = _projectDirection.ID;
                    workSheet.Cells[2, 7] = _projectDirection.ProjectCode;
                    workSheet.Cells[4, 2] = "PHÒNG/ TỔ: Lắp ráp";

                    DataRow[] drsLR = _dtData.Select("ProjectDirectionTypeID > 4 and IsDeleted = 0", "PartsCode ASC");
                    for (int i = 0; i < drsLR.Length; i++)
                    {
                        string moduleCode = TextUtils.ToString(drsLR[i]["ModuleCode"]);
                        string moduleGroup = moduleCode.Substring(0, 6);

                        DataTable dtStructureFile = TextUtils.Select("select * from vPBDL_Structure_File where [PBDLStructureID] in (13,15)");
                        DataTable dtDMVT = LibQLSX.Select("select * from MaterialModuleLink where ModuleCode = '" + moduleCode + "'");
                        foreach (DataRow row in dtStructureFile.Rows)
                        {
                            string pathServer = TextUtils.ToString(row["FolderContain"]).Replace("group", moduleGroup).Replace("code", moduleCode);
                            string folderName = localPath + '/' + moduleCode + "/" + TextUtils.ToString(row["Name"]);
                            string filterDonVi = TextUtils.ToString(row["FilterDonVi"]);
                            string extension = TextUtils.ToString(row["Extension"]);
                            int getType = TextUtils.ToInt(row["GetType"]);
                            Directory.CreateDirectory(folderName);
                            if (getType == 1)
                            {
                                if (DocUtils.CheckExits(pathServer))
                                {
                                    DocUtils.DownloadFile(folderName, Path.GetFileName(pathServer), pathServer);
                                }
                            }
                            else
                            {
                                DataRow[] listDonVi = dtDMVT.Select("Unit = '" + filterDonVi + "'");
                                foreach (DataRow rowMVL in listDonVi)
                                {
                                    string fileName = TextUtils.ToString(rowMVL["Code"]);
                                    try
                                    {
                                        if (DocUtils.CheckExits(pathServer + "/" + fileName + extension))
                                        {
                                            DocUtils.DownloadFile(folderName, fileName + extension, pathServer + "/" + fileName + extension);
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }

                        string stt = TextUtils.ToString(drsLR[i]["STT"]);
                        string partsCode = TextUtils.ToString(drsLR[i]["PartsCode"]);
                        string partsName = TextUtils.ToString(drsLR[i]["PartsName"]);
                        decimal qty = TextUtils.ToDecimal(drsLR[i]["Qty"]);
                        decimal makeTime = TextUtils.ToDecimal(drsLR[i]["MakeTime"]);
                        string userName = TextUtils.ToString(drsLR[i]["UserName"]);
                        DateTime? startDateDK = TextUtils.ToDate2(drsLR[i]["StartDateDK"]);
                        DateTime? endDateDK = TextUtils.ToDate2(drsLR[i]["EndDateDK"]);
                        string vatLieu = TextUtils.ToString(drsLR[i]["Material"]);
                        string note = TextUtils.ToString(drsLR[i]["Note"]);

                        workSheet.Cells[10, 1] = stt;
                        workSheet.Cells[10, 2] = partsName;
                        workSheet.Cells[10, 3] = partsCode;
                        workSheet.Cells[10, 4] = moduleCode;
                        workSheet.Cells[10, 5] = qty;
                        workSheet.Cells[10, 6] = makeTime;
                        //workSheet.Cells[10, 6] = stt;
                        workSheet.Cells[10, 8] = userName;
                        workSheet.Cells[10, 9] = startDateDK != null ? startDateDK.Value.ToString("dd/MM/yyyy") : "";
                        workSheet.Cells[10, 10] = endDateDK != null ? endDateDK.Value.ToString("dd/MM/yyyy") : "";
                        workSheet.Cells[10, 18] = vatLieu;
                        workSheet.Cells[10, 24] = note;
                        //workSheet.Cells[10, 18] = moduleCode;
                        if (note != "")
                        {
                            ((Excel.Range)workSheet.Rows[10]).Interior.Color = Excel.XlRgbColor.rgbLightBlue;
                        }
                        ((Excel.Range)workSheet.Rows[10]).Insert();
                    }
                    ((Excel.Range)workSheet.Rows[9]).Delete();
                    ((Excel.Range)workSheet.Rows[9]).Delete();
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
        }
        void exportLRCN(string selectFolder)
        {
            string fileSourcePath = Application.StartupPath + "\\Templates\\PhongSXLR\\ChiThi.xls";
            string localPath = selectFolder + "/" + _projectDirection.ProjectCode + ".CTSX." + _projectDirection.ID + "/" + _projectDirection.ProjectCode + "-CTSX.LR";
            Directory.CreateDirectory(localPath);
            string filePath = localPath + "/" + _projectDirection.ProjectCode + "-CTSX.LR.xls";
            try
            {
                File.Copy(fileSourcePath, filePath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: File excel đang được mở." + Environment.NewLine + ex.Message);
                return;
            }

            DocUtils.InitFTPQLSX();

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo chỉ thị LR..."))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Application app = default(Excel.Application);
                Excel.Workbook workBoook = default(Excel.Workbook);
                Excel.Worksheet workSheet = default(Excel.Worksheet);
                try
                {
                    app = new Excel.Application();
                    app.Workbooks.Open(filePath);
                    workBoook = app.Workbooks[1];
                    workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                    workSheet.Cells[5, 3] = _projectDirection.ID;
                    workSheet.Cells[2, 7] = _projectDirection.ProjectCode;
                    workSheet.Cells[4, 2] = "PHÒNG/ TỔ: Lắp ráp";

                    #region Download file
                    DataTable dtModule = TextUtils.GetDistinctDatatable(_dtData, "ModuleCode");
                    foreach (DataRow item in dtModule.Rows)
                    {
                        string moduleCode = TextUtils.ToString(item["ModuleCode"]);
                        string moduleGroup = moduleCode.Substring(0, 6);

                        DataTable dtStructureFile = TextUtils.Select("select * from vPBDL_Structure_File where [PBDLStructureID] in (13,15)");
                        DataTable dtDMVT = LibQLSX.Select("select * from MaterialModuleLink where ModuleCode = '" + moduleCode + "'");
                        foreach (DataRow row in dtStructureFile.Rows)
                        {
                            string pathServer = TextUtils.ToString(row["FolderContain"]).Replace("group", moduleGroup).Replace("code", moduleCode);
                            string folderName = localPath + '/' + moduleCode + "/" + TextUtils.ToString(row["Name"]);
                            string filterDonVi = TextUtils.ToString(row["FilterDonVi"]);
                            string extension = TextUtils.ToString(row["Extension"]);
                            int getType = TextUtils.ToInt(row["GetType"]);
                            Directory.CreateDirectory(folderName);
                            if (getType == 1)
                            {
                                if (DocUtils.CheckExits(pathServer))
                                {
                                    DocUtils.DownloadFile(folderName, Path.GetFileName(pathServer), pathServer);
                                }
                            }
                            else
                            {
                                DataRow[] listDonVi = dtDMVT.Select("Unit = '" + filterDonVi + "'");
                                foreach (DataRow rowMVL in listDonVi)
                                {
                                    string fileName = TextUtils.ToString(rowMVL["Code"]);
                                    try
                                    {
                                        if (DocUtils.CheckExits(pathServer + "/" + fileName + extension))
                                        {
                                            DocUtils.DownloadFile(folderName, fileName + extension, pathServer + "/" + fileName + extension);
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    #region Export Excel
                    DataRow[] drsIn = _dtData.Select("ProjectDirectionTypeID > 4 and IsDeleted = 0", "PartsCode ASC");
                    for (int i = 0; i < drsIn.Length; i++)
                    {
                        string moduleCode1 = TextUtils.ToString(drsIn[i]["ModuleCode"]);
                        string moduleGroup1 = moduleCode1.Substring(0, 6);

                        //string cadPathServer = string.Format("Thietke.Ck/{0}/{1}.Ck/CAD.{1}", moduleGroup, moduleCode);
                        //string cadPathServerBC = string.Format("Thietke.Ck/{0}/{1}.Ck/BCCk.{1}/BC-CAD.{1}", moduleGroup, moduleCode);

                        string stt = TextUtils.ToString(drsIn[i]["STT"]);
                        string partsCode = TextUtils.ToString(drsIn[i]["PartsCode"]);
                        string partsName = TextUtils.ToString(drsIn[i]["PartsName"]);
                        decimal qty = TextUtils.ToDecimal(drsIn[i]["Qty"]);
                        decimal makeTime = TextUtils.ToDecimal(drsIn[i]["MakeTime"]);
                        string userName = TextUtils.ToString(drsIn[i]["UserName"]);
                        DateTime? startDateDK = TextUtils.ToDate2(drsIn[i]["StartDateDK"]);
                        DateTime? endDateDK = TextUtils.ToDate2(drsIn[i]["EndDateDK"]);
                        string vatLieu = TextUtils.ToString(drsIn[i]["Material"]);
                        string note = TextUtils.ToString(drsIn[i]["Note"]);

                        workSheet.Cells[10, 1] = stt;
                        workSheet.Cells[10, 2] = partsName;
                        workSheet.Cells[10, 3] = partsCode;
                        workSheet.Cells[10, 4] = moduleCode1;
                        workSheet.Cells[10, 5] = qty;
                        workSheet.Cells[10, 6] = makeTime;
                        //workSheet.Cells[10, 6] = stt;
                        workSheet.Cells[10, 8] = userName;
                        workSheet.Cells[10, 9] = startDateDK != null ? startDateDK.Value.ToString("dd/MM/yyyy") : "";
                        workSheet.Cells[10, 10] = endDateDK != null ? endDateDK.Value.ToString("dd/MM/yyyy") : "";
                        workSheet.Cells[10, 18] = vatLieu;
                        workSheet.Cells[10, 24] = note;
                        //workSheet.Cells[10, 18] = moduleCode;
                        if (note != "")
                        {
                            ((Excel.Range)workSheet.Rows[10]).Interior.Color = Excel.XlRgbColor.rgbLightBlue;
                        }
                        ((Excel.Range)workSheet.Rows[10]).Insert();
                    }
                    ((Excel.Range)workSheet.Rows[9]).Delete();
                    ((Excel.Range)workSheet.Rows[9]).Delete();
                    #endregion
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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (grvTong.RowCount == 0)
                return;

            for (int i = 0; i < grvTong.RowCount; i++)
            {
                ProjectDirectionDetailModel model = new ProjectDirectionDetailModel();
                long id = TextUtils.ToInt64(grvTong.GetRowCellValue(i, colID));
                if (id > 0)
                {
                    model = (ProjectDirectionDetailModel)ProjectDirectionDetailBO.Instance.FindByPK(id);
                }

                model.EndDate = TextUtils.ToDate2(grvTong.GetRowCellValue(i, colEndDate));
                model.EndDateDK = TextUtils.ToDate2(grvTong.GetRowCellValue(i, colEndDateDK));
                model.FilePath = TextUtils.ToString(grvTong.GetRowCellValue(i, colFilePath));
                model.MakeTime = TextUtils.ToDecimal(grvTong.GetRowCellValue(i, colMakeTime));
                model.Material = TextUtils.ToString(grvTong.GetRowCellValue(i, colMaterial));
                model.MaVatLieu = TextUtils.ToString(grvTong.GetRowCellValue(i, colMaVatLieu));
                model.ModuleCode = TextUtils.ToString(grvTong.GetRowCellValue(i, colModuleCode));
                model.PartsCode = TextUtils.ToString(grvTong.GetRowCellValue(i, colPartsCode));
                model.PartsName = TextUtils.ToString(grvTong.GetRowCellValue(i, colPartsName));
                model.ProjectCode = _projectDirection.ProjectCode;
                model.ProjectDirectionID = ProjectDirectionID;
                model.ProjectDirectionTypeID = TextUtils.ToInt(grvTong.GetRowCellValue(i, colProjectDirectionTypeID));
                model.ProjectModuleId = "";
                model.Qty = TextUtils.ToDecimal(grvTong.GetRowCellValue(i, colQty));
                model.StartDate = TextUtils.ToDate2(grvTong.GetRowCellValue(i, colStartDate));
                model.StartDateDK = TextUtils.ToDate2(grvTong.GetRowCellValue(i, colStartDateDK));
                model.EndDate = TextUtils.ToDate2(grvTong.GetRowCellValue(i, colEndDate));
                model.EndDateDK = TextUtils.ToDate2(grvTong.GetRowCellValue(i, colEndDateDK));
                model.STT = TextUtils.ToString(grvTong.GetRowCellValue(i, colSTT));
                model.ThongSo = "TPA";
                model.Unit = TextUtils.ToString(grvTong.GetRowCellValue(i, colUnit));
                model.UserId = TextUtils.ToString(grvTong.GetRowCellValue(i, colUserId));

                if (id > 0)
                {
                    ProjectDirectionDetailBO.Instance.Update(model);
                }
                else
                {
                    model.IsNew = 1;
                    model.IsDeleted = 0;
                    model.CreatedBy = Global.AppUserName;
                    model.CreatedDate = DateTime.Now;
                    ProjectDirectionDetailBO.Instance.Insert(model);
                }
            }

            loadGrid();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            long id = TextUtils.ToInt64(grvTong.GetFocusedRowCellValue(colID));
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa đối tượng này?",TextUtils.Caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (id > 0)
                {
                    ProjectDirectionDetailModel model = (ProjectDirectionDetailModel)ProjectDirectionDetailBO.Instance.FindByPK(id);
                    model.IsDeleted = 1;
                    ProjectDirectionDetailBO.Instance.Update(model);
                    //ProjectDirectionDetailBO.Instance.Delete(id);
                    loadGrid();
                }
                else
                {
                    grvTong.DeleteSelectedRows();
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (_dtData.Rows.Count == 0) return;

            string selectFolder = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                selectFolder = fbd.SelectedPath;
            }
            else
            {
                return;
            }
            exportIn(selectFolder);
            exportCnc(selectFolder);
            exportAl(selectFolder);
            exportDT(selectFolder);
            exportLR(selectFolder);

            MessageBox.Show("Xuất chỉ thị thành công!",TextUtils.Caption,MessageBoxButtons.OK,MessageBoxIcon.Information);
            Process.Start("explorer.exe", "/select, " + selectFolder + "/" + _projectDirection.ProjectCode + ".CTSX" + _projectDirection.ID);
        }
       
        private void btnExportIn_Click(object sender, EventArgs e)
        {
            if (_dtData.Rows.Count == 0) return;

            string selectFolder = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                selectFolder = fbd.SelectedPath;
            }
            else
            {
                return;
            }

             exportIn(selectFolder);

             MessageBox.Show("Xuất chỉ thị thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }        

        private void btnExportCnc_Click(object sender, EventArgs e)
        {
            if (_dtData.Rows.Count == 0) return;

            string selectFolder = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                selectFolder = fbd.SelectedPath;
            }
            else
            {
                return;
            }
            exportCnc(selectFolder);
            MessageBox.Show("Xuất chỉ thị thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
       
        private void btnExportAl_Click(object sender, EventArgs e)
        {
            if (_dtData.Rows.Count == 0) return;

            string selectFolder = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                selectFolder = fbd.SelectedPath;
            }
            else
            {
                return;
            }
            exportAl(selectFolder);
            MessageBox.Show("Xuất chỉ thị thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      
        private void btnDT_Click(object sender, EventArgs e)
        {
            if (_dtData.Rows.Count == 0) return;

            string selectFolder = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                selectFolder = fbd.SelectedPath;
            }
            else
            {
                return;
            }

            exportDT(selectFolder);
            MessageBox.Show("Xuất chỉ thị thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }        

        private void btnLR_Click(object sender, EventArgs e)
        {
            if (_dtData.Rows.Count == 0) return;

            string selectFolder = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                selectFolder = fbd.SelectedPath;
            }
            else
            {
                return;
            }

            exportLR(selectFolder);
            MessageBox.Show("Xuất chỉ thị thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void grvTong_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column != colSTT) return;
            int isNew = TextUtils.ToInt(grvTong.GetRowCellValue(e.RowHandle,colIsNew));
            int isDeleted = TextUtils.ToInt(grvTong.GetRowCellValue(e.RowHandle, colIsDeleted));
            if (isNew > 0)
            {
                e.Appearance.BackColor = Color.GreenYellow;
            }
            if (isDeleted>0)
            {
                e.Appearance.BackColor = Color.Red;
            }            
        }

        private void btnExportLRCN_Click(object sender, EventArgs e)
        {
            if (_dtData.Rows.Count == 0) return;

            string selectFolder = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                selectFolder = fbd.SelectedPath;
            }
            else
            {
                return;
            }

            exportLRCN(selectFolder);
            MessageBox.Show("Xuất chỉ thị thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSetUser_Click(object sender, EventArgs e)
        {
            if (cboUser.EditValue != null)
            {
                foreach (int i in grvTong.GetSelectedRows())
                {
                    grvTong.SetRowCellValue(i, colUserId, TextUtils.ToString(cboUser.EditValue));
                }
            }
        }
    }
}
