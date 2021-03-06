﻿using Codebreak.Framework.Database;
using Codebreak.Service.World.Database.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebreak.Service.World.Database.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class MapTemplateRepository : Repository<MapTemplateRepository, MapTemplateDAO>
    {
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<int, MapTemplateDAO> m_mapById;

        /// <summary>
        /// 
        /// </summary>
        public MapTemplateRepository()
        {
            m_mapById = new Dictionary<int, MapTemplateDAO>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="map"></param>
        public override void OnObjectAdded(MapTemplateDAO map)
        {
            m_mapById.Add(map.Id, map);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="map"></param>
        public override void OnObjectRemoved(MapTemplateDAO map)
        {
            m_mapById.Remove(map.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<MapTemplateDAO> GetMaps()
        {
            return m_dataObjects;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MapTemplateDAO GetById(int id)
        {
            if (m_mapById.ContainsKey(id))
                return m_mapById[id];
            return null;
        }


        public override void UpdateAll(MySql.Data.MySqlClient.MySqlConnection connection, MySql.Data.MySqlClient.MySqlTransaction transaction)
        {
        }

        public override void DeleteAll(MySql.Data.MySqlClient.MySqlConnection connection, MySql.Data.MySqlClient.MySqlTransaction transaction)
        {
        }

        public override void InsertAll(MySql.Data.MySqlClient.MySqlConnection connection, MySql.Data.MySqlClient.MySqlTransaction transaction)
        {
        }
    }
}
