using Microsoft.AspNetCore.Mvc;
using SmartStoreInventoryManagement.Core.Enums;
using SmartStoreInventoryManagement.Core.Security;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace SmartStoreInventoryManagement.Core.AspNetCore
{
    public class BaseMvcController : Controller
    {
        protected UserPrincipal CurrentUser
        {
            get
            {
                return new UserPrincipal(User as ClaimsPrincipal);
            }
        }
        protected virtual void SuccessNotification(string message, bool persistForTheNextRequest = true)
        {
            //AddNotification(NotifyType.Success, message, persistForTheNextRequest);
        }

        protected virtual void ErrorNotification(string message, bool persistForTheNextRequest = true)
        {
            //AddNotification(NotifyType.Error, message, persistForTheNextRequest);
        }
        //protected virtual void AddNotification(NotifyType type, string message, bool persistForTheNextRequest)
        //{
        //    string dataKey = string.Format("nop.notifications.{0}", type);
        //    if (persistForTheNextRequest)
        //    {
        //        if (TempData[dataKey] == null)
        //            TempData[dataKey] = new List<string>();
        //        ((List<string>)TempData[dataKey]).Add(message);
        //    }
        //    else
        //    {
        //        if (ViewData[dataKey] == null)
        //            ViewData[dataKey] = new List<string>();
        //        ((List<string>)ViewData[dataKey]).Add(message);
        //    }
        //}
    }
}
