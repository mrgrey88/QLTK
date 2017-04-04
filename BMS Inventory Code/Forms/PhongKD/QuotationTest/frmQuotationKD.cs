﻿using System;
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

namespace BMS
{
    public partial class frmQuotationKD : _Forms
    {        
        #region Variables
        public C_Quotation_KDModel CurrentQuotation = new C_Quotation_KDModel();
        public int CatID = 0;
        bool _isSaved = false;

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;
        #endregion

        public frmQuotationKD()
        {
            InitializeComponent();
        }

        private void frmQuotationKD_Load(object sender, EventArgs e)
        {
            loadDepartment();
            loadCustomer();
            loadProject();
            if (CurrentQuotation.ID > 0)
            {
                txtCode.Text = CurrentQuotation.Code;
                txtCustomerCode.Text = CurrentQuotation.CustomerCode;
                txtCustomerName.Text = CurrentQuotation.CustomerName;
                
                txtFinishCustomerCode.Text = CurrentQuotation.CustomerCodeF;
                txtFinishCustomerName.Text = CurrentQuotation.CustomerNameF;
                txtPOnumber.Text = CurrentQuotation.POnumber;
                txtProjectCode.Text = CurrentQuotation.ProjectCode;
                txtProjectName.Text = CurrentQuotation.ProjectName;

                cboStatus.SelectedIndex = CurrentQuotation.Status;
                cboDepartment.SelectedValue = CurrentQuotation.DepartmentId;
                cboIsVAT.SelectedIndex = CurrentQuotation.IsVAT;
                cboStatusNC.SelectedIndex = CurrentQuotation.StatusNC;
                cboCustomerType.SelectedIndex = CurrentQuotation.CustomerType;

                //Kinh doanh
                txtTotalDP_KD.EditValue = CurrentQuotation.TotalDP_KD;
                txtCustomerPercent.EditValue = CurrentQuotation.CustomerPercent;
                txtCustomerCash.EditValue = CurrentQuotation.CustomerCash;
                txtDeliveryTime.EditValue = CurrentQuotation.DeliveryTime;
                txtTotalVC_KD.EditValue = CurrentQuotation.TotalVC_KD;
                txtTotalBX_KD.EditValue = CurrentQuotation.TotalBX_KD;

                //San xuat
                txtTotalDP_SX.EditValue = CurrentQuotation.TotalDP_SX;
                txtTotalVCBX.EditValue = CurrentQuotation.TotalVCBX;
                txtTotalBXHB_C52.EditValue = CurrentQuotation.TotalBXHB_C52;
                txtTotalCPVCHB_C13.EditValue = CurrentQuotation.TotalCPVCHB_C13;

                this.Text += ": " + CurrentQuotation.Code;
            }
        }

        void loadDepartment()
        {
            DataTable dt = LibQLSX.Select("select * from Departments where [DepartmentId] in ('D018','D019')");
            cboDepartment.DataSource = dt;
            cboDepartment.DisplayMember = "DName";
            cboDepartment.ValueMember = "DepartmentId";
        }

        void loadCustomer()
        {
            DataTable dt = LibQLSX.Select("select CustomerCode,CustomerName from Customers");
            cboCustomer.Properties.DataSource = dt;
            cboCustomer.Properties.DisplayMember = "CustomerCode";
            cboCustomer.Properties.ValueMember = "CustomerCode";
        }

        void loadProject()
        {
            DataTable dt = LibQLSX.Select("select [ProjectName],[ProjectCode] from Project");
            cboProject.Properties.DataSource = dt;
            cboProject.Properties.DisplayMember = "ProjectCode";
            cboProject.Properties.ValueMember = "ProjectCode";
        }

        private bool ValidateForm()
        {
            txtCode.Text = txtCode.Text.Trim().ToUpper().Replace(" ", "");

            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Mã.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (CurrentQuotation.ID > 0)
                {
                    dt = TextUtils.Select("select Code from C_Quotation_KD where upper(Replace(Code,' ','')) = '"
                        + txtCode.Text.Trim().ToUpper() + "' and ID <> " + CurrentQuotation.ID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from C_Quotation_KD where upper(Replace(Code,' ','')) = '"
                        + txtCode.Text.Trim().ToUpper() + "'");
                }
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Mã này đã tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                }
            }

            //if (txtName.Text.Trim() == "")
            //{
            //    MessageBox.Show("Xin hãy điền Tên.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            //if (TextUtils.ToInt(leParentCat.EditValue) == 0)
            //{
            //    MessageBox.Show("Xin hãy chọn một nhóm!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            if (cboStatus.SelectedIndex < 1)
            {
                MessageBox.Show("Xin hãy chọn một trạng thái!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboCustomerType.SelectedIndex < 1)
            {
                MessageBox.Show("Xin hãy chọn một loại khách hàng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboStatusNC.SelectedIndex < 1)
            {
                MessageBox.Show("Xin hãy chọn một cách tính chi phí nhân công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboIsVAT.SelectedIndex < 1)
            {
                MessageBox.Show("Xin hãy chọn một tình trạng VAT!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboDepartment.SelectedIndex == -1)
            {
                MessageBox.Show("Xin hãy chọn một phòng phụ trách báo giá!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            //if (TextUtils.ToDecimal(txtDeliveryTime.EditValue) <= 0)
            //{
            //    MessageBox.Show("Xin hãy thêm ngày giao hàng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            return true;
        }

        void save()
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (!ValidateForm())
                    return;

                CurrentQuotation.Code = txtCode.Text.Trim();
                CurrentQuotation.CustomerCode = txtCustomerCode.Text.Trim();
                CurrentQuotation.CustomerName = txtCustomerName.Text.Trim();
                CurrentQuotation.DeliveryTime = TextUtils.ToDecimal(txtDeliveryTime.EditValue);
                CurrentQuotation.CustomerCodeF = txtFinishCustomerCode.Text.Trim();
                CurrentQuotation.CustomerNameF = txtFinishCustomerName.Text.Trim();
                CurrentQuotation.POnumber = txtPOnumber.Text.Trim();
                CurrentQuotation.ProjectCode = txtProjectCode.Text.Trim();
                CurrentQuotation.ProjectName = txtProjectName.Text.Trim();
                CurrentQuotation.Status = cboStatus.SelectedIndex;
                CurrentQuotation.DepartmentId = TextUtils.ToString(cboDepartment.SelectedValue);
                
                CurrentQuotation.TotalDP_KD = TextUtils.ToDecimal(txtTotalDP_KD.EditValue);
                CurrentQuotation.TotalDP_SX = TextUtils.ToDecimal(txtTotalDP_SX.EditValue);
                CurrentQuotation.TotalBXHB_C52 = TextUtils.ToDecimal(txtTotalBXHB_C52.EditValue);
                CurrentQuotation.TotalCPVCHB_C13 = TextUtils.ToDecimal(txtTotalCPVCHB_C13.EditValue);
                CurrentQuotation.TotalVCBX = TextUtils.ToDecimal(txtTotalVCBX.EditValue);

                CurrentQuotation.CustomerPercent = TextUtils.ToDecimal(txtCustomerPercent.EditValue);

                CurrentQuotation.CustomerCash = TextUtils.ToDecimal(txtCustomerCash.EditValue);
                CurrentQuotation.IsVAT = cboIsVAT.SelectedIndex;

                CurrentQuotation.TotalBX_KD = TextUtils.ToDecimal(txtTotalBX_KD.EditValue);
                CurrentQuotation.TotalVC_KD = TextUtils.ToDecimal(txtTotalVC_KD.EditValue);

                CurrentQuotation.StatusNC = cboStatusNC.SelectedIndex;
                CurrentQuotation.CustomerType = cboCustomerType.SelectedIndex; 

                CurrentQuotation.UpdatedDate = DateTime.Now;
                CurrentQuotation.UpdatedBy = Global.AppUserName;

                if (CurrentQuotation.ID <= 0)
                {
                    CurrentQuotation.CreatedDate = DateTime.Now;
                    CurrentQuotation.CreatedBy = Global.AppUserName;
                    CurrentQuotation.ID = (int)pt.Insert(CurrentQuotation);
                }
                else
                {
                    pt.Update(CurrentQuotation);
                }

                pt.CommitTransaction();
                _isSaved = true;
                MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu trữ không thành công!" + Environment.NewLine + ex.Message, TextUtils.Caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pt.CloseConnection();
            }

            if (_isSaved)
            {
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save();
            if (_isSaved) this.Close();
        }

        private void cboCustomer_EditValueChanged(object sender, EventArgs e)
        {
            txtCustomerCode.Text = TextUtils.ToString(grvCboCustomer.GetFocusedRowCellValue(colCustomerCode));
            txtCustomerName.Text = TextUtils.ToString(grvCboCustomer.GetFocusedRowCellValue(colCustomerName));
        }

        private void cboProject_EditValueChanged(object sender, EventArgs e)
        {
            txtProjectCode.Text = TextUtils.ToString(grvCboProject.GetFocusedRowCellValue(colProjectCode));
            txtProjectName.Text = TextUtils.ToString(grvCboProject.GetFocusedRowCellValue(colProjectName));
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            txtCustomerCash.EditValue = (TextUtils.ToDecimal(txtTotalHD.EditValue) - TextUtils.ToDecimal(txtTotalTPA.EditValue)) / (1 + 0.15m);// Tính tiền khách hàng gửi
        }
    }
}
