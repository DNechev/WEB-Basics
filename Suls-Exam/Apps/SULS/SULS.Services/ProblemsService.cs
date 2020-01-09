using SULS.Data;
using SULS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SULS.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly SULSContext db;

        public ProblemsService(SULSContext db)
        {
            this.db = db;
        }
        public void CreateProblem(string name, int totalPoints)
        {
            var problem = new Problem
            {
                Name = name,
                Points = totalPoints
            };

            if(problem == null)
            {
                return;
            }

            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }
        
        public Problem GetProblemById(string id)
        {
            var problem = this.db.Problems.FirstOrDefault(p => p.Id == id);

            return problem;
        }

        public IQueryable<Problem> GetAllProblems()
        {
            var problems = this.db.Problems;

            return problems;
        }
    }
}
