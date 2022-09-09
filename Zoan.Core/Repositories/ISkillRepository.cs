using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoan.Core.DTOs;

namespace Zoan.Core.Repositories
{
    public interface ISkillRepository
    {
       Task <List<SkillDTO>> GetAllAsync();
    }
}
