using Macrowing;
using Macrowing.Core;
using Macrowing.Service;
using Zhongyi.Core;
using Zhongyi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zhongyi.Service
{
    public class ZhongyiServiceManager: ServiceManager
    {
        public ZhongyiServiceManager(string nhibernateConfigPath)
            :base(nhibernateConfigPath)
        {
            
        }

        public ZhongyaoService ZhongyaoService { set; get; }

        public ZhongyiCoreManager ZhongyiCoreManager { set; get; }

        public ZhongyiDataManager ZhongyiDataManager { set; get; }

        protected override void LoadConfig()
        {
            base.LoadConfig();
         }

        protected override CoreManager CreateCoreManager()
        {
            this.ZhongyiCoreManager =  new ZhongyiCoreManager();
            return this.ZhongyiCoreManager;
        }

        protected override Macrowing.Data.DataManager CreateDataManager(CoreManager coreManager, string nhibernateConfigPath)
        {
            this.ZhongyiDataManager =  new ZhongyiDataManager(coreManager as ZhongyiCoreManager, nhibernateConfigPath);
            return this.ZhongyiDataManager;
        }

        public override void Load()
        {
            this.DataManager.Load();
        }

        protected override void CreateServices()
        {
            base.CreateServices();

            this.ZhongyaoService = new ZhongyaoService(this);
        }

        public override void PublishServices()
        {
            base.PublishServices();

            this.PublishService(this.ZhongyaoService);
        }
    }
}
