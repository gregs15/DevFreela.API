using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoan.Application.ViewModels;

namespace Zoan.Application.Queries.GetProjectById
{
    public class GetProjectByIdQuery: IRequest<ProjectDetailsViewModel>
    {
        public GetProjectByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
