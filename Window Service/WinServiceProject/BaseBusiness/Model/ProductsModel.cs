
using System;
namespace BMS.Model
{
	public class ProductsModel : BaseModel
	{
		private int iD;
		private string name;
		private string code;
		private int projectInfoID;
		private string createdBy;
		private DateTime createdDate;
		private string updatedBy;
		private DateTime updatedDate;
		private int status;
		private string description;

        private string unit;

        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }
        private decimal quantity;

        public decimal Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private string pjName;

        public string PjName
        {
            get { return pjName; }
            set { pjName = value; }
        }
        private string pjCode;

        public string PjCode
        {
            get { return pjCode; }
            set { pjCode = value; }
        }

		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	
		public string Code
		{
			get { return code; }
			set { code = value; }
		}
	
		public int ProjectInfoID
		{
			get { return projectInfoID; }
			set { projectInfoID = value; }
		}
	
		public string CreatedBy
		{
			get { return createdBy; }
			set { createdBy = value; }
		}
	
		public DateTime CreatedDate
		{
			get { return createdDate; }
			set { createdDate = value; }
		}
	
		public string UpdatedBy
		{
			get { return updatedBy; }
			set { updatedBy = value; }
		}
	
		public DateTime UpdatedDate
		{
			get { return updatedDate; }
			set { updatedDate = value; }
		}
	
		public int Status
		{
			get { return status; }
			set { status = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
	}
}
	