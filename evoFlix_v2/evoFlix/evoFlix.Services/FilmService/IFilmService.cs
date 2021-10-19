using evoFlix.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.Services.FilmService
{
    public interface IFilmService: IDataService<FilmTableModel>
    {
        void ClearTable();
        void ReadRecord(FilmTableModel filmTableModel);
    }
}
