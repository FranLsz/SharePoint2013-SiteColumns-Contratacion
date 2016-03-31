using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;

namespace SpContratacion.Features.ContratacionFeature
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("644a6db0-b3e4-440c-88bf-c9df79368d24")]
    public class ContratacionFeatureEventReceiver : SPFeatureReceiver
    {
        public static readonly SPContentTypeId Ctid = new SPContentTypeId("0x010100C3316E15A95F420F8187FBBE1B9636F9");

        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {

            var site = properties.Feature.Parent as SPSite;
            var web = site.RootWeb;
            SPContentType contratacionCt = web.ContentTypes[Ctid];

            if (contratacionCt == null)
            {
                contratacionCt = new SPContentType(Ctid, web.ContentTypes, "Contratacion");
                web.ContentTypes.Add(contratacionCt);
            }

            contratacionCt.Description = "Un nuevo acuerdo de contratación";
            contratacionCt.Group = "MiApp Content Types";

            //
            SPField fldNombre = web.AvailableFields["Full Name"];
            SPFieldLink fldLinkFullName = new SPFieldLink(fldNombre);

            if (contratacionCt.FieldLinks[fldLinkFullName.Id] == null)
                contratacionCt.FieldLinks.Add(fldLinkFullName);

            //
            SPField fldManager = web.AvailableFields["Manager"];
            SPFieldLink fldLinkManager = new SPFieldLink(fldManager);

            if (contratacionCt.FieldLinks[fldLinkManager.Id] == null)
                contratacionCt.FieldLinks.Add(fldLinkManager);

            //
            SPField fldEquipo = web.AvailableFields["Equipo"];
            SPFieldLink fldLinkEquipo = new SPFieldLink(fldEquipo);

            if (contratacionCt.FieldLinks[fldLinkEquipo.Id] == null)
                contratacionCt.FieldLinks.Add(fldLinkEquipo);

            //
            SPField fldInicio = web.AvailableFields["Inicio"];
            SPFieldLink fldLinkInicio = new SPFieldLink(fldInicio);

            if (contratacionCt.FieldLinks[fldLinkInicio.Id] == null)
                contratacionCt.FieldLinks.Add(fldLinkInicio);

            //
            SPField fldFin = web.AvailableFields["Fin"];
            SPFieldLink fldLinkFin = new SPFieldLink(fldFin);

            if (contratacionCt.FieldLinks[fldLinkFin.Id] == null)
                contratacionCt.FieldLinks.Add(fldLinkFin);

            //
            SPField fldAprobado = web.AvailableFields["Aprobado"];
            SPFieldLink fldLinkAprobado = new SPFieldLink(fldAprobado);

            if (contratacionCt.FieldLinks[fldLinkAprobado.Id] == null)
                contratacionCt.FieldLinks.Add(fldLinkAprobado);

            contratacionCt.Update();


        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var site = properties.Feature.Parent as SPSite;
            var web = site.RootWeb;
            SPContentType contratacionCt = web.ContentTypes[Ctid];

            if (contratacionCt != null)
            {
                web.ContentTypes.Delete(Ctid);
            }
        }


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
