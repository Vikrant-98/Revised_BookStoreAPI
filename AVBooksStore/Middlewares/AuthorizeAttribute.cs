using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Poppins.POS.Api.Resources.Middlewares.CustomJWTMiddleware
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //skip authorization if action is decorated with [AllowAnonymous] attribute
            //if (context.HttpContext.Response.StatusCode != StatusCodes.Status200OK)
            //{
            //    SetUnauthorizedResponse(context, "");
            //    return;
            //}
            //if (context.HttpContext.Request.Headers[Common.ProgramCode].FirstOrDefault() == null && context.HttpContext.Request.Headers[Common.TenantID].FirstOrDefault() == null && context.HttpContext.Request.Headers[Common.TenantCode].FirstOrDefault() == null)
            //{
            //    SetUnauthorizedResponse(context, StatusManager.SecurityTokenVerificationFailed);
            //}

        }

        //private void SetUnauthorizedResponse(AuthorizationFilterContext context, string errorCode)
        //{
        //    var response = new BaseResponse
        //    {
        //        ReturnCode = StatusManager.GetExternalCode(errorCode),
        //        ReturnMessage = StatusManager.GetExternalMessage(errorCode)
        //    };

        //    var acceptHeader = context.HttpContext.Request.Headers["Accept"];
        //    if (acceptHeader.Contains("application/xml"))
        //    {
        //        context.Result = new ContentResult
        //        {
        //            Content = ConvertToXml(response),
        //            ContentType = "application/xml",
        //            StatusCode = StatusCodes.Status401Unauthorized
        //        };
        //    }
        //    else
        //    {
        //        context.Result = new JsonResult(response)
        //        {
        //            StatusCode = StatusCodes.Status401Unauthorized
        //        };
        //    }
        //}

        //private string ConvertToXml(object obj)
        //{
        //    XmlSerializer serializer = new XmlSerializer(obj.GetType());
        //    XmlWriterSettings settings = new XmlWriterSettings
        //    {
        //        OmitXmlDeclaration = true,
        //        Indent = true,
        //        Encoding = Encoding.UTF8
        //    };

        //    using (MemoryStream memoryStream = new MemoryStream())
        //    using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream, settings))
        //    {
        //        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        //        namespaces.Add("", ""); // This line removes the default namespaces

        //        serializer.Serialize(xmlWriter, obj, namespaces);
        //        return Encoding.UTF8.GetString(memoryStream.ToArray());
        //    }
        //}

        [AttributeUsage(AttributeTargets.Method)]
        public class AllowAnonymousAttribute : Attribute
        { }
    }
}
