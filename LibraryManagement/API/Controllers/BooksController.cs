using AutoMapper;
using DomainModels.Models.Dtos;
using DomainModels.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IRepository<Book> _repository;
        private readonly IMapper _mapper;

        public BooksController(IRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _repository.GetAllAsync();
            return Ok(_mapper.Map<List<BookDto>>(books));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var book = await _repository.GetAsync(id);
            if (book == null) return NotFound("Bu idde kitab yoxdur");
            return Ok(_mapper.Map<BookDto>(book));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            var result = await _repository.AddAsync(book);
            if (!result) return BadRequest("Something bad happened");
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BookDto bookDto)
        {
            Book existBook = await _repository.GetAsync(id);
            if (existBook == null) return NotFound("There is no student with this id");
            existBook.Name = bookDto.Name;
            existBook.Author = bookDto.Author;
            existBook.Year = bookDto.Year;
            bool result = _repository.Update(existBook);
            if (!result) return BadRequest("Something bad happened");
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
