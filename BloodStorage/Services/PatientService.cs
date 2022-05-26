using BloodStorage.Data.Repositories;
using BloodStorage.Models;

namespace BloodStorage.Services
{
    public class PatientService : ICrudService<Patient, int>
    {
        private readonly ICrudRepository<Patient, int> _patientRepository;
        public PatientService(ICrudRepository<Patient, int> todoRepository)
        {
            _patientRepository = todoRepository;
        }
        public void Add(Patient element)
        {
            _patientRepository.Add(element);
            _patientRepository.Save();
        }
        public void Delete(int id)
        {
            _patientRepository.Delete(id);
            _patientRepository.Save();
        }
        public Patient Get(int id)
        {
            return  _patientRepository.Get(id);
        }
        public IEnumerable<Patient> GetAll()
        {
            return _patientRepository.GetAll();
        }
        public void Update(Patient old, Patient newT)
        {
            //old.DocId = newT.DocId; 
            old.Name = newT.Name;   
           // old.Age = newT.Age; 
            //old.Address = newT.Address;
            old.PostCode = newT.PostCode;
            _patientRepository.Update(old);
            _patientRepository.Save();
        }

        public IEnumerable<string> GetJoinedData()
        {
            return ((PatientRepository)_patientRepository).GetJoinedData();
        }
    }
}
