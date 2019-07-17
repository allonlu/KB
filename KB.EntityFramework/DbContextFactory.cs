using Castle.MicroKernel;
using System.Threading;
using System.Configuration;
using System.Security.Claims;
using KB.Infrastructure.Runtime.Security;
using Microsoft.EntityFrameworkCore;

namespace KB.EntityFramework
{
    public class DbContextFactory
    {
        public static DbContext Create(IKernel kernel)
        {
            return new KBDataContext();
        }
    }
}
