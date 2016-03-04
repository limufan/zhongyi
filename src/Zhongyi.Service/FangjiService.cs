using Macrowing.Core;
using Zhongyi.Core;
using Zhongyi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Macrowing;
using Macrowing.Service;
using Zhongyi.Api;

namespace Zhongyi.Service
{
    public class FangjiService : RemotingService
    {
        ZhongyiCoreManager _coreManager;
        ZhongyiDataManager _dataManager;
        CoreMapper _mapper;
        ZhongyiServiceManager _serviceManager;

        public FangjiService(ZhongyiServiceManager serviceManager)
        {
            this._coreManager = serviceManager.ZhongyiCoreManager;
            this._dataManager = serviceManager.ZhongyiDataManager;
            this._mapper = this._coreManager.CoreMapper;
            this._serviceManager = serviceManager;
        }

        public Fangji Create(FangjiCreateInfo createInfo)
        {
            FangjiInfo zhongyaoInfo = ObjectMapperHelper.Map<FangjiInfo>(createInfo);
            zhongyaoInfo.Id = Guid.NewGuid().ToString();
            Fangji zhongyao = new Fangji(zhongyaoInfo);
            this._dataManager.FangjiDataProvider.Insert(zhongyao);
            this._coreManager.FangjiManager.Add(zhongyao);
            return zhongyao;
        } 

        public void Change(FangjiChangeInfo changeInfo)
        {
            Fangji zhongyao = changeInfo.Fangji;
            FangjiChangeInfo backupChangeInfo = new FangjiChangeInfo(zhongyao);
            try
            {
                zhongyao.Change(changeInfo);
                this._dataManager.FangjiDataProvider.Update(zhongyao);
            }
            catch
            {
                zhongyao.Change(backupChangeInfo);
                throw;
            }
        }

        public void Delete(params string[] zhongyaoIdArray)
        {
            List<Fangji> zhongyaoList = new List<Fangji>();
            foreach (string zhongyaoId in zhongyaoIdArray)
            {
                Fangji zhongyao = this._coreManager.FangjiManager.Get(zhongyaoId);
                if (zhongyao != null)
                {
                    zhongyaoList.Add(zhongyao);
                }
            }

        }
    }
}
