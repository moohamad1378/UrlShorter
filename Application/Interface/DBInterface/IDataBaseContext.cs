using Domain.Url;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interface.DBInterface
{
    public interface IDataBaseContext
    {
        DbSet<ShortUrl> ShortUrls { get; set; }


        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        EntityEntry Entry([NotNullAttribute] object entity);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
