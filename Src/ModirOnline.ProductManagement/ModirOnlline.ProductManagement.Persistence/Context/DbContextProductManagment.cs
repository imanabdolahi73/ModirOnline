
using Microsoft.EntityFrameworkCore;
using ModirOnline.ProductManagement.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModirOnline.ProductManagement.Persistence.Context
{
    public class DbContextProductManagment: DbContext ,IDbContextProductManagement
    {
        
    }
}

