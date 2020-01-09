using SULS.Data;
using SULS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SULS.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly SULSContext db;

        public SubmissionsService(SULSContext db)
        {
            this.db = db;
        }

        public void CreateSubmission(string id, string code, string userId)
        {
            int problemsTotalPoints = this.db.Problems.FirstOrDefault(p => p.Id == id).Points;
            Random achievedPoints = new Random();

            Submission submission = new Submission
            {
                ProblemId = id,
                Code = code,
                CreatedOn = DateTime.UtcNow,
                AchievedResult = achievedPoints.Next(0, problemsTotalPoints),
                UserId = userId,
                User = this.db.Users.FirstOrDefault(u => u.Id == userId),
                Problem = this.db.Problems.FirstOrDefault(p => p.Id == id)
            };

            this.db.Submissions.Add(submission);
            this.db.Problems.FirstOrDefault(p => p.Id == id).Submissions.Add(submission);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            var submissionToDelete = this.db.Submissions.FirstOrDefault(s => s.Id == id);

            this.db.Submissions.Remove(submissionToDelete);
            this.db.SaveChanges();
        }

        public ICollection<Submission> GetAllSubmissionsByProblem(string problemId)
        {
            var submissions = this.db.Submissions.Where(s => s.ProblemId == problemId).ToList();
            return submissions;
        }

        public string GetProblemName(string id)
        {
            var problem = db.Problems.FirstOrDefault(p => p.Id == id);

            return problem.Name;
        }
    }
}
