
using System;
namespace BMS.Model
{
	public class ModulesModel : BaseModel
	{
		private int iD;
		private string code;
		private string name;
		private int moduleGroupID;
		private string path;
		private string description;
		private int status;
        private string note;

        private string imagePath;
        private decimal price;
        private decimal orderTime;
        private int fileElectric;
        private int fileElectronic;
        private int fileMechanics;
        private string createdBy;
        private string specifications;
        private DateTime createdDate;
        private string updatedBy;
        private DateTime updatedDate;

        private int fileProgram;

        public int FileProgram
        {
            get { return fileProgram; }
            set { fileProgram = value; }
        }

        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }        

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        

        public decimal OrderTime
        {
            get { return orderTime; }
            set { orderTime = value; }
        }
        

        public int FileElectric
        {
            get { return fileElectric; }
            set { fileElectric = value; }
        }
        

        public int FileElectronic
        {
            get { return fileElectronic; }
            set { fileElectronic = value; }
        }
       

        public int FileMechanics
        {
            get { return fileMechanics; }
            set { fileMechanics = value; }
        }

        

        public string Specifications
        {
            get { return specifications; }
            set { specifications = value; }
        }
        public string Note
        {
            get { return note; }
            set { note = value; }
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

		public int ID
		{
			get { return iD; }
			set { iD = value; }
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
	
		public int ModuleGroupID
		{
			get { return moduleGroupID; }
			set { moduleGroupID = value; }
		}
	
		public string Path
		{
			get { return path; }
			set { path = value; }
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
	