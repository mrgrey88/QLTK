
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class C_GroundBO : BaseBO
	{
		private C_GroundFacade facade = C_GroundFacade.Instance;
		protected static C_GroundBO instance = new C_GroundBO();

		protected C_GroundBO()
		{
			this.baseFacade = facade;
		}

		public static C_GroundBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	