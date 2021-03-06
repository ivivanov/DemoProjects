﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonCollection people = new PersonCollection();
            // read prop name to sort by
            //string propName = Console.ReadLine();
            //people.SortByPropName(propName);
            people.SortByPropAge("Age", 28);
            foreach (var item in people.People)
            {
                Console.WriteLine(item.ToString());
            }
            Console.Read();
        }

        ///<summary>
        ///call in main
        ///Console.WriteLine(TypeResutFormatter(ExpressionsUtil.ConcatWithSpace, "Ivan", "Ivanov"));
        ///Console.WriteLine(TypeResutFormatter(ExpressionsUtil.SumIntInDouble, 3, 8));
        ///</summary>
        public static string TypeResutFormatter<A, B, R>(Func<A, B, R> func, A a, B b)
        {
            R funcRes = func.Invoke(a, b);

            if (typeof(R) == typeof(string))
            {
                return String.Format("String: {0}", funcRes.ToString());
            }

            if (typeof(R) == typeof(double))
            {

                double res = (double)Convert.ChangeType(funcRes, typeof(R));
                res += 0.0001d;
                return String.Format("Double: {0:00.00}", res);
            }

            return funcRes.ToString();
        }
    }



    public static class ExpressionsUtil
    {
        public static Func<Person, int, bool> AgeGT = (a, b) => a.Age > 30;

        public static Func<string, string, string> ConcatWithSpace = (a, b) => a + ' ' + b;

        public static Func<int, int, double> SumIntInDouble = (a, b) => a + b;

        //Just a simple lambda expression
        public static Func<int, int, bool> LessThanCompare = (a, b) => a < b;

        private static Expression<Func<int, int, int>> Plus = (a, b) => a + b;

        // Lambda expression as data in the form of an expression tree.
        public static Expression<Func<int, int, bool>> lessThan = (a, b) => a < b;

        public static Func<int, int, bool> LessThan
        {
            get
            {
                // Compile the expression tree into executable code.
                return lessThan.Compile();
            }
        }
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string orderByProperty, bool desc)
        {
            string command = desc ? "OrderByDescending" : "OrderBy";
            var type = typeof(TEntity);
            var property = type.GetProperty(orderByProperty);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
                                          source.Expression, Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<TEntity>(resultExpression);
        }
    }
}
