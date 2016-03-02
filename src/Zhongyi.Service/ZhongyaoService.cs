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
    public class ZhongyaoService : RemotingService, IZhongyaoService
    {
        ZhongyiCoreManager _coreManager;
        ZhongyiDataManager _dataManager;
        CoreMapper _mapper;
        ZhongyiServiceManager _serviceManager;

        public ZhongyaoService(ZhongyiServiceManager serviceManager)
        {
            this._coreManager = serviceManager.ZhongyiCoreManager;
            this._dataManager = serviceManager.ZhongyiDataManager;
            this._mapper = this._coreManager.CoreMapper;
            this._serviceManager = serviceManager;
        }

        public Zhongyao Create(ZhongyaoCreateInfo createInfo)
        {
            ZhongyaoInfo zhongyaoInfo = ObjectMapperHelper.Map<ZhongyaoInfo>(createInfo);
            zhongyaoInfo.Id = Guid.NewGuid().ToString();
            Zhongyao zhongyao = new Zhongyao(zhongyaoInfo);
            this._dataManager.ZhongyaoDataProvider.Insert(zhongyao);
            this._coreManager.ZhongyaoManager.Add(zhongyao);
            return zhongyao;
        } 

        public void Change(ZhongyaoChangeInfo changeInfo)
        {
            Zhongyao zhongyao = changeInfo.Zhongyao;
            ZhongyaoChangeInfo backupChangeInfo = new ZhongyaoChangeInfo(zhongyao);
            try
            {
                zhongyao.Change(changeInfo);
                this._dataManager.ZhongyaoDataProvider.Update(zhongyao);
            }
            catch
            {
                zhongyao.Change(backupChangeInfo);
                throw;
            }
        }

        public void Delete(params string[] zhongyaoIdArray)
        {
            List<Zhongyao> zhongyaoList = new List<Zhongyao>();
            foreach (string zhongyaoId in zhongyaoIdArray)
            {
                Zhongyao zhongyao = this._coreManager.ZhongyaoManager.Get(zhongyaoId);
                if (zhongyao != null)
                {
                    zhongyaoList.Add(zhongyao);
                }
            }

        }
    }
}
