namespace DatabaseHandler.Repositories.CommonGenericRepository
{
    public interface ICommonGenericRepository<T> where T : class
    {
        public Task Add(T Entity);
        public Task<string> AddSome(IEnumerable<T> Entities);

        public Task Delete(T Entity);

        public Task<IEnumerable<T>> GetAll();

        public Task Update(T Entity);


    }
}
