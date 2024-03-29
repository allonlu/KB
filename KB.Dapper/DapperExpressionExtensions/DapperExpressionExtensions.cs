﻿using Comm100.Domain.Entity;
using DapperExtensions;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace KB.Dapper.DapperExpressionExtensions
{
    internal static class DapperExpressionExtensions
    {
        [NotNull]
        public static IPredicate ToPredicateGroup<TEntity>([NotNull] this Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity
        {
     
            var dev = new DapperExpressionVisitor<TEntity>();
            IPredicate pg = dev.Process(expression);

            return pg;
        }
    }
}
