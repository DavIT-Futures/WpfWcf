using System;
using System.Linq.Expressions;

namespace TestApp.Util
{
    public static class Extension
    {
        /// <summary>
        /// Gets name from the property expression
        /// </summary>
        /// <typeparam name="T">Class type - no need to provide any more (see example)</typeparam>
        /// <param name="propertyPointer">Property expression, for example (() => CallTypeRestrictionId)</param>
        /// <returns></returns>
        public static string GetPropertyName<T>(this Expression<Func<T>> propertyPointer)
        {
            if (propertyPointer == null)
                throw new ArgumentNullException("propertyPointer");

            var expression = propertyPointer.Body as MemberExpression;
            if (expression == null)
            {
                var unaryExpression = propertyPointer.Body as UnaryExpression;
                if (unaryExpression != null)
                    expression = unaryExpression.Operand as MemberExpression;
            }

            if (expression == null)
                throw new ArgumentException("Unsupported property type");

            return expression.Member.Name;
        }
    }
}
