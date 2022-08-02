﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoTask.Models;
using ToDoTaskServer.Models.Entity;
using ToDoTaskServer.Models.ViewModel;

namespace ASPBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private ApplicationContext _db;

        public ProjectController(ILogger<ProjectController> logger, ApplicationContext db)
        {
            _logger = logger;
            _db = db;
        }
        [HttpGet]
        [Route("ViewProject")]
        public async Task<IActionResult> ViewPeroject()
        {
            try
            {
                _logger.LogInformation("Запрос получен");
                                
                return Ok(_db.Project);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateProject")]
        public async Task<ActionResult<Project>> CreateProject([FromBody] ProjectViewModel model) 
        {
            try
            {
                _logger.LogInformation("Запрос получен");
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ProjectViewModel, Project>());
                var mapper = new Mapper(config);
                var result = mapper.Map<Project>(model);

                _db.Project.Add(result);
                _db.SaveChanges();

                return Ok(result);

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Route("DeleteProject")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProject(int id)
        {
            try
            {
                _logger.LogInformation("Запрос получен");

                var search = _db.Project.FirstOrDefault(t => t.Id == id);
                _logger.LogInformation("Запрос обработан");
                if (search == null) Ok("Задача не найдена");

                var result = _db.Project.Remove(search);
                _db.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return BadRequest(ex.Message);
            }
        }
    }
}
