﻿using System;
using System.Collections.Generic;
using Codebreak.Framework.Network;
using Codebreak.Service.World.Game;
using Codebreak.Service.World.Game.Entity;
using Codebreak.Service.World.Game.Spell;
using Codebreak.Service.World.Manager;
using Codebreak.Service.World.Game.Stats;
using Codebreak.Service.World.Database.Structures;

namespace Codebreak.Service.World.Frames
{
    public sealed class BasicFrame : FrameBase<BasicFrame, EntityBase, string>
    {
        /// <summary>
        /// 
        /// </summary>
        private Dictionary<int, EffectEnum> _statById = new Dictionary<int, EffectEnum>()
        {
            {10, EffectEnum.AddStrength},
            {11, EffectEnum.AddVitality},
            {12, EffectEnum.AddWisdom},
            {13, EffectEnum.AddChance},
            {14, EffectEnum.AddAgility},
            {15, EffectEnum.AddIntelligence},
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public override Action<EntityBase, string> GetHandler(string message)
        {
            if (message.Length < 2)
                return null;

            switch (message[0])
            {
                case 'P':
                    switch(message[1])
                    {
                        case 'I': // PartyInvite
                            break;

                        case 'A': // PartyAccept
                            break;
                        
                        case 'R': // Party
                            break;

                        case 'V': // Leave
                            break;
                    }
                    break;
                case 'A':
                    switch (message[1])
                    {
                        case 'B':
                            return BoostStats;
                    }
                    break;

                case 'B':
                    switch (message[1])
                    {
                        case 'D':
                            return BasicDate;

                        case 'T':
                            return BasicTime;

                        case 'M':
                            return BasicMessage;
                    }
                    break;

                case 'p':
                    if (message == "ping")
                        return BasicPong;
                    break;

                case 'q':
                    if (message == "qping")
                        return BasicQPong;
                    break;
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="message"></param>
        private void PartyInvite(EntityBase entity, string message)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="message"></param>
        private void PartyDecline(EntityBase entity, string message)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="message"></param>
        private void PartyAccept(EntityBase entity, string message)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="message"></param>
        private void BoostStats(EntityBase entity, string message)
        {
            var character = (CharacterEntity)entity;
            var statId = 0;

            if (!int.TryParse(message.Substring(2), out statId))
            {
                entity.Dispatch(WorldMessage.BASIC_NO_OPERATION());
                return;
            }

            if (!_statById.ContainsKey(statId))
            {
                entity.Dispatch(WorldMessage.BASIC_NO_OPERATION());
                return;
            }

            entity.AddMessage(() =>
            {
                var effect = _statById[statId];
                var actualValue = entity.Statistics.GetEffect(effect).Base;
                var boostValue = statId == 11 && character.Breed == CharacterBreedEnum.BREED_SACRIEUR ? 2 : 1;
                var requiredPoint = GenericStats.GetRequiredStatsPoint(character.Breed, statId, actualValue);

                if (character.CaractPoint < requiredPoint)
                {
                    entity.Dispatch(WorldMessage.BASIC_NO_OPERATION());
                    return;
                }

                character.CaractPoint -= requiredPoint;

                switch (effect)
                {
                    case EffectEnum.AddStrength:
                        character.DatabaseRecord.Strength += boostValue;
                        break;

                    case EffectEnum.AddVitality:
                        character.DatabaseRecord.Vitality += boostValue;
                        break;

                    case EffectEnum.AddWisdom:
                        character.DatabaseRecord.Wisdom += boostValue;
                        break;

                    case EffectEnum.AddIntelligence:
                        character.DatabaseRecord.Intelligence += boostValue;
                        break;

                    case EffectEnum.AddAgility:
                        character.DatabaseRecord.Agility += boostValue;
                        break;
                }

                character.Statistics.AddBase(effect, boostValue);
                character.Dispatch(WorldMessage.ACCOUNT_STATS(character));
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="message"></param>
        private void BasicPong(EntityBase entity, string message)
        {
            entity.Dispatch(WorldMessage.BASIC_PONG());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="message"></param>
        private void BasicQPong(EntityBase entity, string message)
        {
            entity.Dispatch(WorldMessage.BASIC_QPONG());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="message"></param>
        private void BasicDate(EntityBase entity, string message)
        {
            entity.Dispatch(WorldMessage.BASIC_DATE());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="message"></param>
        private void BasicTime(EntityBase entity, string message)
        {
            entity.Dispatch(WorldMessage.BASIC_TIME());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="message"></param>
        private void BasicMessage(EntityBase entity, string message)
        {
            var messageData = message.Substring(2).Split('|');
            var channel = messageData[0];
            var messageContent = messageData[1];

            if (channel.Length == 1)
            {
                entity.AddMessage(() =>
                    {
                        entity.DispatchChatMessage((ChatChannelEnum)channel[0], messageContent);
                    });
            }
            else
            {
                var remoteEntity = EntityManager.Instance.GetCharacter(channel);

                if (remoteEntity == null)
                {
                    entity.Dispatch(WorldMessage.CHAT_MESSAGE_ERROR_PLAYER_OFFLINE());
                    return;
                }

                entity.AddMessage(() =>
                {
                    entity.DispatchChatMessage(ChatChannelEnum.CHANNEL_PRIVATE_SEND, messageContent, remoteEntity);
                });

                remoteEntity.AddMessage(() =>
                {
                    remoteEntity.DispatchChatMessage(ChatChannelEnum.CHANNEL_PRIVATE_RECEIVE, messageContent, entity);
                });
            }
        }
    }
}