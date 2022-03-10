namespace DevJobs.API.Controllers
{
    using DevJobs.API.Entities;
    using DevJobs.API.Models;
    using DevJobs.API.Persistence;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/job-vacancies")]
    [ApiController]
    public class JobVacanciesController : ControllerBase
    {
        private readonly DevJobsContext _context;

        public JobVacanciesController(DevJobsContext context)
        {
            _context = context;
        }

        //GET api/Job-vacancies
        [HttpGet]
        public IActionResult GetAll()
        {
            var jobVacancies = _context.Jobvacancies;
            return Ok(jobVacancies);
        }

        //GET api/Job-vacancies/4
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var jobVacancy = _context.Jobvacancies
                .SingleOrDefault(jv => jv.Id == id);

            if (jobVacancy == null)
                return NotFound();

            return Ok(jobVacancy);
        }

        //POST api/Job-vacancies
        [HttpPost]
        public IActionResult Post(AddJobVacancyInputModel model)
        {
            var jobVacancy = new JobVacancy(
                model.Title,
                model.Description,
                model.Company,
                model.IsRemote,
                model.SalaryRange
            );  

            _context.Jobvacancies.Add(jobVacancy);
            return CreatedAtAction("GetById", 
                                    new {id = jobVacancy.Id},
                                    jobVacancy);
        }

        //put api/Job-vacancies/4
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateJobVacancyInputModel model)
        {
              var jobVacancy = _context.Jobvacancies
                .SingleOrDefault(jv => jv.Id == id);

            if (jobVacancy == null)
                return NotFound();

            jobVacancy.Update(model.Title, model.Description);
            
            return NoContent();
        }
    }
}