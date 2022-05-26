using BloodStorage.Data.Repositories;
using BloodStorage.Models;

namespace BloodStorage.Services
{
    public class DoctorService : ICrudService<Doctor, int>
    {
        private readonly ICrudRepository<Doctor, int> _doctorRepository;
        public DoctorService(ICrudRepository<Doctor, int> doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public void Add(Doctor element)
        {
            _doctorRepository.Add(element);
            _doctorRepository.Save();
        }
        public void Delete(int id)
        {
            _doctorRepository.Delete(id);
            _doctorRepository.Save();
        }
        public Doctor Get(int id)
        {
            return _doctorRepository.Get(id);
        }
        public IEnumerable<Doctor> GetAll()
        {
            return _doctorRepository.GetAll();
        }
        public void Update(Doctor old, Doctor newT)
        {
            //old.DocId = newT.DocId; 
            old.Name = newT.Name;
            // old.Age = newT.Age; 
            //old.Address = newT.Address;
            old.GPAddress = newT.GPAddress;
            _doctorRepository.Update(old);
            _doctorRepository.Save();
        }
    }
}

