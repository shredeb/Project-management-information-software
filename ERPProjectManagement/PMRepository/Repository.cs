using ERPProjectManagement.DataLayer;
using ERPProjectManagement.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProjectManagement.PMRepository
{
    public partial class Repository<T> : IRepository<T> where T : class
    {

        private ProjectManagementDBEntities context = ContextInstance;
       
        protected static ProjectManagementDBEntities ContextInstance
        {
            get { return new ProjectManagementDBEntities(); }
        }

        DbSet<T> _entity;
        public Repository()
        {
            _entity = context.Set<T>();
        }
        private bool? SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
        public DbSet<T> Entities
        {
            get { return _entity; }
        }

        DbSet<T> IRepository<T>.Entities
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public DbSet<PT> Entity<PT>() where PT : class
        {
            return context.Set<PT>();
        }
        public static DbSet<PT> Entity_<PT>() where PT : class
        {
            return ContextInstance.Set<PT>();
        }
        public T Get(params object[] keyValues)
        {
            return _entity.Find(keyValues);
        }
        public static T Get_(params object[] keyValues)
        {
            return ContextInstance.Set<T>().Find(keyValues);
        }
        public static T Find_(params object[] keyValues)
        {
            return ContextInstance.Set<T>().Find(keyValues);
        }
        public static MT Find<MT>(params object[] keyValues) where MT : class
        {
            return ContextInstance.Set<MT>().Find(keyValues);
        }

        public MT Get<MT>(params object[] keyValues) where MT : class
        {
            return context.Set<MT>().Find(keyValues);
        }
        public static MT Get_<MT>(params object[] keyValues) where MT : class
        {
            return ContextInstance.Set<MT>().Find(keyValues);
        }
        public IEnumerable<T> GetEnumerator(string qurey, params object[] parameters)
        {
            return _entity.SqlQuery(qurey, parameters);
        }

        public bool? Insert(T entity)
        {
            _entity.Add(entity);
            return SaveChanges();
        }

        public bool? Insert<MT>(MT entity) where MT : class
        {
            context.Set<MT>().Add(entity);
            return SaveChanges();
        }
        public static bool? Insert_(T entity)
        {
            using (var _context = ContextInstance)
            {
                _context.Set<T>().Add(entity);
                return _context.SaveChanges() > 0;
            }
        }
        public static bool? Insert_<MT>(MT entity) where MT : class
        {
            using (var _context = ContextInstance)
            {
                _context.Set<MT>().Add(entity);
                return _context.SaveChanges() > 0;
            }
        }
        public bool? Update(T entity, params object[] keyValues)
        {
            var entry = context.Entry(entity);
            if (keyValues.Length > 0)
            {
                if (entry.State == EntityState.Detached)
                {
                    T attached = _entity.Find(keyValues);
                    if (attached != null)
                    {
                        var attachedEntry = context.Entry(attached);
                        attachedEntry.CurrentValues.SetValues(entity);
                    }
                    else
                        entry.State = EntityState.Modified;
                }
            }
            else
            {
                entry.State = EntityState.Modified;
            }
            return SaveChanges();
        }
        public bool? Update<MT>(MT entity, params object[] keyValues) where MT : class
        {
            var entry = context.Entry(entity);
            if (keyValues.Length > 0)
            {
                if (entry.State == EntityState.Detached)
                {
                    MT attached = context.Set<MT>().Find(keyValues);
                    if (attached != null)
                    {
                        var attachedEntry = context.Entry(attached);
                        attachedEntry.CurrentValues.SetValues(entity);
                    }
                    else
                        entry.State = EntityState.Modified;
                }
            }
            else
            {
                entry.State = EntityState.Modified;
            }
            return SaveChanges();
        }
        public static bool? Update_(T entity, params object[] keyValues)
        {
            using (var _context = ContextInstance)
            {
                var entry = _context.Entry(entity);
                if (keyValues.Length > 0)
                {
                    if (entry.State == EntityState.Detached)
                    {
                        T attached = _context.Set<T>().Find(keyValues);
                        if (attached != null)
                        {
                            var attachedEntry = _context.Entry(attached);
                            attachedEntry.CurrentValues.SetValues(entity);
                        }
                        else
                            entry.State = EntityState.Modified;
                    }
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
                return _context.SaveChanges() > 0;
            }
        }
        public static bool? Update_<MT>(MT entity, params object[] keyValues) where MT : class
        {
            using (var _context = ContextInstance)
            {
                var entry = _context.Entry<MT>(entity);
                if (keyValues.Length > 0)
                {
                    if (entry.State == EntityState.Detached)
                    {
                        MT attached = _context.Set<MT>().Find(keyValues);
                        if (attached != null)
                        {
                            var attachedEntry = _context.Entry(attached);
                            attachedEntry.CurrentValues.SetValues(entity);
                        }
                        else
                            entry.State = EntityState.Modified;
                    }
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
                return _context.SaveChanges() > 0;
            }
        }
        public bool? Delete(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }
        public bool? Delete<MT>(MT entity) where MT : class
        {
            context.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }
        public static bool? Delete_(T entity)
        {
            using (var _context = ContextInstance)
            {
                //var entry = _context.Entry(entity);
                _context.Entry(entity).State = EntityState.Deleted;
                return _context.SaveChanges() > 0;
            }
        }
        public static bool? Delete_<MT>(MT entity) where MT : class
        {
            using (var _context = ContextInstance)
            {
                //var entry = _context.Entry<MT>(entity);
                _context.Entry(entity).State = EntityState.Deleted;
                return _context.SaveChanges() > 0;
            }
        }

        public void SetDelete<MT>(MT entity) where MT : class
        {
            context.Entry(entity).State = EntityState.Deleted;
        }
        public bool? ConfirmDelete()
        {
            return SaveChanges();
        }

    }
}
