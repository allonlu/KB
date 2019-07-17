using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Infrastructure.Runtime.Authorization
{
    public class PermissionChecker : IPermissionChecker
    {
        public bool IsGranted(int agentId, string permissionName)
        {
            return true;
        }
    }
}
