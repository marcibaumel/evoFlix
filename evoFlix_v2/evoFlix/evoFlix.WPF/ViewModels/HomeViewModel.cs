using evoFlix.DataAccess;
using evoFlix.Models.Content;
using evoFlix.Services.DataServices;
using System.Collections.Generic;



namespace evoFlix.WPF.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly GenericDataService<FilmTableModel> _genericData;
        public int MaxItemsInRow { get => 5; }
        public HomeViewModel()
        {
            _genericData = new GenericDataService<FilmTableModel>(new UnitOfWork());
        }

        public List<FilmTableModel> GetAllFilm()
        {
            return _genericData.GetAll();
        }
    }
}
