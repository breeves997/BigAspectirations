using BigAspectirations.Entities;

namespace BigAspectirations.Services
{
    public interface IQualitiesRepo
    {
        Quality Create(Quality newQuality);
        void Delete(int id);
        Quality Get(int id);
        Quality Update(Quality toUpdate);
    }
}