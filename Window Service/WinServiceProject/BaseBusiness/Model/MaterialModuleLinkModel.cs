
using System;
namespace BMS.Model
{
	public class MaterialModuleLinkModel : BaseModel
	{
		private long iD;
		private string moduleCode;
		private int moduleID;
		private string code;
		private string name;
		private int materialID;
		private string sTT;
		private string unit;
		private int qty;
		private string vatLieu;
		private decimal weight;
		private string hang;
		private string maVatLieu;
		private string thongSo;
		private string designer;
		private string dateCreated;
		private int size;
		private bool isExist;
		private string author;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string ModuleCode
		{
			get { return moduleCode; }
			set { moduleCode = value; }
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
	
		public int MaterialID
		{
			get { return materialID; }
			set { materialID = value; }
		}
	
		public string STT
		{
			get { return sTT; }
			set { sTT = value; }
		}
	
		public string Unit
		{
			get { return unit; }
			set { unit = value; }
		}
	
		public int Qty
		{
			get { return qty; }
			set { qty = value; }
		}
	
		public string VatLieu
		{
			get { return vatLieu; }
			set { vatLieu = value; }
		}
	
		public decimal Weight
		{
			get { return weight; }
			set { weight = value; }
		}
	
		public string Hang
		{
			get { return hang; }
			set { hang = value; }
		}
	
		public string MaVatLieu
		{
			get { return maVatLieu; }
			set { maVatLieu = value; }
		}
	
		public string ThongSo
		{
			get { return thongSo; }
			set { thongSo = value; }
		}
	
		public string Designer
		{
			get { return designer; }
			set { designer = value; }
		}
	
		public string DateCreated
		{
			get { return dateCreated; }
			set { dateCreated = value; }
		}
	
		public int Size
		{
			get { return size; }
			set { size = value; }
		}
	
		public bool IsExist
		{
			get { return isExist; }
			set { isExist = value; }
		}
	
		public string Author
		{
			get { return author; }
			set { author = value; }
		}
	
	}
}
	