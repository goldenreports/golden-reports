using GoldenReports.Application.Abstractions.Security;
using GoldenReports.Domain.Common;
using GoldenReports.Domain.Constants;
using GoldenReports.Domain.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GoldenReports.Persistence.Middlewares;

public class AuditMiddleware : IDbContextMiddleware
{
    private readonly IAuthContext authContext;

    public AuditMiddleware(IAuthContext authContext)
    {
        this.authContext = authContext;
    }

    public async Task ProcessModifiedEntries(GoldenReportsDbContext dbContext, IEnumerable<EntityEntry<Entity>> modifiedEntries)
    {
        var currentUser = await this.GetOrCreateCurrentUser(dbContext);
        foreach (var entry in modifiedEntries.Where(x => x.State is EntityState.Added or EntityState.Modified))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreationDate = DateTime.UtcNow;
                entry.Entity.CreatedBy = currentUser;
            }

            entry.Entity.ModificationDate = DateTime.UtcNow;
            entry.Entity.ModifiedBy = currentUser;
        }
    }

    private async Task<User> GetOrCreateCurrentUser(GoldenReportsDbContext dbContext)
    {
        if (this.authContext.CurrentUser == null)
        {
            throw new InvalidOperationException("Current user was not found.");
        }

        var user = dbContext.Users.Local.SingleOrDefault(x => x.AuthContextKey == this.authContext.CurrentUser.AuthContextKey) ??
                   await dbContext.Users.SingleOrDefaultAsync(x => x.AuthContextKey == this.authContext.CurrentUser.AuthContextKey);
        if (user != null)
        {
            return user;
        }

        if (dbContext.Entry(SecurityConstants.SystemUser).State == EntityState.Detached)
        {
            dbContext.Users.Attach(SecurityConstants.SystemUser);
        }

        user = new User
        {
            AuthContextKey = this.authContext.CurrentUser.AuthContextKey,
            Email = this.authContext.CurrentUser.Email,
            FirstName = this.authContext.CurrentUser.FirstName,
            LastName = this.authContext.CurrentUser.LastName,
            CreatedBy = SecurityConstants.SystemUser,
            CreationDate = DateTime.UtcNow,
            ModifiedBy = SecurityConstants.SystemUser,
            ModificationDate = DateTime.UtcNow
        };

        await dbContext.Users.AddAsync(user);

        return user;
    }
}
