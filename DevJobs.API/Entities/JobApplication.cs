namespace DevJobs.API.Entities
{
    public class JobApplication
    {       
        public JobApplication(string applicanteName, string applicanteEmail, int idJobVacancy) 
        {            
            ApplicantName = applicanteName;
            ApplicanteEmail = applicanteEmail; 
            IdJobVacancy = idJobVacancy;  
        }

        public int Id { get; private set; }
        public string ApplicantName { get; private set; }
        public string ApplicanteEmail { get; private set; }
        public int IdJobVacancy { get; private set; }                                         
    }
}