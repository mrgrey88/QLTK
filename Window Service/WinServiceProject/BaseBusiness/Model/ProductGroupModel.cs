
using System;
namespace BMS.Model
{
	public class ProductGroupModel : BaseModel
	{
		private int iD;
		private string name;
        private int type;
        private string description;
        private string parentPath;

        public string ParentPath
        {
            get { return parentPath; }
            set { parentPath = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
		private int parentID;
		private string path;
		private string createdBy;
		private DateTime createdDate;
		private string updatedBy;
		private DateTime updatedDate;
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
	
        //public int ManufacturerID
        //{
        //    get { return manufacturerID; }
        //    set { manufacturerID = value; }
        //}
	
		public int ParentID
		{
			get { return parentID; }
			set { parentID = value; }
		}
	
		public string Path
		{
			get { return path; }
			set { path = value; }
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
	
	}
}
	