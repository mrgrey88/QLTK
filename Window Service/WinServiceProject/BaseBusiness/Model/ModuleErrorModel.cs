
using System;
namespace BMS.Model
{
	public class ModuleErrorModel : BaseModel
	{
		private int iD;
		private int moduleID;
		private string code;
		private string name;
		private int userID;
		private int pLLTQ;
		private int pLLNN;
		private int pLLCP;
		private string huongKhacPhuc;
		private string description;
		private int status;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int ModuleID
		{
			get { return moduleID; }
			set { moduleID = value; }
		}
	
		public string Code
		{
			get { return code; }
			set { code = value; }
		}
	
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	
		public int UserID
		{
			get { return userID; }
			set { userID = value; }
		}
	
		public int PLLTQ
		{
			get { return pLLTQ; }
			set { pLLTQ = value; }
		}
	
		public int PLLNN
		{
			get { return pLLNN; }
			set { pLLNN = value; }
		}
	
		public int PLLCP
		{
			get { return pLLCP; }
			set { pLLCP = value; }
		}
	
		public string HuongKhacPhuc
		{
			get { return huongKhacPhuc; }
			set { huongKhacPhuc = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
		public int Status
		{
			get { return status; }
			set { status = value; }
		}
	
	}
}
	