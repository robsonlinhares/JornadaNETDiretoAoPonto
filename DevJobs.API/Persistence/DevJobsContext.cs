using DevJobs.API.Entities;

namespace DevJobs.API.Persistence
{
    public class DevJobsContext
    {
        public DevJobsContext()
        {
            Jobvacancies = new List<JobVacancy>();
        }

        public List<JobVacancy> Jobvacancies { get; set; }
        
        
    }
}