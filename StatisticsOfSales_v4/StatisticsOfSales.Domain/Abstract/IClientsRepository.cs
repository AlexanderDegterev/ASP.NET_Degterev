﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatisticsOfSales.Domain.Entities;

namespace StatisticsOfSales.Domain.Abstract
{
    public interface IClientsRepository
    {
        IQueryable<Client> Clients { get; } 
    }
}
