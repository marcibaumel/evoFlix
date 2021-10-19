using evoFlix.DataAccess;
using evoFlix.Models;
using evoFlix.Models.Users;
using evoFlix.Models.Content;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.Services.DataServices
{
    public class GenericDataService<T> : IDataService<T> where T : BaseTableModel
    {
        private readonly UnitOfWork unitOfWork;

        public GenericDataService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public bool Create(T entity)
        {
            unitOfWork.Set<T>().Add(entity);
            unitOfWork.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            T entity = unitOfWork.Set<T>().FirstOrDefault((e) => e.ID == id);
            unitOfWork.Set<T>().Remove(entity);
            unitOfWork.SaveChanges();

            return true;
        }

        public T Get(int id)
        {
            T entity = unitOfWork.Set<T>().FirstOrDefault((e) => e.ID == id);
            return entity;
        }

        public List<T> GetAll()
        {
            List<T> entites = unitOfWork.Set<T>().ToList();
            return entites;
        }

        public bool Update(int id, T entity)
        {
            T currentEntity = unitOfWork.Set<T>().FirstOrDefault((e) => e.ID == id);
            entity.ID = currentEntity.ID;
            unitOfWork.Entry(currentEntity).CurrentValues.SetValues(entity);
            unitOfWork.SaveChanges();

            return true;
        }
    }
}
