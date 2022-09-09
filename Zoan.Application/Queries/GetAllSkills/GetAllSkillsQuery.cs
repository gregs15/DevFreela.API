using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zoan.Core.DTOs;

namespace Zoan.Application.Queries.GetAllSkills
{
    public class GetAllSkillsQuery: IRequest <List<SkillDTO>>
    {

    }
}
