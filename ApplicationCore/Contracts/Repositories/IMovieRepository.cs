using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repositories
{
    public interface IMovieRepository
    {
        //CRUD methods
        // get top30 grossing movies from database
        //List<Movie> GetTop30GrossingMovies();

        Task<List<Movie>> GetTop30HighestRevenueMovies();
        Task<List<Movie>> GetTop30RatedMovies();
        Task<Movie> GetById(int id);
        Task<PagedResultSet<Movie>> GetMoviesByGenrePagination(int genreId, int pageSize = 30, int page = 1);
        


        // get Movie by Id
        //get movie bu Genre

    }
}
