using BloodStorage.Models;

namespace BloodStorage.Data.Repositories
{
    public class DoctorRepository : ICrudRepository<Doctor, int>
    {

        private readonly DBContext _doctorContext;
        public DoctorRepository(DBContext doctorContext)
        {
            _doctorContext = doctorContext ?? throw new
            ArgumentNullException(nameof(doctorContext));
        }
        public void Add(Doctor element)
        {
            _doctorContext.Doctors.Add(element);
        }



        public void Delete(int id)
        {
            var item = Get(id);
            if (item is not null) _doctorContext.Doctors.Remove(Get(id));
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Doctor Get(int id)
        {
            return _doctorContext.Doctors.FirstOrDefault(u => u.DocId == id);

        }
        public IEnumerable<Doctor> GetAll()
        {
            return _doctorContext.Doctors.ToList();
        }

        public bool Save()
        {
            return _doctorContext.SaveChanges() > 0;
        }

        public void Update(Doctor element)
        {
            _doctorContext.Update(element);
        }


    }
}
