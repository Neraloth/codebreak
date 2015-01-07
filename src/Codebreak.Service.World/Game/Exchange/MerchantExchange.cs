﻿using Codebreak.Service.World.Game.Entity;
using Codebreak.Service.World.Manager;
using Codebreak.Service.World.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codebreak.Service.World.Game.Exchange
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class MerchantExchange : ExchangeBase
    {
        /// <summary>
        /// 
        /// </summary>
        public CharacterEntity Character
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public MerchantEntity Merchant
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        /// <param name="merchant"></param>
        public MerchantExchange(CharacterEntity character, MerchantEntity merchant)
            : base(ExchangeTypeEnum.EXCHANGE_MERCHANT)
        {
            Character = character;
            Merchant = merchant;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Create()
        {
            base.Create();
            SendItemsList();
        }

        /// <summary>
        /// 
        /// </summary>
        public void SendItemsList()
        {
            Character.Dispatch(WorldMessage.EXCHANGE_PERSONAL_SHOP_ITEMS_LIST(Merchant.PersonalShop.Items));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string SerializeAs_ExchangeCreate()
        {
            return Merchant.Id.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="templateId"></param>
        /// <param name="quantity"></param>
        public override void BuyItem(EntityBase actor, long itemId, long quantity)
        {         
            if(!Merchant.HasGameAction(Action.GameActionTypeEnum.MAP))
            {
                Character.Dispatch(WorldMessage.EXCHANGE_BUY_ERROR());
                return;
            }

            var item = Merchant.PersonalShop.GetItem(itemId);
            if(item == null)
            {
                Character.Dispatch(WorldMessage.INFORMATION_MESSAGE(InformationTypeEnum.INFO, InformationEnum.INFO_AUCTION_ALREADY_SOLD));
                SendItemsList();
                return;
            }

            if (quantity > item.Quantity)
                quantity = item.Quantity;

            var price = item.MerchantPrice * quantity;

            if(Character.Inventory.Kamas < price)
            {
                Character.Dispatch(WorldMessage.INFORMATION_MESSAGE(InformationTypeEnum.ERROR, InformationEnum.ERROR_NOT_ENOUGH_KAMAS, price));
                return;
            }

            Merchant.Inventory.AddKamas(price);

            Character.CachedBuffer = true;
            Character.Inventory.SubKamas(price);
            Character.Inventory.AddItem(Merchant.PersonalShop.RemoveItem(itemId, (int)quantity));
            SendItemsList();
            Character.CachedBuffer = false;

            if(Merchant.PersonalShop.Items.Count == 0)
            {
                EntityManager.Instance.RemoveMerchant(Merchant);
            }
        }
    }
}