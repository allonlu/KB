using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Infrastructure.Runtime.Authorization
{
    public interface IPermissionChecker
    {
        bool IsGranted(int agentId, string permissionName);
    }
}
