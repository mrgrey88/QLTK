﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Utils;
using BMS.Model;
using BMS.Business;

namespace BMS
{
    public partial class frmShowStaff : _Forms
    {
        #region Variables
        public UsersModel Model = new UsersModel();
        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;
        #endregion

        #region Contructors and Load
        public frmShowStaff()
        {
            InitializeComponent();
        }

        private void frmShowStaff_Load(object sender, EventArgs e)
        {
            loadStaffGroupLink();
            loadStaffGroup();
            loadCombo();

            if (Model.ID != 0)
            {
                txtBankAccount.Text = Model.BankAccount;
                txtBHXH.Text = Model.BHXH;
                txtBHYT.Text = Model.BHYT;
                dtpBirthOfDate.EditValue = Model.BirthOfDate;
                txtCMTND.Text = Model.CMTND;
                txtCode.Text = Model.Code;
                cboDepartment.SelectedValue = Model.DepartmentID;
                txtEmail.Text = Model.Email;
                txtEmailCom.Text = Model.EmailCom;
                txtFullName.Text = Model.FullName;
                txtTelephone.Text = Model.HandPhone;
                txtHomeAddress.Text = Model.HomeAddress;
                txtJobDescription.Text = Model.JobDescription;
                txtLoginName.Text = Model.LoginName;
                txtMST.Text = Model.MST;
                txtPasswordHash.Text = MD5.DecryptPassword(Model.PasswordHash);
                txtPosition.Text = Model.Position;
                txtQualifications.Text = Model.Qualifications;
                cboSex.SelectedIndex = Model.Sex;
                dtpStartWorking.EditValue = Model.StartWorking;
                pictureBox1.ImageLocation = Model.ImagePath;
                cboStatus.SelectedIndex = Model.Status;
                lookUpEdit1.EditValue = Model.UserGroupID;
                if (txtLoginName.Text != "")
                {
                    chkHasUser.Checked = true;
                }
            }
            else
            {
                txtPasswordHash.Text = "123456";
            }
        }
        #endregion

        #region Functions

        void loadCombo()
        {
            DataTable tbl = TextUtils.Select(@"SELECT ID,Name FROM Department WITH(NOLOCK) ORDER BY Name");
            if (tbl == null)
            {
                return;
            }
            TextUtils.PopulateCombo(cboDepartment, tbl.Copy(), "Name", "ID", "-- Phòng ban --");
            DataTable tblPerson = TextUtils.Select("Select ID, Code, Name from UserGroup a with(nolock)");
            //lkTruongNhom.Properties.DataSource = tblPerson;
            //lkTruongNhom.Properties.DisplayMember = "FullName";
            //lkTruongNhom.Properties.ValueMember = "ID";
            TextUtils.PopulateCombo(lookUpEdit1, tblPerson.Copy(), "Name", "ID", "-- Chọn nhóm --");
        }

        private bool ValidateForm()
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Mã nhân viên.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (Model.ID > 0)
                {
                    dt = TextUtils.Select("select Code from Users where Code = '" + txtCode.Text.Trim() + "' and ID <> " + Model.ID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from Users where Code = '" + txtCode.Text.Trim() + "'");
                }
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Mã nhân viên này đã được sử dụng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                }
            }
            if (txtFullName.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Tên nhân viên.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (chkHasUser.Checked)
            {
                if (txtPasswordHash.Text.Trim() == "")
                {
                    MessageBox.Show("Xin hãy điền Mật khẩu.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
                if (txtLoginName.Text.Trim() == "")
                {
                    MessageBox.Show("Xin hãy điền Tên đăng nhập.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
                else
                {
                    DataTable dt;
                    if (Model.ID > 0)
                    {
                        dt = TextUtils.Select("select LoginName from Users where LoginName = '" + txtLoginName.Text.Trim() + "' and ID <> " + Model.ID);
                    }
                    else
                    {
                        dt = TextUtils.Select("select LoginName from Users where LoginName = '" + txtLoginName.Text.Trim() + "'");
                    }
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Tên đăng nhập này đã được sử dụng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return false;
                        }
                    }
                }
            }
           
            if (TextUtils.ToInt(cboDepartment.SelectedValue) <=0)
            {
                MessageBox.Show("Làm ơn nhập phòng ban!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (dtpStartWorking.EditValue==null)
            {
                 MessageBox.Show("Làm ơn nhập Ngày vào công ty!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (dtpBirthOfDate.EditValue == null)
            {
                MessageBox.Show("Làm ơn nhập Ngày sinh nhân viên!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (txtQualifications.Text.Trim() == "")
            {
                MessageBox.Show("Làm ơn nhập Trình độ học vấn!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (txtCMTND.Text.Trim() == "")
            {
                MessageBox.Show("Làm ơn nhập Số CMTND!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        void loadDegree()
        {
            DataTable dt = TextUtils.Select("Select * from Degrees WITH(NOLOCK) WHERE UserID = " + Model.ID);
            grdData.DataSource = dt;
            grvData.BestFitColumns();
        }

        void loadStaffGroup()
        {
            try
            {
                DataTable tbl = TextUtils.Select("Select * from vUserGroup a with(nolock)");
                gridControl1.DataSource = tbl;
                gridView1.BestFitColumns();
            }
            catch
            {
            }
        }

        void loadStaffGroupLink()
        {
            try
            {
                DataTable tbl = TextUtils.Select("Select * from vUserGroupLink with(nolock) where UserID = " + Model.ID);
                gridControl2.DataSource = tbl;
                gridView2.BestFitColumns();
            }
            catch
            {
            }
        }
        #endregion

        #region Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (!ValidateForm())
                    return;              

                Model.BankAccount = txtBankAccount.Text.Trim();
                Model.BHXH = txtBHXH.Text.Trim();
                Model.BHYT = txtBHYT.Text.Trim();
                try
                {
                    Model.BirthOfDate = TextUtils.ToDate(dtpBirthOfDate.EditValue.ToString());
                }
                catch
                {
                    Model.BirthOfDate = DateTime.Now;
                }

                Model.CMTND = txtCMTND.Text.Trim();
                Model.Code = txtCode.Text.Trim();
                Model.DepartmentID = TextUtils.ToInt(cboDepartment.SelectedValue);
                Model.Email = txtEmail.Text.Trim();
                Model.EmailCom = txtEmailCom.Text.Trim();
                Model.FullName = txtFullName.Text;
                Model.HandPhone = txtTelephone.Text;
                Model.HomeAddress = txtHomeAddress.Text;
                Model.JobDescription = txtJobDescription.Text.Trim();
                Model.MST = txtMST.Text.Trim();
                Model.Position = txtPosition.Text;
                Model.Qualifications = txtQualifications.Text.Trim();
                Model.Sex = cboSex.SelectedIndex;
                Model.UserGroupID =TextUtils.ToInt(lookUpEdit1.EditValue);
                try
                {
                    Model.StartWorking = TextUtils.ToDate(dtpStartWorking.EditValue.ToString());
                }
                catch
                {
                    Model.StartWorking = DateTime.Now;
                }

                Model.ImagePath = pictureBox1.ImageLocation;
                Model.Status = cboStatus.SelectedIndex;

                if (chkHasUser.Checked)
                {
                    Model.LoginName = txtLoginName.Text.Trim();
                    Model.PasswordHash = MD5.EncryptPassword(txtPasswordHash.Text.Trim());
                }
                else
                {
                    Model.LoginName = "";
                    Model.PasswordHash = "";
                }

                Model.UpdatedDate = Model.CreatedDate;
                Model.UpdatedBy = Global.AppUserName;

                if (Model.ID == 0)
                {
                    Model.CreatedDate = TextUtils.GetSystemDate();
                    Model.CreatedBy = Global.AppUserName;
                  
                    Model.ID = (int)pt.Insert(Model);
                }
                else
                {
                    pt.Update(Model);
                }
                pt.CommitTransaction();
                //this.DialogResult = DialogResult.OK;
                MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {                
                pt.CloseConnection();
            }   
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkHasUser_CheckedChanged(object sender, EventArgs e)
        {
            txtPasswordHash.Enabled = txtLoginName.Enabled = chkHasUser.Checked;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.ImageLocation = ofd.FileName;
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (TabControlUser.SelectedTabPage == tabPageBangCap)
            {
                btnAddDegree.Enabled = btnEditDegree.Enabled = btnDelDegree.Enabled = Model.ID != 0;
                if (Model.ID != 0)
                {
                    loadDegree();
                }
            }
        }      

        private void btnAddDegree_Click(object sender, EventArgs e)
        {
            //frmDegree frm = new frmDegree();
            //frm.UserID = Model.ID;
            //if (frm.ShowDialog()==DialogResult.OK)
            //{
            //    loadDegree();
            //}
        }

        private void btnEditDegree_Click(object sender, EventArgs e)
        {
            //int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            //if (id == 0) return;
            //frmDegree frm = new frmDegree();
            //frm.UserID = Model.ID;
            //frm.Model = (DegreesModel)DegreesBO.Instance.FindByPK(id);
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    loadDegree();
            //}
        }

        private void btnDelDegree_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Bạn có thực sự muốn xóa bằng cấp này?", TextUtils.Caption, MessageBoxButtons.YesNo);
            //if (result==DialogResult.Yes)
            //{
            //    int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            //    if (id == 0) return;
            //    DegreesBO.Instance.Delete(id);
            //    loadDegree();
            //}            
        }
        #endregion

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            if (Model.ID == 0)
            {
                MessageBox.Show("Nhân viên này chưa được tạo nên không thể gán nhóm quyền", TextUtils.Caption, 
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            int userID = Model.ID;
            int count = 0;
            foreach (int i in gridView1.GetSelectedRows())
            {
                int userGroupID = TextUtils.ToInt(gridView1.GetRowCellValue(i, colIDGroup));
                DataTable dtLink = TextUtils.Select("select * from UserGroupLink with(nolock) where UserID = " + userID
                    + " and UserGroupID = " + userGroupID);
                if (dtLink.Rows.Count > 0) continue;
                UserGroupLinkModel gLink = new UserGroupLinkModel();
                gLink.UserID = userID;
                gLink.UserGroupID = userGroupID;
                UserGroupLinkBO.Instance.Insert(gLink);
                count++;
            }
            if (count > 0)
            {
                loadStaffGroupLink();
            }
        }

        private void xóaNhómToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(gridView2.GetFocusedRowCellValue(colIDLink));
            if (id > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn hủy nhóm quyền?", TextUtils.Caption, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UserGroupLinkBO.Instance.Delete(id);
                    loadStaffGroupLink();
                }
            }
        }
    }
}
