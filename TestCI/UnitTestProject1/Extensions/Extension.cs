using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCI.Database;
using System.Data.Entity;
using System.IO;

namespace UnitTestProject1.Extensions
{
    public static class DbSetExtensions                     
    {
        
            public static DbSet<T> GetQueryableMockDbSet<T>(this IEnumerable<T> sourceList) where T : class
            {
                var queryable = sourceList.AsQueryable();

                var dbSet = new Mock<DbSet<T>>();
                dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
                dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
                dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
                dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

                return dbSet.Object;
            }
        public static Stream ToStream(this string str)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(str);
            //byte[] byteArray = Encoding.ASCII.GetBytes(str);
            return new MemoryStream(byteArray);
        }

    }
}
