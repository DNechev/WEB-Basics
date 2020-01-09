using SULS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SULS.Services
{
    public interface IProblemsService
    {
        void CreateProblem(string name, int totalPoints);

        IQueryable<Problem> GetAllProblems();

        Problem GetProblemById(string id);
    }
}
