﻿using Centroware.Model.DTOs.Works;
using System.Threading.Tasks;

namespace Centroware.Service.Interfaces
{
    public interface IWorkService
    {
        Task<CreateWorkDto> AddWork(CreateWorkDto input);
        Task<CreateWorkDto> UpdateWork(UpdateWorkDto input);
    }
}