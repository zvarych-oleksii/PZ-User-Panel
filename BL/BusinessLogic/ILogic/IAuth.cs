using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_User_Panel_BL.BusinessLogic.ILogic
{
    internal interface IAuth
    {
        int Login(string username, string password);

        bool CheckPremission(int userId);
    }
}
