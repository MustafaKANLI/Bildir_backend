﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IWorkHistoryRepositoryAsync : IGenericRepositoryAsync<WorkHistory>
    {
        //Task<bool> IsUniqueBarcodeAsync(string barcode);
    }
}
