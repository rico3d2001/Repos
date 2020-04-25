using AutoMapper;
using Brass.Materiais.Dominio.Servico.Interfaces;
using Brass.Materiais.RepositorioSQLitePlant.Common;
using SQLiteWithCSharp.Utility;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace Brass.Materiais.Dominio.Servico.Service
{
    public class DominioService<T> : IDominioService<T> where T : class, new()
    {
        protected IRepoSQLiteService<T> _repositorioService;
        //private IMapper _mapper;

        public DominioService(IRepoSQLiteService<T> repositorioService)
        {
            _repositorioService = repositorioService;

        }

        public void Start(string connectionString)
        {
            Context.ConnectionString = connectionString;
        }

        public long Add(T entity)
        {
            return _repositorioService.Add(entity);
        }

        public void AddRange(IList<T> entities)
        {
            _repositorioService.AddRange(entities);
        }

        public IList<T> Find(IEnumerable<object> ids)
        {
            return _repositorioService.Find(ids);
        }

        public IList<T> Find(IFilter<T> filter)
        {
            return _repositorioService.Find(filter);
        }

        public IList<T> GetAll()
        {
            //return _repositorioService.GetAll();
            return _repositorioService.GetAll().ToList();
            //return _mapper.Map<List<U>>(engineeringItems);
        }

        public IList<T> GetAll(string commandText)
        {
            return _repositorioService.GetAll(commandText);
        }

        public IList<TEntity> GetAll<TEntity>(string commandText) where TEntity : class, new()
        {
            return _repositorioService.GetAll<TEntity>(commandText);
        }

        public T GetById(object id)
        {
            return _repositorioService.GetById(id);
        }

        public SQLiteConnection GetConnection()
        {
            return _repositorioService.GetConnection();
        }

        public void Update(T entity)
        {
            _repositorioService.Update(entity);
        }

        public void UpdateRange(IList<T> entities)
        {
            _repositorioService.UpdateRange(entities);
        }

        public void Dispose()
        {
            _repositorioService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
