using BloodStorage.Models;

namespace BloodStorage.Data.Repositories
{
    public class PatientRepository : ICrudRepository<Patient, int>
    {
        private readonly DBContext _patientContext;
        //private readonly DBContext _doctorContext;
        public PatientRepository(DBContext patientContext)
        {
            _patientContext = patientContext ?? throw new
            ArgumentNullException(nameof(patientContext));
        }
        public void Add(Patient element)
        {
            _patientContext.Patients.Add(element);  
        }

        

        public void Delete(int id)
        {
            var item = Get(id);
            if (item is not null) _patientContext.Patients.Remove(Get(id));
        }

        public bool Exists(int id)
        {
            return _patientContext.Patients.Any(u => u.NHSId == id);
        }

        public Patient Get(int id)
        {
            return _patientContext.Patients.FirstOrDefault(u => u.NHSId == id);

        }
        public IEnumerable<Patient> GetAll()
        {
            return _patientContext.Patients.ToList();
        }

        public bool Save()
        {
            return _patientContext.SaveChanges() > 0;
        }

        public void Update(Patient element)
        {
            _patientContext.Update(element);
        }

        public IEnumerable<string> GetJoinedData()
        {
            List<Patient> patients = _patientContext.Patients.ToList();  
            List<Doctor> doctors = _patientContext.Doctors.ToList(); 

            var result = from patient in patients
                         join doctor in doctors
                         on patient.DocId equals doctor.DocId
                         select $"{patient.Name} {doctor.Name}";
            return result;

        }

        

      

    }
}
