using Dio.Series.Class;
using Dio.Series.Interfaces;

namespace Dio.Series.Repository
{
    public class SeriesRepository : IRepository<Serie>
    {
        private List<Serie> _seriesList = new();

        public async Task DeleteAsync(int id)
        {
            await Task.FromResult(_seriesList[id].Inactive());
        }

        public async Task<List<Serie>> GetAllAsync()
        {
            return await Task.FromResult(_seriesList);
        }

        public async Task<Serie> GetAsync(int id)
        {
            return await Task.FromResult(_seriesList[id]);
        }

        public async Task InsertAsync(Serie entity)
        {
            _seriesList.Add(entity);
        }

        public async Task<int> NextIdAsync()
        {
            return await Task.FromResult(_seriesList.Count);
        }

        public async Task UpdateAsync(int id, Serie entity)
        {
            await Task.FromResult(_seriesList[id] = entity);
        }
    }
}
