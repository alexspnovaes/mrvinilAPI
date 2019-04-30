using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System;
using System.Collections.Generic;

namespace API.Controllers
{

    [ApiController]
    public class DiskController : ControllerBase
    {
        private readonly IDiskRepository _diskRepository;
        public DiskController(IDiskRepository diskRepository)
        {
            _diskRepository = diskRepository;
        }

        [HttpGet("v1/disks/{id}")]
        [AllowAnonymous]
        public ActionResult<Disk> GetDiskById(Guid id)
        {
            Disk disk = _diskRepository.GetById(id);

            if (disk == null)
                return NotFound("Disco não encontrado");

            return Ok(disk);
        }

        [HttpGet]
        [Route("v1/disks/paged")]
        public ActionResult<PaginatedResult<Disk>> GetPaged(int genre, int actualPage, int pageSize)
        {
            return Ok(_diskRepository.GetPagedResult(genre,actualPage, pageSize));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("v1/disks/{genre}")]
        public ActionResult<PaginatedResult<Disk>> GetByGenre(int genre)
        {
            return Ok(_diskRepository.GetByGenre(genre));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("v1/disks")]
        public ActionResult<IEnumerable<Disk>> Get()
        {
            return Ok(_diskRepository.GetAll());
        }

    }
}