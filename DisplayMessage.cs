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
    [TransactionAttribute(TransactionMode.ReadOnly)]
    public class DisplayMessage : IExternalCommand
    {

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                //get UIdoc
                UIDocument uidoc = commandData.Application.ActiveUIDocument;
                //pickobj
                Reference pickObj = uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element);

                //show obj
                if (pickObj != null)
                {
                    TaskDialog.Show("Element Id", pickObj.ElementId.ToString());
                }
                return Result.Succeeded;
            }
            catch
            {
                return Result.Failed;
            }
        }
    }
}
