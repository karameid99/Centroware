using AutoMapper;
using Centroware.Model.DTOs;
using Centroware.Model.DTOs.Helpers;
using Centroware.Model.DTOs.Users;
using Centroware.Model.Entities.Identity;
using Centroware.Model.ViewModels.Users;
using Centroware.Repository.Interfaces.Generic;
using Centroware.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<CentrowareUser> _userManager;
        private readonly IBaseRepository<CentrowareUser> _userRepository;
        private readonly IMapper _mapper;

        public UserService(UserManager<CentrowareUser> userManager, IBaseRepository<CentrowareUser> userRepository, IMapper mapper)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateUser(CreateUserDto input)
        {
            var userExsits = await _userRepository.Any(x => x.UserName == input.Email);
            if (userExsits)
            {
                return false;
            }
            var user = new CentrowareUser
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                UserName = input.Email,
                Email = input.Email
            };
            var result = await _userManager.CreateAsync(user, input.Password);
            return result.Succeeded;

        }

        public async Task<bool> DeleteUser(string id)
        {
            var user = await _userRepository.Get(id);
            if (user == null)
                return false;
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var skipValue = (pagination.Page - 1) * pagination.PerPage;
            var data = _userRepository.Filter(filter: x =>
           string.IsNullOrEmpty(query.GeneralSearch) || x.FirstName.Contains(query.GeneralSearch),
            orderBy: x => x.OrderByDescending(x => x.Id));
            var dataCount = await data.CountAsync();
            if (skipValue >= dataCount)
            {
                skipValue = 0;
                pagination.Page = 1;
            }
            var pages = Convert.ToInt32(Math.Ceiling(dataCount / (float)pagination.PerPage));
            var dataList = await data.Skip(skipValue).Take(pagination.PerPage).Select(x => new UserVm
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
            }).ToListAsync();
            var response = new ResponseDto
            {
                meta = new Meta
                {
                    page = pagination.Page,
                    perpage = pagination.PerPage,
                    total = dataCount,
                    pages = pages,
                },
                data = dataList

            };
            return response;
        }

        public async Task<UpdateUserDto> GetUser(string id)
        {
            var user = await _userRepository.Get(id);
            if (user == null)
                return null;
            var userVm = _mapper.Map<UpdateUserDto>(user);
            return userVm;
        }

        public async Task<bool> UpdateUser(UpdateUserDto input)
        {
            var userExsits = await _userRepository.Any(x => x.UserName == input.Email && x.Id != input.Id);
            if (userExsits)
                return false;
            var user = await _userRepository.Get(input.Id);
            if (user == null)
                return false;
            user.FirstName = input.FirstName;
            user.LastName = input.LastName;
            user.UserName = input.Email;
            user.Email = input.Email;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;

        }
    }
}
