using Arkitektur.Entity.Entities.Common;

namespace Arkitektur.DataAccess.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity:BaseEntity
    {
        Task<List<TEntity>> GetAllAsync();

        IQueryable<TEntity> GetQueryable();

        Task<TEntity> GetByIdAsync(int id);
        Task CreateAsync(TEntity entity);

        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}

//1.
//IGenericRepository<Category> categoryRepository=
//new GenericRepository<Category>(); şeklinde kullanımı
//sağlıyor interface içinde generic olması. 
// bağımlılık azalır

// 2.
// Metot geriye değer dönerse Async de Task İÇİNDE SARMALIYOZ
//Eğer dönmezse Task CreateAsync yazımı gibi sadece Task yazıyoz.