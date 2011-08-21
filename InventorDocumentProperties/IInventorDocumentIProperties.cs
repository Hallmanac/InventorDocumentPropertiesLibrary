using System.Collections.Generic;
using Inventor;

namespace InventorDocumentProperties
{
    public interface IInventorDocumentIProperties
    {
        void AddUserProperty(string displayName, object propertyValue = null);
        Property GetUserProperty(string displayName);

        void AddClientPropertySet(string displayName);
        PropertySet GetClientPropertySet(string displayName);

        void AddClientProperty(string clientPropertySetDisplayName, string clientPropertyDisplayName,
                               object clientPropertyValue = null);
        Property GetClientProperty(string clientPropertySetDisplayName, string clientPropertyDisplayName);

        bool IsClientProperty(string displayName);
        bool IsClientPropertySet(string clientPropSetDispName);
        bool IsInventorProperty(string displayName);
        bool IsUserProperty(string displayName);

        List<Property> AllPropertiesList { get; }
        Property Author { get; }
        Property Authority { get; }
        Property CatalogWebLink { get; }
        Property Categories { get; }
        Property Category { get; }
        Property CheckedBy { get; }
        List<Property> ClientPropertiesList { get; }
        List<PropertySet> ClientPropertySetsList { get; }
        Property Comments { get; }
        Property Company { get; }
        Property Cost { get; }
        Property CostCenter { get; }
        Property CreationTime { get; }
        Property DateChecked { get; }
        Property DeferUpdates { get; }
        Property Description { get; }
        Property Designer { get; }
        Property DesignStatus { get; }
        List<Property> DesignTrackingPropertiesList { get; }
        PropertySet DesignTrackingPropSet { get; }
        List<Property> DocSummaryInfoPropertiesList { get; }
        PropertySet DocSummaryInfoPropSet { get; }
        Document Document { get; set; }
        Property DocumentSubType { get; }
        Property DocumentSubTypeName { get; }
        Property Engineer { get; }
        Property EngineerApprovedBy { get; }
        Property EngineerDateApproved { get; }
        Property ExternalPropertyRevisionID { get; }
        Property Keywords { get; }
        Property Language { get; }
        Property LastSavedBy { get; }
        Property Manager { get; }
        Property Manufacturer { get; }
        Property Material { get; }
        Property MfgApprovedBy { get; }
        Property MfgDateApproved { get; }
        Property ParameterizedTemplate { get; }
        Property PartIcon { get; }
        Property PartNumber { get; }
        Property PartPropertyRevisionID { get; }
        Property Project { get; }
        PropertySets PropertySets { get; }
        List<PropertySet> PropertySetsList { get; }
        Property ProxyRefreshDate { get; }
        Property RevisionNumber { get; }
        Property SizeDesignation { get; }
        Property Standard { get; }
        Property StandardRevision { get; }
        Property StandardsOrganization { get; }
        Property StockNumber { get; }
        Property Subject { get; }
        List<Property> SummaryInfoPropertiesList { get; }
        PropertySet SummaryInfoPropSet { get; }
        Property TemplateRow { get; }
        Property Thumbnail { get; }
        Property Title { get; }
        List<Property> UserDefinedPropertiesList { get; }
        PropertySet UserDefinedPropSet { get; }
        Property UserStatus { get; }
        Property Vendor { get; }
        Property WeldMaterial { get; }
    }
}
