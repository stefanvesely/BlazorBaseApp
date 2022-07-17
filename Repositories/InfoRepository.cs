using BlazorBaseApp.Model;
using BlazorBaseApp.Repositories.Interfaces;
using AutoMapper;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorBaseApp.Data;

namespace BlazorBaseApp.Repositories
{
    public class InfoRepository : IInfoRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _data;    
        public InfoRepository (DataContext dataContext , IMapper mapper)
        {
            _data = dataContext;
            _mapper = mapper;   
        }
        public async Task<InfoModel> GetInfo(int Id)
        {
            if (Id == 0)
            {
                return null;
            }
            try
            {
                InfoModel _info = _mapper.Map<Info, InfoModel>(await _data.Infos.FirstOrDefaultAsync(x => x.PersonId == Id));
                return _info;
            }
            catch
            {
                return null;
            }
        }

        public async Task<InfoModel> UpdateInfo(InfoModel _Info)
        {
            if (_Info.PersonId != 0)
            {
                try
                {
                    Info infodetails = await _data.Infos.FindAsync(_Info.PersonId);
                    Info updatedinfo = _mapper.Map<InfoModel, Info>(_Info, infodetails);
                    var UpdatedInfo = _data.Infos.Update(updatedinfo);
                    await _data.SaveChangesAsync();
                    return _mapper.Map<Info, InfoModel>(UpdatedInfo.Entity);
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        
    }
}
