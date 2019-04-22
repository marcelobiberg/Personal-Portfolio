using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyPortfolio.Data;

namespace MyPortfolio.Services.Skill
{
    interface ISkillManager
    {
        List<MyPortfolio.Data.Skill> GetAll { get; }

        bool GetSkill();
        bool Update();
        bool Remove();
    }
}
