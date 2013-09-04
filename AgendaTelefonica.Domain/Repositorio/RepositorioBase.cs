using System;
using System.Data;
using AgendaTelefonica.Domain.Entidades.Interfaces;
using AgendaTelefonica.Domain.Mapeamento;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System.Collections.Generic;

namespace AgendaTelefonica.Domain.Repositorio
{
    public abstract class RepositorioBase
    {
        public const string NHibernateSessionKey = "nhibernate.session.key";
        public static ISessionFactory Factory = CreateSessionFactory();

        private static ISession _session;
        private static readonly object SyncObj = 1;

        public static ISession Session
        {
            get { return _session ?? (_session = GetCurrentSession()); }
            set { _session = value; }
        }

        #region Methods Generics to acess Database

        protected RepositorioBase() { }

        protected RepositorioBase(ISession session)
        {
            Session = session;
        }

        public virtual T Get<T>(int id)
        {
            return Session.Get<T>(id);
        }

        public virtual IList<T> All<T>()
        {
            return Session.CreateCriteria(typeof(T)).List<T>();
        }

        public virtual void Save(IRaizDeAgregacao<int> root)
        {
            var transaction = Session.BeginTransaction(IsolationLevel.ReadUncommitted);
            Session.SaveOrUpdate(root);
            transaction.Commit();
        }

        public virtual void SaveList(List<IRaizDeAgregacao<int>> roots)
        {
            var transaction = Session.BeginTransaction(IsolationLevel.ReadUncommitted);

            try
            {
                foreach (var root in roots)
                {
                    Session.SaveOrUpdate(root);
                }
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public virtual void SaveList<T>(List<T> roots)
        {
            var transaction = Session.BeginTransaction(IsolationLevel.ReadUncommitted);

            try
            {
                foreach (var root in roots)
                {
                    Session.SaveOrUpdate(root);
                }
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public virtual void Delete(IRaizDeAgregacao<int> root)
        {
            var transaction = Session.BeginTransaction(IsolationLevel.ReadUncommitted);
            Session.Delete(root);
            transaction.Commit();
        }

        #endregion

        #region Methods of Session and Transaction

        public static void CloseTransaction(ITransaction transaction)
        {
            transaction.Dispose();
        }

        public static ISession GetCurrentSession()
        {
            ISession currentSession;
            lock (SyncObj)
                currentSession = Factory.OpenSession();
            return currentSession;
        }

        public static ISessionFactory CreateSessionFactory()
        {
            return
            Fluently.Configure().Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c
            .FromAppSetting("connection")
            )).Mappings(m => m.FluentMappings.AddFromAssemblyOf<PessoaMap>()).BuildSessionFactory();
        }

        #endregion
    }
}