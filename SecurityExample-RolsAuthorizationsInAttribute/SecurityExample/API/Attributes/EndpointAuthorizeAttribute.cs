using Microsoft.AspNetCore.Mvc.Controllers;

namespace API.Attributes
{
    public class EndpointAuthorizeAttribute : Attribute
    {
        public EndpointAuthorizeAttribute()
        {
            Values = new EndpointAuthorizeAttributeValues();
        }
        public EndpointAuthorizeAttribute(HttpContext context)
        {
            Values = new EndpointAuthorizeAttributeValues();
            SetValuesFromContext(context);
        }

        public bool AllowsAnonymous;
        public string AllowedUserRols;
        public EndpointAuthorizeAttributeValues Values { get;}

        public void SetValuesFromContext(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            var actionDescriptor = endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();
            var authorizeAttribute = actionDescriptor.MethodInfo.CustomAttributes.Where(a => a.AttributeType == typeof(EndpointAuthorizeAttribute)).First();
            var authorizedRols = authorizeAttribute.NamedArguments.Where(a => a.MemberName == "AllowedUserRols").FirstOrDefault().TypedValue.Value;
            var authorizedAnonymous = authorizeAttribute.NamedArguments.Where(a => a.MemberName == "AllowsAnonymous").FirstOrDefault().TypedValue.Value;

            try
            {
                if (authorizedRols != null)
                {
                    Values.AllowedUserRols = authorizedRols.ToString().Replace(" ", "").Split(",").ToList();
                }
                else
                {
                    Values.AllowedUserRols = new List<string>();
                }
                if ((authorizedAnonymous != null && (bool)authorizedAnonymous))
                {
                    Values.AllowsAnonymous = true;
                }
                else
                {
                    Values.AllowsAnonymous = false;
                }
            }
            catch
            {
                throw new InvalidCastException();
            }
        }
    }

    public class EndpointAuthorizeAttributeValues
    {
        public EndpointAuthorizeAttributeValues()
        {
            AllowedUserRols = new List<string>();
            AllowsAnonymous = false;
        }
        public bool AllowsAnonymous { get; set; }
        public List<string> AllowedUserRols { get; set; }
    }
}
