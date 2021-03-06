﻿using System.Linq;
using System.Collections.Generic;
using Codebreak.Framework.Generic;
using Codebreak.Service.World.Database.Structure;
using Codebreak.Service.World.Game.Action;
using Codebreak.Service.World.Game.Entity;
using Codebreak.Service.World.Frame;
using Codebreak.Service.World.Game.Guild;
using Codebreak.Service.World.Database.Repository;

namespace Codebreak.Service.World.Manager
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class EntityManager : Singleton<EntityManager>
    {
        private readonly Dictionary<long, MerchantEntity> m_merchantById;
        private readonly Dictionary<long, MerchantEntity> m_merchantByAccount;
        private readonly Dictionary<string, MerchantEntity> m_merchantByName;

        private readonly Dictionary<long, CharacterEntity> m_characterById;
        private readonly Dictionary<long, CharacterEntity> m_characterByAccount;
        private readonly Dictionary<string, CharacterEntity> m_characterByNickname;
        private readonly Dictionary<string, CharacterEntity> m_characterByName;
        
        private readonly Dictionary<long, TaxCollectorEntity> m_taxCollectorById;
        private readonly Dictionary<long, MountEntity> m_mountById;

        /// <summary>
        /// 
        /// </summary>
        public long OnlinePlayers
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public EntityManager()
        {
            m_merchantById = new Dictionary<long, MerchantEntity>();
            m_merchantByAccount = new Dictionary<long, MerchantEntity>();
            m_merchantByName = new Dictionary<string, MerchantEntity>();

            m_characterById = new Dictionary<long, CharacterEntity>();
            m_characterByAccount = new Dictionary<long, CharacterEntity>();
            m_characterByName = new Dictionary<string, CharacterEntity>();
            m_characterByNickname = new Dictionary<string, CharacterEntity>();
            
            m_taxCollectorById = new Dictionary<long, TaxCollectorEntity>();

            m_mountById = new Dictionary<long, MountEntity>();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Initialize()
        {
            foreach(var character in CharacterRepository.Instance.All)
                if(character.Merchant)                
                    CreateMerchant(character).StartAction(GameActionTypeEnum.MAP);
            foreach (var mount in MountRepository.Instance.All)
                CreateMount(mount);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="guild"></param>
        /// <param name="taxCollectorDAO"></param>
        /// <returns></returns>
        public TaxCollectorEntity CreateTaxCollector(GuildInstance guild, TaxCollectorDAO taxCollectorDAO)
        {
            var taxCollector = new TaxCollectorEntity(guild, taxCollectorDAO);
            taxCollector.StartAction(GameActionTypeEnum.MAP);
            taxCollector.Map.SubArea.TaxCollector = taxCollector;
            m_taxCollectorById.Add(taxCollector.Id, taxCollector);
            return taxCollector;
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="taxCollector"></param>
        public void RemoveTaxCollector(TaxCollectorEntity taxCollector)
        {
            m_taxCollectorById.Remove(taxCollector.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <param name="characterDAO"></param>
        /// <returns></returns>
        public CharacterEntity CreateCharacter(AccountTicket account, CharacterDAO characterDAO)
        {
            // Uniquement 1 marchant par compte par serveur
            var merchant = GetMerchantByAccount(characterDAO.AccountId);
            if(merchant != null)            
                RemoveMerchant(merchant);
            
            var character = new CharacterEntity(account, characterDAO);         
            m_characterById.Add(character.Id, character);
            m_characterByName.Add(character.Name.ToLower(), character);
            m_characterByAccount.Add(character.AccountId, character);
            m_characterByNickname.Add(account.Pseudo.ToLower(), character);
            OnlinePlayers++;
            Logger.Info("EntityManager online players : " + OnlinePlayers);            
            return character;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="characterDAO"></param>
        /// <returns></returns>
        public MerchantEntity CreateMerchant(CharacterDAO characterDAO)
        {
            var merchant = new MerchantEntity(characterDAO);
            m_merchantById.Add(merchant.Id, merchant);
            m_merchantByName.Add(merchant.Name.ToLower(), merchant);
            m_merchantByAccount.Add(merchant.AccountId, merchant);
            return merchant;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mountDAO"></param>
        /// <returns></returns>
        public MountEntity CreateMount(MountDAO mountDAO)
        {
            var mount = new MountEntity(mountDAO);
            m_mountById.Add(mount.UniqueId, mount);
            return mount;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        public void CharacterDisconnected(CharacterEntity character)
        {
            if (character.PartyId != -1)
                PartyManager.Instance.PartyLeave(character);
            if (character.PartyInvitedPlayerId != -1 || character.PartyInviterPlayerId != -1)
                BasicFrame.Instance.PartyRefuse(character, "");
            if (character.GuildInvitedPlayerId != -1 || character.GuildInviterPlayerId != -1)
                BasicFrame.Instance.GuildJoinRefuse(character, "");
                
            character.AddMessage(() =>
            {
                if (character.Disconnected())
                {
                    RemoveCharacter(character);
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="merchant"></param>
        public void RemoveMerchant(MerchantEntity merchant)
        {
            merchant.AddMessage(() =>
            {
                foreach (var buyer in merchant.Buyers)
                    buyer.AddMessage(() => buyer.AbortAction(GameActionTypeEnum.EXCHANGE));
                merchant.StopAction(GameActionTypeEnum.MAP);
                merchant.Dispose();
                merchant.Merchant = false;

                WorldService.Instance.AddMessage(() =>
                {
                    m_merchantById.Remove(merchant.Id);
                    m_merchantByName.Remove(merchant.Name.ToLower());
                    m_merchantByAccount.Remove(merchant.AccountId);
                });
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="character"></param>
        public void RemoveCharacter(CharacterEntity character)
        {
            WorldService.Instance.AddMessage(() =>
                {
                    OnlinePlayers--;
                    m_characterById.Remove(character.Id);
                    m_characterByName.Remove(character.Name.ToLower());
                    m_characterByAccount.Remove(character.AccountId);
                    m_characterByNickname.Remove(character.Account.Pseudo.ToLower());
                    Logger.Info("EntityManager online players : " + OnlinePlayers);
                });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CharacterEntity GetCharacterById(long id)
        {
            if (m_characterById.ContainsKey(id))
                return m_characterById[id];
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public CharacterEntity GetCharacterByAccount(long accountId)
        {
            if (m_characterByAccount.ContainsKey(accountId))
                return m_characterByAccount[accountId];
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nickname"></param>
        /// <returns></returns>
        public CharacterEntity GetCharacterByNickname(string nickname)
        {
            nickname = nickname.ToLower();
            if (m_characterByNickname.ContainsKey(nickname))
                return m_characterByNickname[nickname];
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public CharacterEntity GetCharacterByName(string name)
        {
            name = name.ToLower();
            if (m_characterByName.ContainsKey(name))
                return m_characterByName[name];
            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MerchantEntity GetMerchantById(long id)
        {
            if (m_merchantById.ContainsKey(id))
                return m_merchantById[id];
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public MerchantEntity GetMerchantByAccount(long accountId)
        {
            if (m_merchantByAccount.ContainsKey(accountId))
                return m_merchantByAccount[accountId];
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public MerchantEntity GetMerchantByName(string name)
        {
            name = name.ToLower();
            if (m_merchantByName.ContainsKey(name))
                return m_merchantByName[name];
            return null;
        }    

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MountEntity GetMountById(long id)
        {
            if (m_mountById.ContainsKey(id))
                return m_mountById[id];
            return null;
        }
    }
}
