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
    public class GujiService : RemotingService
    {
        ZhongyiCoreManager _coreManager;
        ZhongyiDataManager _dataManager;
        CoreMapper _mapper;
        ZhongyiServiceManager _serviceManager;

        public GujiService(ZhongyiServiceManager serviceManager)
        {
            this._coreManager = serviceManager.ZhongyiCoreManager;
            this._dataManager = serviceManager.ZhongyiDataManager;
            this._mapper = this._coreManager.CoreMapper;
            this._serviceManager = serviceManager;
        }

        public Guji Create(GujiCreateInfo createInfo)
        {
            GujiInfo zhongyaoInfo = ObjectMapperHelper.Map<GujiInfo>(createInfo);
            zhongyaoInfo.Id = Guid.NewGuid().ToString();
            Guji zhongyao = new Guji(zhongyaoInfo);
            this._dataManager.GujiDataProvider.Insert(zhongyao);
            this._coreManager.GujiManager.Add(zhongyao);
            return zhongyao;
        } 

        public void Change(GujiChangeInfo changeInfo)
        {
            Guji zhongyao = changeInfo.Guji;
            GujiChangeInfo backupChangeInfo = new GujiChangeInfo(zhongyao);
            try
            {
                zhongyao.Change(changeInfo);
                this._dataManager.GujiDataProvider.Update(zhongyao);
            }
            catch
            {
                zhongyao.Change(backupChangeInfo);
                throw;
            }
        }

        public void Delete(params string[] zhongyaoIdArray)
        {
            List<Guji> zhongyaoList = new List<Guji>();
            foreach (string zhongyaoId in zhongyaoIdArray)
            {
                Guji zhongyao = this._coreManager.GujiManager.Get(zhongyaoId);
                if (zhongyao != null)
                {
                    zhongyaoList.Add(zhongyao);
                }
            }

        }
    }
}
