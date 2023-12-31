﻿using Backend.Models;

namespace Backend.Interfaces
{
    public interface ILevelService
    {
        Task<IEnumerable<Level>> FindAll();
    }
}
