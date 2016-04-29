using System.Web.Mvc;
using FS.Log;

namespace FsGit
{
    public class HandleErrorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var exp = filterContext.Exception;
            if (exp != null)
            {
                // 使用框架的日志记录
                LogManger.Log.Error(exp);
            }
        }
    }

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}