using BlazorBaseApp.Model;
using BlazorBaseApp.Repositories.Interfaces;
using BlazorBaseApp.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorBaseApp.Repositories
{

    public class PersonRepository : IPersonRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public PersonRepository(DataContext db, IMapper mapper)
        {
            _mapper = mapper;
            _dataContext = db;
        }
        public async Task<PersonModel> CheckForDuplicates(string sUserName)
        {
            try
            {
                    PersonModel person = _mapper.Map<Person, PersonModel>(await _dataContext.Persons.FirstOrDefaultAsync(x => x.UserName.ToLower() == sUserName.ToLower()));
                    return person;
             
                
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<PersonModel> CreatePerson(PersonModel _Person, InfoModel Info1)
        {
            Person person = _mapper.Map<PersonModel, Person>(_Person);
            Info info = _mapper.Map<InfoModel, Info>(Info1);
            info.Person = person;
            info.PersonId = person.Id;
            var AddedPerson = await _dataContext.Persons.AddAsync(person);
            var AddInfo = await _dataContext.Infos.AddAsync(info);
            await _dataContext.SaveChangesAsync();
            return _mapper.Map<Person, PersonModel>(AddedPerson.Entity);
        }

        public async Task<bool> DeletePerson(int PersonID)
        {
            var PersonDetails = await _dataContext.Persons.FindAsync(PersonID);
            if (PersonDetails != null)
            {
                var PersonInfo = await _dataContext.Infos.FindAsync(PersonID);
                _dataContext.Remove(PersonDetails);
                _dataContext.Remove(PersonInfo);
                return true;
            }
            return false;
        }

        public async Task<PersonModel> GetPerson(string UserName, string Password)
        {
            try
            {
                PersonModel Person1 = _mapper.Map<Person, PersonModel>(await _dataContext.Persons.FirstOrDefaultAsync(x=>x.UserName == UserName && x.Password == Password));
                return Person1;
            }
            catch
            {
                return null;
            }
        }

        public async Task<PersonModel> UpdatePerson(int PersonID, PersonModel _Person, InfoModel _Info)
        {
            try
            {
                if (PersonID == _Person.Id && PersonID == _Info.PersonId)
                {
                    Person persondetails = await _dataContext.Persons.FindAsync(PersonID);
                    Person person = _mapper.Map<PersonModel, Person>(_Person, persondetails);
                    var UpdatePerson = _dataContext.Persons.Update(person);
                    Info infodetails = await _dataContext.Infos.FindAsync(PersonID);
                    Info info = await _dataContext.Infos.FindAsync(PersonID);
                    var UpdateInfo = _dataContext.Infos.Update(info);
                    await _dataContext.SaveChangesAsync();
                    return _mapper.Map<Person, PersonModel>(UpdatePerson.Entity);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
