using SULS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SULS.Services
{
    public interface ISubmissionsService
    {
        string GetProblemName(string id);

        void CreateSubmission(string id, string code, string userId);

        ICollection<Submission> GetAllSubmissionsByProblem(string problemId);

        void Delete(string id);
    }
}
