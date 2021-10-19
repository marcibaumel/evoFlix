using evoFlix.DataAccess;
using evoFlix.Models.Content;
using evoFlix.Services.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.WPF.ViewModels
{
    public class FilmListViewModel
    {

        private readonly GenericDataService<FilmTableModel> _genericData;
        public int MaxItemsInRow { get => 5; }
        public FilmListViewModel()
        {
            _genericData = new GenericDataService<FilmTableModel>(new UnitOfWork());
        }

        public List<FilmTableModel> GetAllFilm()
        {
            return _genericData.GetAll();
        }
    }
}
