﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFood.DataAccess.Repository.IRepository
{
    public interface IUnidadTrabajo : IDisposable
    {
        IUserRepository User { get;  }

        Task Guardar();

    }
}
