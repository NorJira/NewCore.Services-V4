using System;
using Microsoft.EntityFrameworkCore;
using NewCore.Data;
using NewCore.Services.CustomerServices;
// using NewCore.Services.ServiceInterfaces;
using static NewCore.Services.CustomerServices;

namespace NewCore.Services
{
    // private readonly DbContext NewCoreDataContext;

    public partial class CustomerServices : Services.CustomerServices.ICustomerServices
    {
        public void CustomerAddress()
        {
        }
    }
}
