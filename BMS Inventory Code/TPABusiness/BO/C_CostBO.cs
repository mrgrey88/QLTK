
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class C_CostBO : BaseBO
	{
		private C_CostFacade facade = C_CostFacade.Instance;
		protected static C_CostBO instance = new C_CostBO();

		protected C_CostBO()
		{
			this.baseFacade = facade;
		}

		public static C_CostBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	