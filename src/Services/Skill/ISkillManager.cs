using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biberg.MyPortfolio.Data;

namespace Biberg.MyPortfolio.Services.Skill
{
    interface ISkillManager
    {
        List<Biberg.MyPortfolio.Data.Skill> GetAll { get; }

        bool GetSkill();
        bool Update();
        bool Remove();
    }
}
