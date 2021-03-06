
using System;
namespace BMS.Model
{
	public class BaiThucHanhVersionModel : BaseModel
	{
		private int iD;
		private int baiThucHanhID;
		private int version;
		private string reason;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int BaiThucHanhID
		{
			get { return baiThucHanhID; }
			set { baiThucHanhID = value; }
		}
	
		public int Version
		{
			get { return version; }
			set { version = value; }
		}
	
		public string Reason
		{
			get { return reason; }
			set { reason = value; }
		}
	
		public string CreatedBy
		{
			get { return createdBy; }
			set { createdBy = value; }
		}
	
		public DateTime? CreatedDate
		{
			get { return createdDate; }
			set { createdDate = value; }
		}
	
		public string UpdatedBy
		{
			get { return updatedBy; }
			set { updatedBy = value; }
		}
	
		public DateTime? UpdatedDate
		{
			get { return updatedDate; }
			set { updatedDate = value; }
		}
	
	}
}
	