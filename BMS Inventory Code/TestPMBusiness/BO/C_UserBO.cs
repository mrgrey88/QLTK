
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class C_UserBO : BaseBO
	{
		private C_UserFacade facade = C_UserFacade.Instance;
		protected static C_UserBO instance = new C_UserBO();

		protected C_UserBO()
		{
			this.baseFacade = facade;
		}

		public static C_UserBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	