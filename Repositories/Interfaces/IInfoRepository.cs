using BlazorBaseApp.Model;

namespace BlazorBaseApp.Repositories.Interfaces
{
    public interface IInfoRepository
    {
             
        public Task<InfoModel> UpdateInfo (InfoModel Info);
        public Task<InfoModel> GetInfo (int Id);
    }
}
