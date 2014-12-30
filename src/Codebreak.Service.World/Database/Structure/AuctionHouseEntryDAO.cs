﻿using Codebreak.Framework.Database;
using Codebreak.Service.World.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebreak.Service.World.Database.Structure
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class AuctionHouseEntryDAO : DataAccessObject<AuctionHouseEntryDAO>
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public long ItemId
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public int AuctionHouseId
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public long OwnerId
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public long Price
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime InitialDate
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="houseId"></param>
        /// <param name="ownerId"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public static AuctionHouseEntryDAO Create(long itemId, int houseId, long ownerId, long price)
        {
            var entry = new AuctionHouseEntryDAO()
            {
                ItemId = itemId,
                AuctionHouseId = houseId,
                OwnerId = ownerId,
                Price = price,
                InitialDate = DateTime.Now
            };
            if (!AuctionHouseEntryRepository.Instance.Insert(entry))
                return null;
            return entry;
        }
    }
}