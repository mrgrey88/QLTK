using DevExpress.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Business;
using TPA.Model;
using TPA.Utils;

namespace BMS
{
    public partial class frmListModuleOfProjectTPAD : _Forms
    {
        public frmListModuleOfProjectTPAD()
        {
            InitializeComponent();
        }

        private void frmListPartOfModule_Load(object sender, EventArgs e)
        {
            loadProject();        
        }

        void loadProject()
        {
            try
            {
                //DataTable tbl = LibQLSX.Select("exec spGetAllProject");
                DataTable tbl = LibQLSX.Select("select * from Project");
                TextUtils.PopulateCombo(cboProject, tbl, "ProjectCode", "ProjectId", "");
            }
            catch (Exception ex)
            {
            }
        }

        DataTable _dtData = new DataTable();
        void loadGrid()
        {
            string projectCode = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colProjectCode));
            try
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load danh sách thiết bị..."))
                {
                    _dtData = LibQLSX.Select("exec spGetProductOfProjectTPAD '" + projectCode + "'");
                    grdData.DataSource = _dtData;                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnReloadData_Click(object sender, EventArgs e)
        {
            loadGrid();
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            string projectModuleCode = TextUtils.ToString(grvData.GetFocusedRowCellValue(colCodeTK));
            if (projectModuleCode == "") return;
            frmListPartOfModule frm = new frmListPartOfModule();
            frm.ProjectModuleId = TextUtils.ToString(grvData.GetFocusedRowCellValue(colProjectModuleId));
            frm.ModuleCode = projectModuleCode;
            frm.ProjectId = TextUtils.ToString(cboProject.EditValue);
            frm.TotalReal = TextUtils.ToDecimal(grvData.GetFocusedRowCellValue(colQty));
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

        private void btnShowDMVT_Click(object sender, EventArgs e)
        {
            string code = TextUtils.ToString(grvData.GetFocusedRowCellValue(colCodeTK));
            string name = TextUtils.ToString(grvData.GetFocusedRowCellValue(colNameTK));
            DataTable dtDMVT = new DataTable();
            dtDMVT = LibQLSX.Select("select * from vMaterialModuleLink with(nolock) where ModuleCode = '" + code + "' order by ID");
            frmViewDMVT frm = new frmViewDMVT();
            frm.Name = name;
            frm.Code = code;
            frm.DtDMVT = dtDMVT.Copy();
            frm.Show();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < grvData.RowCount; i++)
            {
                grvData.SetRowCellValue(i, colCheck, chkAll.Checked);
            }        
        }

        private void btnCreateChiThiCN_Click(object sender, EventArgs e)
        {
            DocUtils.InitFTPQLSX();
            grvData.FocusedRowHandle = -1;

            DataTable dtDirectionType = LibQLSX.Select("SELECT * FROM [ProjectDirectionType]");
            //DataTable dtMaterialModel = LibQLSX.Select("SELECT * FROM [MaterialsModel]");
            string projectCode = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colProjectCode));
            DataRow[] drs = _dtData.Select("Check = 1 and (ProjectDirectionID is null or ProjectDirectionID = 0)");
            if (drs.Length == 0) return;

            ProjectDirectionModel direction = new ProjectDirectionModel();
            direction.Code = "";
            direction.Name = "Chỉ thị ngày: " + DateTime.Now.ToString("dd/MM/yyyy");
            direction.ProjectCode = projectCode;
            direction.ProjectId = TextUtils.ToString(cboProject.EditValue);
            direction.CreatedBy = Global.AppUserName;
            direction.CreatedDate = DateTime.Now;
            direction.ID = (int)ProjectDirectionBO.Instance.Insert(direction);

            for (int i = 0; i < drs.Length; i++)
            {
                //DateTime maxDate = new DateTime(1990, 1, 1);
                string moduleCode = TextUtils.ToString(drs[i]["ProjectModuleCode"]);                
                decimal parentQty = TextUtils.ToDecimal(drs[i]["TotalReal"]);
                DateTime? dateAboutE = TextUtils.ToDate2(drs[i]["DateAboutE"]);
                string projectModuleId = TextUtils.ToString(drs[i]["ProjectModuleId"]);
                string note = TextUtils.ToString(drs[i]["Note"]);

                DataTable dtLink = new DataTable();
                dtLink = TextUtils.GetDMVT(moduleCode, true);
                DataRow[] drsL = dtLink.Select("F3 = 'TPA'");
                if (drsL.Length > 0)
                {
                    dtLink = drsL.CopyToDataTable();
                }
                else
                {
                    continue;
                }
                //DataTable dtLink = LibQLSX.Select("select * from vMaterialModuleLink with(nolock) where ThongSo = 'TPA' and ModuleCode = '" + moduleCode + "'");

                string moduleGroup = moduleCode.Substring(0, 6);
                string serverPathMat = string.Format(@"/Thietke.Ck/{0}/{1}.Ck/MAT.{1}", moduleGroup, moduleCode);
                string serverPathCad = string.Format(@"/Thietke.Ck/{0}/{1}.Ck/CAD.{1}", moduleGroup, moduleCode);
                string[] array = DocUtils.GetContentList(serverPathMat);

                #region Update ProjectModule
                ArrayList arr = ProjectModuleBO.Instance.FindByAttribute("ProjectModuleId", projectModuleId);
                if (arr.Count > 0)
                {
                    ProjectModuleModel model = (ProjectModuleModel)arr[0];
                    model.ProjectDirectionID = direction.ID;
                    ProjectModuleBO.Instance.UpdateQLSX(model);
                }
                #endregion

                #region In phim
                if (array != null)
                {
                    for (int i1 = 0; i1 < array.Length; i1++)
                    {
                        string partsCode = array[i1].Split('-')[0];
                        DataRow[] drsLink = dtLink.Select("F4 = '" + partsCode + "' or F4 like '" + partsCode + "-%'");
                        decimal qty = parentQty * (drsLink.Length > 0 ? TextUtils.ToDecimal(drsLink[0]["QtyReal"]) : 1);

                        //DataTable dtDetail = LibQLSX.Select("select top 1 * from ProjectDirectionDetail where ProjectDirectionTypeID = 2 and PartsCode = '"
                        //    + partsCode + "' and ProjectDirectionID = " + direction.ID);
                        //if (dtDetail.Rows.Count > 0)
                        //{
                        //    ProjectDirectionDetailModel detail = (ProjectDirectionDetailModel)ProjectDirectionDetailBO.Instance.FindByPK(TextUtils.ToInt(dtDetail.Rows[0]["ID"]));
                        //    detail.Qty += qty;
                        //    ProjectDirectionDetailBO.Instance.Update(detail);
                        //}
                        //else
                        //{
                            ProjectDirectionDetailModel detail = new ProjectDirectionDetailModel();
                            detail.ProjectModuleId = projectModuleId;
                            detail.ProjectDirectionID = direction.ID;
                            //projectDirection.Material = TextUtils.ToString(dtLink.Rows[j]["VatLieu"]);
                            detail.ModuleCode = moduleCode;
                            detail.PartsCode = partsCode;
                            //projectDirection.PartsName = TextUtils.ToString(dtLink.Rows[j]["PartsName"]);
                            detail.ProjectCode = projectCode;

                            detail.Qty = qty;

                            //projectDirection.STT = TextUtils.ToString(dtLink.Rows[j]["STT"]);
                            detail.ThongSo = "TPA";
                            //projectDirection.Unit = TextUtils.ToString(dtLink.Rows[j]["Unit"]);
                            detail.UserId = "";

                            detail.ProjectDirectionTypeID = 2;//In
                            DataRow[] drsDirectionType = dtDirectionType.Select("ID = " + detail.ProjectDirectionTypeID);
                            detail.MakeTime = TextUtils.ToDecimal(drsDirectionType[0]["TimeDK"]);

                            detail.FilePath = serverPathMat + "/" + array[i1];
                            detail.FileName = array[i1];

                            detail.StartDateDK = null; //dateAboutE;
                            detail.EndDateDK = null; //dateAboutE != null ? dateAboutE.Value.AddHours((double)(parentQty * detail.MakeTime)) : dateAboutE;
                            detail.StartDate = null;
                            detail.EndDate = null;

                            detail.IsNew = 0;
                            detail.IsDeleted = 0;
                            detail.CreatedBy = Global.AppUserName;
                            detail.CreatedDate = DateTime.Now;

                            detail.Note = note;

                            ProjectDirectionBO.Instance.Insert(detail);
                        //}
                    }
                }

                #endregion

                #region Other
                for (int j = 0; j < dtLink.Rows.Count; j++)
                {
                    string partsCode = TextUtils.ToString(dtLink.Rows[j]["F4"]);
                    decimal qty = parentQty * TextUtils.ToDecimal(dtLink.Rows[j]["QtyReal"]);
                    string material = TextUtils.ToString(dtLink.Rows[j]["F8"]);

                    //int projectDirectionTypeID = TextUtils.ToInt(dtLink.Rows[j]["ProjectDirectionTypeID"]);
                    int projectDirectionTypeID = TextUtils.ToInt(LibQLSX.ExcuteScalar("select top 1 ProjectDirectionTypeID from MaterialsModel where MaterialsId = '" + material + "'"));
                    if (partsCode.StartsWith("PCB"))
                    {
                        projectDirectionTypeID = 4;
                    }

                    //DataTable dtDetail = LibQLSX.Select("select top 1 * from ProjectDirectionDetail where ProjectDirectionTypeID = " + projectDirectionTypeID + " and PartsCode = '"
                    //    + partsCode + "' and ProjectDirectionID = " + direction.ID);
                    //if (dtDetail.Rows.Count > 0)
                    //{
                    //    ProjectDirectionDetailModel detail = (ProjectDirectionDetailModel)ProjectDirectionDetailBO.Instance.FindByPK(TextUtils.ToInt(dtDetail.Rows[0]["ID"]));
                    //    detail.Qty += qty;
                    //    ProjectDirectionDetailBO.Instance.Update(detail);
                    //}
                    //else
                    //{
                        ProjectDirectionDetailModel detail = new ProjectDirectionDetailModel();
                        detail.ProjectModuleId = projectModuleId;
                        detail.ProjectDirectionID = direction.ID;
                        detail.Material = material;
                        detail.ModuleCode = moduleCode;
                        detail.PartsCode = partsCode;
                        detail.PartsName = TextUtils.ToString(dtLink.Rows[j]["F2"]);
                        detail.ProjectCode = projectCode;
                        detail.Qty = qty;

                        detail.STT = TextUtils.ToString(dtLink.Rows[j]["F1"]);
                        detail.ThongSo = "TPA";
                        detail.MaVatLieu = TextUtils.ToString(dtLink.Rows[j]["F5"]);
                        string unitPart = TextUtils.ToString(LibQLSX.ExcuteScalar("select top 1 Unit from Parts where PartsCode = N'" + detail.MaVatLieu + "'"));
                        //detail.Unit = TextUtils.ToString(dtLink.Rows[j]["F6"]);
                        detail.Unit = unitPart;
                        detail.UserId = "";

                        detail.ProjectDirectionTypeID = projectDirectionTypeID;

                        if (detail.PartsCode.StartsWith("PCB"))
                        {
                            string serverPathPCB = string.Format("/Thietke.Dt/PCB/{0}/PRD.{0}/", detail.PartsCode);
                            detail.FilePath = serverPathPCB + "TPAT." + detail.PartsCode.Substring(4, 7) + ".doc";//PCB.B060101
                            detail.FileName = "TPAT." + detail.PartsCode.Substring(4, 7) + ".doc"; 
                            detail.StartDateDK = dateAboutE;
                            detail.EndDateDK = dateAboutE != null ? dateAboutE.Value.AddHours((double)(parentQty * detail.MakeTime)) : dateAboutE;
                        }
                        else
                        {
                            detail.FilePath = serverPathCad + "/" + detail.PartsCode + ".dwg";
                            detail.FileName = detail.PartsCode + ".dwg";
                            detail.StartDateDK = null; //dateAboutE;
                            detail.EndDateDK = null; //dateAboutE != null ? dateAboutE.Value.AddHours((double)(parentQty * detail.MakeTime)) : dateAboutE;
                        }

                        DataRow[] drsDirectionType = dtDirectionType.Select("ID = " + detail.ProjectDirectionTypeID);
                        detail.MakeTime = drsDirectionType.Length > 0 ? TextUtils.ToDecimal(drsDirectionType[0]["TimeDK"]) : 0;

                        
                        detail.StartDate = null;
                        detail.EndDate = null;

                        detail.IsNew = 0;
                        detail.IsDeleted = 0;
                        detail.CreatedBy = Global.AppUserName;
                        detail.CreatedDate = DateTime.Now;

                        detail.Note = note;

                        ProjectDirectionBO.Instance.Insert(detail);

                        //if (maxDate < detail.EndDateDK)
                        //    maxDate = (DateTime)detail.EndDateDK;
                    //}
                }
                #endregion
                
                #region Lắp ráp
                DataRow[] drsLink1 = dtLink.Select("F3 = 'TPA' and F6 = 'BỘ'");
                for (int j = 0; j < drsLink1.Length; j++)
                {
                    string partsCode = TextUtils.ToString(drsLink1[j]["F4"]);
                    decimal qty = parentQty * TextUtils.ToDecimal(drsLink1[j]["QtyReal"]);
                    string material = TextUtils.ToString(drsLink1[j]["F8"]);

                    DataRow[] drsDirectionType1 = dtDirectionType.Select("Code = '" + moduleCode.Substring(0, 6) + "'");
                    int projectDirectionTypeID = TextUtils.ToInt(drsDirectionType1[0]["ID"]);
                    //decimal makeTime = TextUtils.ToInt(drsDirectionType1[0]["TimeDK"]);

                    //DataTable dtDetail = LibQLSX.Select("select top 1 * from ProjectDirectionDetail where ModuleCode = '" + moduleCode + "' and PartsCode = '"
                    //+ partsCode + "' and ProjectDirectionID = " + direction.ID + "and ProjectDirectionTypeID = " + projectDirectionTypeID);
                    //if (dtDetail.Rows.Count > 0)
                    //{
                    //    ProjectDirectionDetailModel detail = (ProjectDirectionDetailModel)ProjectDirectionDetailBO.Instance
                    //        .FindByPK(TextUtils.ToInt(dtDetail.Rows[0]["ID"]));
                    //    detail.Qty += qty;
                    //    ProjectDirectionDetailBO.Instance.Update(detail);
                    //}
                    //else
                    //{
                        ProjectDirectionDetailModel directionDetail = new ProjectDirectionDetailModel();
                        directionDetail.ProjectModuleId = projectModuleId;
                        directionDetail.ProjectDirectionID = direction.ID;
                        directionDetail.Material = TextUtils.ToString(drsLink1[j]["F8"]);
                        directionDetail.ModuleCode = moduleCode;
                        directionDetail.PartsCode = partsCode;
                        directionDetail.PartsName = TextUtils.ToString(drsLink1[j]["F2"]);
                        directionDetail.ProjectCode = projectCode;
                        directionDetail.Qty = qty;                       

                        directionDetail.STT = TextUtils.ToString(drsLink1[j]["F1"]);
                        directionDetail.ThongSo = "TPA";
                        directionDetail.Unit = "BỘ";
                        directionDetail.UserId = "";

                        //directionDetail.MakeTime = makeTime;
                        directionDetail.ProjectDirectionTypeID = projectDirectionTypeID;
                        directionDetail.FilePath = serverPathCad + "/" + directionDetail.PartsCode + ".dwg";
                        directionDetail.FileName = directionDetail.PartsCode + ".dwg";

                        directionDetail.StartDateDK = null;// maxDate;
                        directionDetail.EndDateDK = null; //directionDetail.StartDateDK != null ? directionDetail.StartDateDK.Value.AddHours((double)(directionDetail.Qty * directionDetail.MakeTime)) : directionDetail.StartDateDK;
                        directionDetail.StartDate = null;
                        directionDetail.EndDate = null;

                        directionDetail.IsNew = 0;
                        directionDetail.IsDeleted = 0;

                        directionDetail.CreatedBy = Global.AppUserName;
                        directionDetail.CreatedDate = DateTime.Now;

                        directionDetail.Note = note;

                        ProjectDirectionBO.Instance.Insert(directionDetail);
                    //}
                }
                #endregion
            }

            loadGrid();

            MessageBox.Show("Tạo chỉ thị thành công", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

            frmProjectDirection frm = new frmProjectDirection();
            frm.ProjectDirectionID = direction.ID;
            frm.Show();
        }

        private void btnCreateDirection_Click(object sender, EventArgs e)
        {
            DocUtils.InitFTPQLSX();
            grvData.FocusedRowHandle = -1;

            DataTable dtDirectionType = LibQLSX.Select("SELECT * FROM [ProjectDirectionType]");
            DataTable dtMaterialModel = LibQLSX.Select("SELECT * FROM [MaterialsModel]");
            string projectCode = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colProjectCode));
            DataRow[] drs = _dtData.Select("Check = 1 and ProjectDirectionID is null");
            if (drs.Length == 0) return;

            //ProcessTransaction pt = new ProcessTransaction();
            //pt.OpenConnection();
            //pt.BeginTransaction();

            //try
            //{
            ProjectDirectionModel direction = new ProjectDirectionModel();
            direction.Code = "";
            direction.Name = "Chỉ thị ngày: " + DateTime.Now.ToString("dd/MM/yyyy");
            direction.ProjectCode = projectCode;
            direction.ProjectId = TextUtils.ToString(cboProject.EditValue);
            direction.CreatedBy = Global.AppUserName;
            direction.CreatedDate = DateTime.Now;
            direction.ID = (int)ProjectDirectionBO.Instance.Insert(direction);

            for (int i = 0; i < drs.Length; i++)
            {
                //DateTime maxDate = new DateTime(1990, 1, 1);
                //string statusText = TextUtils.ToString(drs[i]["StatusText"]);
                //if (statusText != "") continue;
                string moduleCode = TextUtils.ToString(drs[i]["ProjectModuleCode"]);
                decimal parentQty = TextUtils.ToDecimal(drs[i]["TotalReal"]);
                DateTime? dateAboutE = TextUtils.ToDate2(drs[i]["DateAboutE"]);
                string projectModuleId = TextUtils.ToString(drs[i]["ProjectModuleId"]);
                string note = TextUtils.ToString(drs[i]["Note"]);

                DataTable dtLink = new DataTable();
                dtLink = TextUtils.GetDMVT(moduleCode, true);
                DataRow[] drsL = dtLink.Select("F3 = 'TPA'");
                if (drsL.Length > 0)
                {
                    dtLink = drsL.CopyToDataTable();
                }
                else
                {
                    continue;
                }

                //dtLink = LibQLSX.Select("select * from vMaterialModuleLink with(nolock) where ThongSo = 'TPA' and ModuleCode = '" + moduleCode + "'");
                string moduleGroup = moduleCode.Substring(0, 6);
                string serverPathMat = string.Format(@"/Thietke.Ck/{0}/{1}.Ck/MAT.{1}", moduleGroup, moduleCode);
                string serverPathCad = string.Format(@"/Thietke.Ck/{0}/{1}.Ck/CAD.{1}", moduleGroup, moduleCode);
                string[] array = DocUtils.GetContentList(serverPathMat);

                #region Update ProjectModule
                ArrayList arr = ProjectModuleBO.Instance.FindByAttribute("ProjectModuleId", projectModuleId);
                if (arr.Count > 0)
                {
                    ProjectModuleModel model = (ProjectModuleModel)arr[0];
                    model.ProjectDirectionID = direction.ID;
                    ProjectModuleBO.Instance.UpdateQLSX(model);
                }
                #endregion

                #region In phim
                if (array != null)
                {
                    for (int i1 = 0; i1 < array.Length; i1++)
                    {
                        //try
                        //{
                        string partsCode = array[i1].Split('-')[0];
                        DataRow[] drsLink = dtLink.Select("F4 = '" + partsCode + "' or F4 like '" + partsCode + "-%'");
                        decimal qty = parentQty * (drsLink.Length > 0 ? TextUtils.ToDecimal(drsLink[0]["QtyReal"]) : 1);

                        //DataTable dtDetail = LibQLSX.Select("select top 1 * from ProjectDirectionDetail where ProjectDirectionTypeID = 2 and PartsCode = '"
                        //    + partsCode + "' and ProjectDirectionID = " + direction.ID);
                        //if (dtDetail.Rows.Count > 0)
                        //{
                        //    ProjectDirectionDetailModel detail = (ProjectDirectionDetailModel)ProjectDirectionDetailBO.Instance.FindByPK(TextUtils.ToInt(dtDetail.Rows[0]["ID"]));
                        //    detail.Qty += qty;
                        //    ProjectDirectionDetailBO.Instance.Update(detail);
                        //}
                        //else
                        //{
                        ProjectDirectionDetailModel detail = new ProjectDirectionDetailModel();
                        detail.ProjectModuleId = projectModuleId;
                        detail.ProjectDirectionID = direction.ID;
                        //projectDirection.Material = TextUtils.ToString(dtLink.Rows[j]["VatLieu"]);
                        detail.ModuleCode = moduleCode;
                        detail.PartsCode = partsCode;
                        //projectDirection.PartsName = TextUtils.ToString(dtLink.Rows[j]["PartsName"]);
                        detail.ProjectCode = projectCode;

                        detail.Qty = qty;

                        //projectDirection.STT = TextUtils.ToString(dtLink.Rows[j]["STT"]);
                        detail.ThongSo = "TPA";
                        //projectDirection.Unit = TextUtils.ToString(dtLink.Rows[j]["Unit"]);
                        detail.UserId = "";

                        detail.ProjectDirectionTypeID = 2;//In
                        DataRow[] drsDirectionType = dtDirectionType.Select("ID = " + detail.ProjectDirectionTypeID);
                        detail.MakeTime = TextUtils.ToDecimal(drsDirectionType[0]["TimeDK"]);

                        detail.FilePath = serverPathMat + "/" + array[i1];
                        detail.FileName = array[i1];

                        detail.StartDateDK = null;//dateAboutE;
                        detail.EndDateDK = null;//dateAboutE != null ? dateAboutE.Value.AddHours((double)(parentQty * detail.MakeTime)) : dateAboutE;
                        detail.StartDate = null;
                        detail.EndDate = null;

                        detail.IsNew = 0;
                        detail.IsDeleted = 0;
                        detail.CreatedBy = Global.AppUserName;
                        detail.CreatedDate = DateTime.Now;

                        detail.Note = note;

                        ProjectDirectionBO.Instance.Insert(detail);
                        //}
                        //}
                        //catch (Exception)
                        //{                            
                        //    throw;
                        //}                        
                    }
                }

                #endregion

                #region Other
                for (int j = 0; j < dtLink.Rows.Count; j++)
                {
                    //try                        
                    //{
                    string partsCode = TextUtils.ToString(dtLink.Rows[j]["F4"]);
                    decimal qty = parentQty * TextUtils.ToDecimal(dtLink.Rows[j]["QtyReal"]);
                    string material = TextUtils.ToString(dtLink.Rows[j]["F8"]);

                    int projectDirectionTypeID = TextUtils.ToInt(dtLink.Rows[j]["ProjectDirectionTypeID"]);
                    if (partsCode.StartsWith("PCB"))
                    {
                        projectDirectionTypeID = 4;
                    }
                    //else
                    //{
                    //    DataRow[] drsMaterialModel = dtMaterialModel.Select("MaterialsId = '" + material + "'");
                    //    projectDirectionTypeID = drsMaterialModel.Length > 0 ? 3 : TextUtils.ToInt(drsMaterialModel[0]["ProjectDirectionTypeID"]);
                    //}

                    //DataTable dtDetail = LibQLSX.Select("select top 1 * from ProjectDirectionDetail where ProjectDirectionTypeID = " + projectDirectionTypeID + " and PartsCode = '" 
                    //    + partsCode + "' and ProjectDirectionID = " + direction.ID);
                    //if (dtDetail.Rows.Count > 0)
                    //{
                    //    ProjectDirectionDetailModel detail = (ProjectDirectionDetailModel)ProjectDirectionDetailBO.Instance.FindByPK(TextUtils.ToInt(dtDetail.Rows[0]["ID"]));
                    //    detail.Qty += qty;
                    //    ProjectDirectionDetailBO.Instance.Update(detail);
                    //}
                    //else
                    //{
                    ProjectDirectionDetailModel detail = new ProjectDirectionDetailModel();
                    detail.ProjectModuleId = projectModuleId;
                    detail.ProjectDirectionID = direction.ID;
                    detail.Material = material;
                    detail.ModuleCode = moduleCode;
                    detail.PartsCode = partsCode;
                    detail.PartsName = TextUtils.ToString(dtLink.Rows[j]["F2"]);
                    detail.ProjectCode = projectCode;
                    detail.Qty = qty;

                    detail.STT = TextUtils.ToString(dtLink.Rows[j]["F1"]);
                    detail.ThongSo = "TPA";
                    //detail.Unit = TextUtils.ToString(dtLink.Rows[j]["F6"]);
                    //detail.MaVatLieu = TextUtils.ToString(dtLink.Rows[j]["F5"]);
                    detail.MaVatLieu = TextUtils.ToString(dtLink.Rows[j]["F5"]);
                    string unitPart = TextUtils.ToString(LibQLSX.ExcuteScalar("select top 1 Unit from Parts where PartsCode = N'" + detail.MaVatLieu + "'"));
                    detail.Unit = unitPart;
                    detail.UserId = "";

                    detail.ProjectDirectionTypeID = projectDirectionTypeID;

                    if (detail.PartsCode.StartsWith("PCB"))
                    {
                        string serverPathPCB = string.Format("/Thietke.Dt/PCB/{0}/PRD.{0}/", detail.PartsCode);
                        detail.FilePath = serverPathPCB + "TPAT." + detail.PartsCode.Substring(4, 7) + ".doc";//PCB.B060101
                        detail.FileName = "TPAT." + detail.PartsCode.Substring(4, 7) + ".doc";
                        detail.StartDateDK = dateAboutE;
                        detail.EndDateDK = dateAboutE != null ? dateAboutE.Value.AddHours((double)(parentQty * detail.MakeTime)) : dateAboutE;
                    }
                    else
                    {
                        detail.FilePath = serverPathCad + "/" + detail.PartsCode + ".dwg";
                        detail.FileName = detail.PartsCode + ".dwg";
                        detail.StartDateDK = null;
                        detail.EndDateDK = null;
                    }

                    DataRow[] drsDirectionType = dtDirectionType.Select("ID = " + detail.ProjectDirectionTypeID);
                    detail.MakeTime = drsDirectionType.Length > 0 ? TextUtils.ToDecimal(drsDirectionType[0]["TimeDK"]) : 3;


                    detail.StartDate = null;
                    detail.EndDate = null;

                    detail.IsNew = 0;
                    detail.IsDeleted = 0;
                    detail.CreatedBy = Global.AppUserName;
                    detail.CreatedDate = DateTime.Now;

                    detail.Note = note;

                    ProjectDirectionBO.Instance.Insert(detail);

                    //if (maxDate < detail.EndDateDK)
                    //    maxDate = (DateTime)detail.EndDateDK;
                    //}
                    //}
                    //catch (Exception)
                    //{                            
                    //    throw;
                    //}
                }
                #endregion

                #region Lắp ráp
                //try
                //{
                //DataTable dtDetail1 = LibQLSX.Select("select top 1 * from ProjectDirectionDetail where ProjectDirectionTypeID > 4 and PartsCode = '"
                //        + moduleCode + "' and ProjectDirectionID = " + direction.ID);
                //if (dtDetail1.Rows.Count > 0)
                //{
                //    ProjectDirectionDetailModel detail = (ProjectDirectionDetailModel)ProjectDirectionDetailBO.Instance.FindByPK(TextUtils.ToInt(dtDetail1.Rows[0]["ID"]));
                //    detail.Qty += parentQty;
                //    ProjectDirectionDetailBO.Instance.Update(detail);
                //}
                //else
                //{
                ProjectDirectionDetailModel directionDetail = new ProjectDirectionDetailModel();
                directionDetail.ProjectModuleId = projectModuleId;
                directionDetail.ProjectDirectionID = direction.ID;
                //directionDetail.Material = TextUtils.ToString(dtLink.Rows[j]["VatLieu"]);
                directionDetail.ModuleCode = moduleCode;
                directionDetail.PartsCode = moduleCode;
                directionDetail.PartsName = TextUtils.ToString(drs[i]["ProjectModuleName"]);
                directionDetail.ProjectCode = projectCode;
                directionDetail.Qty = parentQty;

                //directionDetail.STT = TextUtils.ToString(dtLink.Rows[j]["STT"]);
                directionDetail.ThongSo = "TPA";
                directionDetail.Unit = "BỘ";
                directionDetail.UserId = "";
                directionDetail.FilePath = "";

                DataRow[] drsDirectionType1 = dtDirectionType.Select("Code = '" + moduleCode.Substring(0, 6) + "'");
                if (drsDirectionType1.Length > 0)
                {
                    directionDetail.ProjectDirectionTypeID = TextUtils.ToInt(drsDirectionType1[0]["ID"]);
                    directionDetail.MakeTime = TextUtils.ToDecimal(drsDirectionType1[0]["TimeDK"]);
                }
                else
                {
                    directionDetail.MakeTime = 0;
                }

                directionDetail.StartDateDK = null;//maxDate;
                directionDetail.EndDateDK = null;//directionDetail.StartDateDK != null ? directionDetail.StartDateDK.Value.AddHours((double)(directionDetail.Qty * directionDetail.MakeTime)) : directionDetail.StartDateDK;
                directionDetail.StartDate = null;
                directionDetail.EndDate = null;

                directionDetail.IsNew = 0;
                directionDetail.IsDeleted = 0;

                directionDetail.CreatedBy = Global.AppUserName;
                directionDetail.CreatedDate = DateTime.Now;

                directionDetail.Note = note;

                ProjectDirectionBO.Instance.Insert(directionDetail);
                //}
                //}
                //catch (Exception)
                //{
                //    throw;
                //}
                #endregion
            }
            //pt.CommitTransaction();
            MessageBox.Show("Tạo chỉ thị thành công", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

            frmProjectDirection frm = new frmProjectDirection();
            frm.ProjectDirectionID = direction.ID;
            frm.Show();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    pt.CloseConnection();
            //}
        }

        private void xemDanhSáchCácCụmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string projectModuleCode = TextUtils.ToString(grvData.GetFocusedRowCellValue(colCodeTK));
            if (projectModuleCode == "") return;
            string projectId = TextUtils.ToString(cboProject.EditValue);
            string projectModuleId = TextUtils.ToString(grvData.GetFocusedRowCellValue(colProjectModuleId));
            decimal qty = TextUtils.ToDecimal(grvData.GetFocusedRowCellValue(colQty));
            
            frmListCumOfModule frm = new frmListCumOfModule();
            frm.ModuleQty = qty;
            frm.ModuleCode = projectModuleCode;
            frm.ProjectId = projectId;
            frm.ProjectModuleId = projectModuleId;
            frm.Show();
        }

        private void btnExecl_Click(object sender, EventArgs e)
        {
            TextUtils.ExportExcel(grvData);
        }

        private void grvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            decimal percentVT = TextUtils.ToDecimal(grvData.GetRowCellValue(e.RowHandle, colPercentVT));
            decimal qty = TextUtils.ToDecimal(grvData.GetRowCellValue(e.RowHandle, colQty));

            if (e.Column == colPercentExport || e.Column == colPercentVT)
            {
                decimal percentExport = TextUtils.ToDecimal(grvData.GetRowCellValue(e.RowHandle, colPercentExport));
                if (percentVT >= 100 && percentExport >= 100)
                {
                    e.Appearance.BackColor = Color.GreenYellow;
                }
                if (percentVT >= 100 && percentExport < 100)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
                //if (percentVT == 0)
                //{
                //    e.Appearance.BackColor = Color.MediumTurquoise;
                //}
            }

            if (e.Column == colDateAboutE && percentVT < 100)
            {
                if (qty == 0) return;

                if (TextUtils.ToDate3(grvData.GetRowCellValue(e.RowHandle, colDateAboutE)).Date > TextUtils.ToDate3(dtpSXLRDeadline.EditValue).Date)
                {
                    e.Appearance.BackColor = Color.Red;
                }
                else
                {
                    if (TextUtils.ToInt(grvData.GetRowCellValue(e.RowHandle, colTotalDateAboutENull)) > 0)
                    {
                        e.Appearance.BackColor = Color.Orange;
                    }
                }
            }       
        }

        private void cboProject_EditValueChanged(object sender, EventArgs e)
        {
            dtpSXLRDeadline.EditValue = TextUtils.ToDate2(grvProject.GetFocusedRowCellValue(colAssemblyDeadline));
        }

        private void btnDeadlineSXLR_Click(object sender, EventArgs e)
        {
            string projectCode = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colProjectCode));
            if (dtpSXLRDeadline.EditValue != null && projectCode != "")
            {
                DateTime date = TextUtils.ToDate3(dtpSXLRDeadline.EditValue);
                LibQLSX.ExcuteSQL("update Project set AssemblyDeadline = '" + date.Year + "-" + date.Month + "-" + date.Day
                    + "' where [ProjectCode] = '" + projectCode + "'");
                string id = TextUtils.ToString(cboProject.EditValue);
                loadProject();
                cboProject.EditValue = id;

                MessageBox.Show("Thay đổi deadline SXLR thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }
    }
}
