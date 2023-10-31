﻿using AutoMapper;
using e_commerce_API.Data.Entities;
using e_commerce_API.Models;
using e_commerce_API.Services.Implementations;
using e_commerce_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public AdminController(IAdminService adminService, IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _adminService = adminService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAdmins()
        {
            //string role =User.Claims.SingleOrDefault(c => c.Type.Contains("role")).Value;
            //if (role == "SuperAdmin" )
            return Ok(_adminService.GetAdmins());
            //return Forbid();
        }
        [HttpGet("{email}", Name = nameof(GetAdminByEmail))]
        public IActionResult GetAdminByEmail(string email)
        {
            var admin = _userService.GetByEmail(email);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdmin(AdminDto adminForCreation)
        {
            Admin? userEntity = _mapper.Map<Admin>(adminForCreation);
            if (_userService.GetByEmail(userEntity.Email) != null)
            {
                return Conflict("Este Email ya esta en uso");
            }
            if (userEntity == null)
            {
                return BadRequest();
            }
            _adminService.AddAdmin(userEntity);

            await _adminService.SaveChangesAsync();

            return CreatedAtRoute(nameof(GetAdminByEmail), new { email = userEntity.Email }, userEntity);

        }
    }
}
