﻿using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AwesomeToDo.Core.Exceptions;
using AwesomeToDo.Domain.Data.Abstract;
using AwesomeToDo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AwesomeToDo.Domain.Extensions
{
    public static class DbSetExtensions
    {
        public static async Task<T> FindAndEnsureExistAsync<T>(this DbSet<T> set, Guid id, ErrorCode errorCode) where T : Entity
        {
            var result = await set.FindAsync(id);
            if (result == null)
            {
                throw new AwesomeToDoException(errorCode);
            }

            return result;
        }

        public static async Task EnsureUserNotExistAsync(this DbSet<User> set, string email)
        {
            var user = await set.SingleOrDefaultAsync(u => u.Email == email);
            if (user != null)
            {
                throw new AwesomeToDoException(ErrorCode.UserWithGivenEmailExist);
            }
        }

        public static async Task<T> FindAndEnsureSingleAsync<T>(this DbSet<T> set, Expression<Func<T, bool>> action, ErrorCode code) where T : Entity
        {
            var result = await set.SingleOrDefaultAsync(action);
            if (result == null)
            {
                throw new AwesomeToDoException(code);
            }

            return result;
        }
    }
}
