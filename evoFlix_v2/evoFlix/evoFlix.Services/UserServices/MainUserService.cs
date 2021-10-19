using evoFlix.DataAccess;
using evoFlix.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;
using evoFlix.Services.DataServices;

namespace evoFlix.Services
{
    public class MainUserService : IMainUserService
    {
        #region Properties
        private readonly UnitOfWork _unitOfWork;
        private readonly GenericDataService<MainUserTableModel> _genericData;
        #endregion

        public MainUserService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _genericData = new GenericDataService<MainUserTableModel>(unitOfWork);
        }

        public bool Create(MainUserTableModel entity)
        {
            return _genericData.Create(entity);

            //_unitOfWork.Set<MainUserTableModel>().Add(entity);
            //_unitOfWork.SaveChanges();

            //return true;
        }

        public bool Delete(int id)
        {
            return _genericData.Delete(id);

            //MainUserTableModel entity = _unitOfWork.Set<MainUserTableModel>().FirstOrDefault((e) => e.ID == id);
            //_unitOfWork.Set<MainUserTableModel>().Remove(entity);
            //_unitOfWork.SaveChanges();

            //return true;
        }

        public MainUserTableModel Get(int id)
        {
            return _genericData.Get(id);

            //MainUserTableModel entity = _unitOfWork.Set<MainUserTableModel>().FirstOrDefault((e) => e.ID == id);
            //return entity;
        }

        public List<MainUserTableModel> GetAll()
        {
            return _genericData.GetAll();

            //List<MainUserTableModel> entites = _unitOfWork.Set<MainUserTableModel>().ToList();
            //return entites;
        }
        public bool Update(int id, MainUserTableModel entity)
        {
            return _genericData.Update(id, entity);
        }

        public MainUserTableModel GetByEmail(string email)
        {
            MainUserTableModel entity = _unitOfWork.MainUsers.FirstOrDefault(m => m.Email.Equals(email));
            return entity;
        }

        public MainUserTableModel GetByUsername(string username)
        {
            MainUserTableModel entity = _unitOfWork.MainUsers.FirstOrDefault(m => m.Username.Equals(username));
            return entity;
        }
    }
}
