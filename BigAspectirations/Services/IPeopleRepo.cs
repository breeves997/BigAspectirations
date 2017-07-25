using BigAspectirations.Entities;

namespace BigAspectirations.Services
{
    public interface IPeopleRepo
    {
        Person Create(Person newPerson);
        void Delete(int id);
        Person Get(int id);
        Person Update(Person toUpdate);
    }
}