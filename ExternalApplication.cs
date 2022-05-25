using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using System.Reflection;

namespace displayprob
{
    class ExternalApplication : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            //Create Ribbon Tab
            application.CreateRibbonTab("My Commands");

            string path = Assembly.GetExecutingAssembly().Location;
            PushButtonData button = new PushButtonData("show ID", "Your Element", path, "displayprob.DisplayMessage");

            RibbonPanel panel = application.CreateRibbonPanel("enteer your element", "element");

            panel.AddItem(button);

            return Result.Succeeded;
        }
    }
}
