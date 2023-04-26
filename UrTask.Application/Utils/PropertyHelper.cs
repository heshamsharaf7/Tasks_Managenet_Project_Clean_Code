using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace UrTask.Application.Utils
{
    public static class PropertyHelper
    {
        public static string GetPropertyName<T, TProperty>(Expression<Func<T, TProperty>> property)
        {
            PropertyInfo propertyInfo = null;
            var body = property.Body;

            if (body is MemberExpression)
            {
                propertyInfo = (body as MemberExpression).Member as PropertyInfo;
            }
            else if (body is UnaryExpression)
            {
                propertyInfo = ((MemberExpression)((UnaryExpression)body).Operand).Member as PropertyInfo;
            }

            if (propertyInfo == null)
            {
                throw new ArgumentException("The lambda expression 'property' should point to a valid Property");
            }

            var propertyName = propertyInfo.Name;

            return propertyName;
        }

        public static string GetPropertyName<T>(Expression<Func<T, object>> property)
        {
            PropertyInfo propertyInfo = null;
            var body = property.Body;

            if (body is MemberExpression)
            {
                propertyInfo = (body as MemberExpression).Member as PropertyInfo;
            }
            else if (body is UnaryExpression)
            {
                propertyInfo = ((MemberExpression)((UnaryExpression)body).Operand).Member as PropertyInfo;
            }

            if (propertyInfo == null)
            {
                throw new ArgumentException("The lambda expression 'property' should point to a valid Property");
            }

            var propertyName = propertyInfo.Name;

            return propertyName;
        }
    }
}
