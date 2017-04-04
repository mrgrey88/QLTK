
using System;
namespace BMS.Model
{
	public class ModuleFilmHistoryModel : BaseModel
	{
		private int iD;
		private int moduleFilmID;
		private int lastTimeChange;
		private DateTime lastDateChange;
		private string updatedBy;
		private DateTime updatedDate;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int ModuleFilmID
		{
			get { return moduleFilmID; }
			set { moduleFilmID = value; }
		}
	
		public int LastTimeChange
		{
			get { return lastTimeChange; }
			set { lastTimeChange = value; }
		}
	
		public DateTime LastDateChange
		{
			get { return lastDateChange; }
			set { lastDateChange = value; }
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
	