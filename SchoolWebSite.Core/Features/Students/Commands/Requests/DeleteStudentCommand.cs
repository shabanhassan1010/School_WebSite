using MediatR;
using SchoolWebSite.Core.Bases;

namespace SchoolWebSite.Core.Features.Students.Commands.Models
{
    public class DeleteStudentCommand : IRequest<Response<string>>
    {
        #region Fields
        public int Id { get; set; }
        #endregion

        #region Constructor
        public DeleteStudentCommand(int id)
        {
            Id = id;
        }
        #endregion
    }
}
