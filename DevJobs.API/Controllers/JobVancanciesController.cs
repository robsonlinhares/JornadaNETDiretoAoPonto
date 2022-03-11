namespace DevJobs.API.Controllers
{
    using DevJobs.API.Entities;
    using DevJobs.API.Models;
    using DevJobs.API.Persistence;
    using DevJobs.API.Persistence.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("api/job-vacancies")]
    [ApiController]
    public class JobVacanciesController : ControllerBase
    {
        private readonly IJobVacancyRepository _jobVacancyRepository;

        public JobVacanciesController(IJobVacancyRepository jobVacancyRepository)
        {
            _jobVacancyRepository = jobVacancyRepository;
        }

        //GET api/Job-vacancies
        [HttpGet]
        public IActionResult GetAll()
        {
            var jobVacancies = _jobVacancyRepository.GetAll();
            return Ok(jobVacancies);
        }

        //GET api/Job-vacancies/4
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var jobVacancy = _jobVacancyRepository.GetById(id);

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

          _jobVacancyRepository.Add(jobVacancy);
          
            return CreatedAtAction("GetById", 
                                    new {id = jobVacancy.Id},
                                    jobVacancy);
        }

        //put api/Job-vacancies/4
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateJobVacancyInputModel model)
        {
              var jobVacancy = _jobVacancyRepository.GetById(id);

            if (jobVacancy == null)
                return NotFound();

            jobVacancy.Update(model.Title, model.Description);
            
            _jobVacancyRepository.Update(jobVacancy);

            
            return NoContent();
        }
    }
}