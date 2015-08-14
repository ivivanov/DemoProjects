using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTrees
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime JoiningDate { get; set; }

        public override string ToString()
        {
            return String.Format("Name: {0}, Age: {1}, Joining: {2}", Name, Age, JoiningDate);
        }
    }

    public class PersonCollection
    {
        public List<Person> People { get; set; }

        public PersonCollection()
        {
            this.People = new List<Person>();
            Person p1 = new Person { Name = "Kayes", Age = 29, JoiningDate = DateTime.Parse("2010-06-06") };
            Person p2 = new Person { Name = "Gibbs", Age = 34, JoiningDate = DateTime.Parse("2008-04-23") };
            Person p3 = new Person { Name = "Steyn", Age = 28, JoiningDate = DateTime.Parse("2011-02-17") };

            People.Add(p1);
            People.Add(p2);
            People.Add(p3);
        }

        public void SortByPropName(string sortByPropName)
        {
            Type sortByPropType = typeof(Person).GetProperty(sortByPropName).PropertyType;
            ParameterExpression personParam = Expression.Parameter(typeof(Person), "p");
            //var sortExpression = Expression.Lambda<Func<Person, int>>(Expression.Property(personParam, sortByPropName), personParam);
            LambdaExpression sortExpression = Expression.Lambda(Expression.Property(personParam, sortByPropName), personParam);
            IQueryable<Person> peopleQery = this.People.AsQueryable<Person>();

            MethodInfo orderByMethodInfo = typeof(Queryable).GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Single(mi => mi.Name == "OrderBy" && mi.IsGenericMethodDefinition
                    && mi.GetGenericArguments().Length == 2
                    && mi.GetParameters().Length == 2);

            this.People = (orderByMethodInfo.MakeGenericMethod(new Type[] { typeof(Person), sortByPropType })
                            .Invoke(peopleQery, new object[] { peopleQery, sortExpression }) as IOrderedQueryable<Person>)
                            .ToList();
        }


        public void SortByPropAge(string sortByPropName, int ageFilterGreaterThan = -1)
        {
            //var gtExpression = Expression.Lambda(gt, personParam);
            //IQueryable<Person> peopleQery = this.People.AsQueryable<Person>();
            //this.People = peopleQery.Where<Person>(ExpressionsUtil.AgeGT).ToList();//.OrderBy<Person, int>(ageSelector);
            //LambdaExpression sortExpression = Expression.Lambda()

            /* build our parameters */
             var pX = Expression.Parameter(typeof(double?));
            var personParam = Expression.Parameter(typeof(Person), "p");
            var ageProp = Expression.Property(personParam, "Age");
            var ageSelector = Expression.Lambda(ageProp, personParam);
            //Expression<Func<int
            ///* build the body */
            //var body = Expression.Condition(
            //    /* condition */
            //    Expression.Property(pX, "HasValue"),
            //    /* if-true */
            //    Expression.Call(typeof(BitConverter),
            //                    "GetBytes",
            //                    null, /* no generic type arguments */
            //                    Expression.Member(pX, "Value")),
            //    /* if-false */
            //    Expression.Constant(new byte[] { 0xFF })
            //);

            var exprBody = Expression.GreaterThan(ageProp, Expression.Constant(ageFilterGreaterThan));
            /* build the method */
            var exprAgeFilter = Expression.Lambda<Func<Person, bool>>(exprBody, personParam);
            var exprOrderByProp = Expression.Lambda<Func<Person,int>>(Expression.Property(personParam, sortByPropName), personParam);
            //var lambda = Expression.Lambda<Func<double?, byte[]>>(body, pX);
            //Func<double?, byte[]> compiled = lambda.Compile();

            
            IQueryable<Person> peopleQery = this.People.AsQueryable<Person>();
            this.People = peopleQery.Where(exprAgeFilter).OrderByDescending(exprOrderByProp).ToList();
        }

        public void SortByPropAgeWithGenericOrderBy(string propname)
        {
            IQueryable<Person> peopleQery = this.People.AsQueryable<Person>();
            this.People = peopleQery.OrderBy<Person>(propname, true).ToList();
        }
    }
}
