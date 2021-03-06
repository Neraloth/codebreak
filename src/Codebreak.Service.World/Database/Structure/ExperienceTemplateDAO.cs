﻿using Codebreak.Framework.Database;

namespace Codebreak.Service.World.Database.Structure
{
    /// <summary>
    /// 
    /// </summary>
    [Table("experiencetemplate")]
    public sealed class ExperienceTemplateDAO : DataAccessObject<ExperienceTemplateDAO>
    {
        [Key]
        public int Level
        {
            get;
            set;
        }
        public long Character
        {
            get;
            set;
        }
        public long Job
        {
            get;
            set;
        }
        public long Mount
        {
            get;
            set;
        }
        public long Pvp
        {
            get;
            set;
        }
        public int Living
        {
            get;
            set;
        }
        public long Guild
        {
            get;
            set;
        }
    }
}
