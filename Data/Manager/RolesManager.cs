﻿using Data.Base;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Manager
{
    public class RolesManager : BaseManager<Roles>
    {
        public async override Task<List<Roles>> Borrar(Roles entity)
        {
            throw new NotImplementedException();
        }

        public async override Task<List<Roles>> BuscarAsync(Roles entity)
        {
            throw new NotImplementedException();
        }

        public async override Task<List<Roles>> BuscarListaAsync()
        {
            return await contextSingleton.Roles.Where(rol => rol.Activo).ToListAsync();
        }
    }
}
