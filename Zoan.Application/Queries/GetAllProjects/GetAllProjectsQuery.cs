using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoan.Application.ViewModels;

namespace Zoan.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQuery: IRequest <List<ProjectViewModel>>
    {
        public GetAllProjectsQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
