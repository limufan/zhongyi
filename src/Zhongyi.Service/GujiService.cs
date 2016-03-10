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
    public class GujiService : RemotingService, IGujiService
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
            GujiInfo gujiInfo = ObjectMapperHelper.Map<GujiInfo>(createInfo);
            gujiInfo.Id = Guid.NewGuid().ToString();
            Guji guji = new Guji(gujiInfo);
            this._dataManager.GujiDataProvider.Insert(guji);
            this._coreManager.GujiManager.Add(guji);
            return guji;
        } 

        public void Change(GujiChangeInfo changeInfo)
        {
            Guji guji = changeInfo.Guji;
            GujiChangeInfo backupChangeInfo = new GujiChangeInfo(guji);
            try
            {
                guji.Change(changeInfo);
                this._dataManager.GujiDataProvider.Update(guji);
            }
            catch
            {
                guji.Change(backupChangeInfo);
                throw;
            }
        }

        public void Delete(params string[] gujiIdArray)
        {
            List<Guji> gujiList = new List<Guji>();
            foreach (string gujiId in gujiIdArray)
            {
                Guji guji = this._coreManager.GujiManager.Get(gujiId);
                if (guji != null)
                {
                    gujiList.Add(guji);
                }
            }

        }

        public List<GujiDetailsModel> Find(GujiFilterModel filterModel, out int totalCount)
        {
            GujiFilter filter = new GujiFilter();
            ObjectMapperHelper.Map(filter, filterModel, this._mapper);
            List<Guji> gujiList = this._coreManager.GujiManager.Find(filter, out totalCount);
            List<GujiDetailsModel> modelList = gujiList
                .Select(d =>
                {
                    GujiDetailsModel model = this._mapper.Map<GujiDetailsModel>(d);
                    return model;
                }).ToList();
            return modelList;
        }
    }
}
