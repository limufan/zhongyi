﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Macrowing.Data;
using System.IO;
using Zhongyi.Core;

namespace Zhongyi.Data
{
    public class ZhongyiDataManager: DataManager
    {
        public ZhongyiDataManager(ZhongyiCoreManager coreManager, string nhibernateConfigPath)
            :base(coreManager, nhibernateConfigPath)
        {
            this.ZhongyiCoreManager = coreManager;
            this.ZhongyaoDataProvider = new DataProvider<Zhongyao, ZhongyaoDataModel>(coreManager);
            this.FangjiDataProvider = new DataProvider<Fangji, FangjiDataModel>(coreManager);
            this.GujiDataProvider = new DataProvider<Guji, GujiDataModel>(coreManager);
        }

        public ZhongyiCoreManager ZhongyiCoreManager { set; get; }

        public DataProvider<Zhongyao, ZhongyaoDataModel> ZhongyaoDataProvider { set; get; }

        public DataProvider<Fangji, FangjiDataModel> FangjiDataProvider { set; get; }

        public DataProvider<Guji, GujiDataModel> GujiDataProvider { set; get; }

        public override void Load()
        {
            base.Load();
            this.ZhongyaoDataProvider.Load();
            this.FangjiDataProvider.Load();
            this.GujiDataProvider.Load();
        }
    }
}
