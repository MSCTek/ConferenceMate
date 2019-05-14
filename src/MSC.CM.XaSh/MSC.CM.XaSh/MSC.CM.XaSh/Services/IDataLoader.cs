using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSC.CM.XaSh.Services
{
    public interface IDataLoader
    {
        Task<bool> HeartbeatCheck();

        Task<int> LoadAnnouncementsAsync();
    }
}