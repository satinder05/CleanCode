using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;
using System;

namespace API.RoutingConstraint
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class QueryStringConstraintAttribute : ActionMethodSelectorAttribute
    {
        private readonly string _valueName;
        private readonly bool _valuePresent;

        public QueryStringConstraintAttribute(string valueName, bool valuePresent)
        {
            _valueName = valueName;
            _valuePresent = valuePresent;
        }

        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            var value = routeContext.HttpContext.Request.Query[_valueName];
            if(_valuePresent)
            {
                return !string.IsNullOrEmpty(value);
            }

            return string.IsNullOrEmpty(value);
        }
    }
}
