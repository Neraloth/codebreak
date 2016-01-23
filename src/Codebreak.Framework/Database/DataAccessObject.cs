﻿using log4net;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebreak.Framework.Database
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// 
    public abstract class DataAccessObject<T> : INotifyPropertyChanged
        where T : DataAccessObject<T>, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public static ILog Logger = LogManager.GetLogger(typeof(T));

        /// <summary>
        /// 
        /// </summary>
        public static bool IsRunning
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public static SqlManager SqlMgr
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 
        /// </summary>
        [Write(false)]
        [DoNotNotify]
        public bool IsDirty
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [Write(false)]
        [DoNotNotify]
        public bool IsNew
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [Write(false)]
        [DoNotNotify]
        public bool IsDeleted
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        static DataAccessObject()
        {
            IsRunning = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public DataAccessObject()
        {
            IsDirty = false;
            IsNew = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (IsRunning)            
                IsDirty = true;            
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Update()
        {
            OnBeforeUpdate();
            return SqlMgr.Update((T)this);
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Delete()
        {
            OnBeforeDelete();
            return SqlMgr.Delete((T)this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Insert()
        {
            OnBeforeInsert();
            return SqlMgr.InsertWithKey((T)this);
        }

        /// <summary>
        /// 
        /// </summary>
        [Write(false)]
        public T This
        {
            get
            {
                return (T)this;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Write(false)]
        public string DisplayMember
        {
            get
            {
                return ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void OnBeforeUpdate()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void OnBeforeInsert()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void OnBeforeDelete()
        {
        }
    }
}
