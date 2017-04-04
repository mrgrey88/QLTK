namespace WinServiceProject
{
    using System;
    using System.IO;
    using System.Collections;
    using System.Linq;
    using BMS.Business;
    using BMS.Model;
    using BMS.Utils;
    using System.Data;
    using BMS;

    class WinService : System.ServiceProcess.ServiceBase
    {
        // The main entry point for the process
        static void Main()
        {
            System.ServiceProcess.ServiceBase[] ServicesToRun;
            ServicesToRun = new System.ServiceProcess.ServiceBase[] { new WinService() };
            System.ServiceProcess.ServiceBase.Run(ServicesToRun);

            #if(!DEBUG)
                       ServiceBase[] ServicesToRun;
                       ServicesToRun = new ServiceBase[] 
	                { 
	                    new WinService() 
	                };
                       ServiceBase.Run(ServicesToRun);
            #else
                    WinService myServ = new WinService();
                    myServ.OnStart(null);
                        // here Process is my Service function
                        // that will run when my service onstart is call
                        // you need to call your own method or function name here instead of Process();
            #endif
        }
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            
        }

        void DongBoQLSX()
        {
            try
            {
                //Đồng bộ Module: Trạng thái,thông số kỹ thuật
                TextUtils.ExcuteProcedure("spDongBoModelQLSX", null, null);
            }
            catch //(Exception)
            {               
            }

            //try
            //{
            //    //Đồng bộ Vật tư: Giá, thời gian giao hàng.
            //    TextUtils.ExcuteProcedure("spDongBoMaterialQLSX", null, null);
            //}
            //catch (Exception)
            //{              
            //}            
        }

        /// <summary>
        /// Set things in motion so your service can do its work.
        /// </summary>
        ///  
        protected override void OnStart(string[] args)
        {
            DongBoQLSX();
            OnStart(null);
        }
        /// <summary>
        /// Stop this service.
        /// </summary>
        protected override void OnStop()
        {
            
        }
    }
}