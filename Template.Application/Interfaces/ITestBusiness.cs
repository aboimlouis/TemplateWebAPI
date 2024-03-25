using Template.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.Interfaces
{
    public interface ITestBusiness
    {
        Task<TestDTO?> GetTest();
    }
}
