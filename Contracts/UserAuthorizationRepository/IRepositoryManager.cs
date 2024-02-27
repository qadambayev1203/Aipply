﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.UserAuthorizationRepository
{
    public interface IRepositoryManager
    {
        IUserRepositoryy User { get; }
        Task SaveAsync();
    }
}