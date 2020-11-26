using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace GuestBookSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_AuthorizeRequest(object sender, System.EventArgs e)
        {
            HttpApplication App = (HttpApplication)sender;
            HttpContext Ctx = App.Context; //��ȡ����Http������ص�HttpContext����
            if (Ctx.Request.IsAuthenticated == true) //��֤�����û��Ž���role�Ĵ���
            {
                FormsIdentity Id = (FormsIdentity)Ctx.User.Identity;
                FormsAuthenticationTicket Ticket = Id.Ticket; //ȡ�������֤Ʊ
                string[] Roles = Ticket.UserData.Split(','); //�������֤Ʊ�е�role����ת���ַ�������
                Ctx.User = new GenericPrincipal(Id, Roles); //��ԭ�е�Identity���Ͻ�ɫ��Ϣ�½�һ��GenericPrincipal��ʾ��ǰ�û�,������ǰ�û���ӵ����role��Ϣ
            }
        }
    }
}
