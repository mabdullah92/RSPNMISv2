using RSPNMISv2.ViewModels;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSPNMISv2.Helpers
{
   
    public class OutreachCache
    {
        public static bool Add(string UserId, OutreachImportViewModel _Data)
        {
            using (var redisClient = new RedisClient(Utility.REDIS_CONNECTIONS_SERVER, Utility.REDIS_CONNECTIONS_PORT, (!String.IsNullOrEmpty(Utility.REDIS_CONNECTIONS_PASSWORD) ? Utility.REDIS_CONNECTIONS_PASSWORD : null)))
            {
                IRedisTypedClient<OutreachImportViewModel> redis = redisClient.As<OutreachImportViewModel>();
                var dataKey = string.Format("outreach:user:{0}:indicator_id:{1}:subIndicatorName:{2}:dist_id:{3}", UserId, _Data.IndicatorID, _Data.SubIndicatorName, _Data.Dist_Id);
                redis.SetEntry(dataKey, _Data);
            }
            return true;
        }
        public static List<OutreachImportViewModel> GetAll()
        {
            List<OutreachImportViewModel> dataItems = null;
            using (var redisClient = new RedisClient(Utility.REDIS_CONNECTIONS_SERVER, Utility.REDIS_CONNECTIONS_PORT, (!String.IsNullOrEmpty(Utility.REDIS_CONNECTIONS_PASSWORD) ? Utility.REDIS_CONNECTIONS_PASSWORD : null)))
            {
                var dataKeys = redisClient.ScanAllKeys("outreach:user:*").ToList();
                dataItems = redisClient.GetValues<OutreachImportViewModel>(dataKeys);
            }
            return dataItems;
        }
        public static bool RemoveUserData(string UserId)
        {
            using (var redisClient = new RedisClient(Utility.REDIS_CONNECTIONS_SERVER, Utility.REDIS_CONNECTIONS_PORT, (!String.IsNullOrEmpty(Utility.REDIS_CONNECTIONS_PASSWORD) ? Utility.REDIS_CONNECTIONS_PASSWORD : null)))
            {
                var dataKeys = string.Format("outreach:user:{0}:*", UserId);
                redisClient.RemoveByPattern(dataKeys);
            }
            return true;
        }

    }
}