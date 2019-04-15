using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biberg.MyPortfolio.Data;

namespace Biberg.MyPortfolio.Services.Skill
{
    public class SkillManager : ISkillManager
    {
        private readonly ApplicationDbContext _context;

        public SkillManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Data.Skill> GetAll => _context.Skills.ToList();

        public bool GetSkill()
        {
            throw new NotImplementedException();
        }

        public bool Remove()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }
    }
}
