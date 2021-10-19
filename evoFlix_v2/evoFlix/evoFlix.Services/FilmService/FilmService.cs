using evoFlix.DataAccess;
using evoFlix.Models.Content;
using evoFlix.Services.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.Services.FilmService
{
    public class FilmService : IFilmService
    {

        #region Properties
        private readonly UnitOfWork _unitOfWork;
        private readonly GenericDataService<FilmTableModel> _genericData;
        #endregion
        
        public FilmService()
        {
            _unitOfWork = new UnitOfWork();
            _genericData = new GenericDataService<FilmTableModel>();
        }

        public void ClearTable()
        {
            foreach(var film in _unitOfWork.Films)
            {
                _genericData.Delete(film.ID);
            }
        }

        public bool Create(FilmTableModel entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public FilmTableModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<FilmTableModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void ReadRecord(FilmTableModel filmTableModel)
        {
            try {
                _unitOfWork.Films.Add(filmTableModel);
                _unitOfWork.SaveChanges();
            }
            catch (Exception e)
            {

            }
            
        }
    }
}
