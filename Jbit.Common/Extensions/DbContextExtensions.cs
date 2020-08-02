using Jbit.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Jbit.Common.Extensions
{
    public static class DbContextExtensions
    {
        //public static IQueryable<Team> IncludeRelations(this DbSet<Team> query)
        //{
        //    return query.Include(t => t.Pers)
        //}

        public static IQueryable<T> IncludeAllRelations<T>(this DbSet<T> query) where T : class
        {
            switch (T.ToString())
            {
                case "PersonTask" :
                    return ((DbSet<JbitTask>) query).IncludeRelations();

            }
        }


        public static IQueryable<JbitTask> IncludeRelations(this DbSet<JbitTask> query)
        {
            return query.Include(t => t.Values);
        }

        public static IQueryable<Person> IncludeRelations(this DbSet<Person> query)
        {
            return query.Include(t => t.TaskLinks);
        }

        public static IQueryable<Competition> IncludeRelations(this DbSet<Competition> query)
        {
            return query.Include(t => t.PersonLinks);
        }

    }
}
