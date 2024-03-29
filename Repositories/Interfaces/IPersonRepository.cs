﻿using BlazorBaseApp.Model;

namespace BlazorBaseApp.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        public Task<PersonModel> CreatePerson(PersonModel Person, InfoModel Info);
        public Task<PersonModel> UpdatePerson(int PersonID, PersonModel Person, InfoModel Info);
        public Task<PersonModel> GetPerson (string UserName, string Password);    
        public Task<bool> DeletePerson(int PersonID);
        public Task<PersonModel> CheckForDuplicates (string sUserName);
    }
}
