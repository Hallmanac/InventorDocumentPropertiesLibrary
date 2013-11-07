using System;
using System.Collections.Generic;
using System.Linq;
using Inventor;

namespace InventorDocumentProperties
{
    using InventorEvents2011;

    public class InventorDocumentIProperties : IInventorDocumentIProperties 
    {
        #region Fields

        private Document document;
        private PropertySets propertySets;
        private List<PropertySet> propertySetsList;
        private PropertySet summaryInfoPropSet;
        private PropertySet docSummaryInfoPropSet;
        private PropertySet designTrackingPropSet;
        private PropertySet userDefinedPropSet;
        private List<Property> userDefinedPropertiesList;
        private List<Property> summaryInfoPropertiesList;
        private List<Property> docSummaryInfoPropertiesList;
        private List<Property> designTrackingPropertiesList;
        private List<Property> clientPropertiesList;
        private List<Property> allPropertiesList;
        private List<PropertySet> clientPropertySetsList;
        private DocumentEventsLib inventorDocEvents;
        #endregion   
     
        /// <summary>
        /// Gets and sets the Inventor Document object. When it sets the property it also 
        /// re-initializes all the members to handle a new document object.
        /// </summary>
        public Document Document
        {
            get { return this.document; }

            set
            {
                this.document = value;

                if(inventorDocEvents == null)
                {
                    inventorDocEvents = new DocumentEventsLib (value);
                    inventorDocEvents.OnChangDelegate = this.DocumentEvents_OnChange;
                    inventorDocEvents.DocumentEvents.OnChange += inventorDocEvents.OnChangDelegate;
                }
                this.InitializeMembers();
            }
        }

        #region Summary Information Properties

        /// <summary>
        /// Returns the "Title" property from the "Summary Information" property set
        /// </summary>
        public Property Title
        {
            get
            {
                return this.GetInventorProperty(this.summaryInfoPropSet, 2);
            }
        }

        /// <summary>
        /// Returns the "Subject" property from the "Summary Information" property set
        /// </summary>
        public Property Subject
        {
            get
            {
                return this.GetInventorProperty(this.summaryInfoPropSet, 3);
            }
        }

        /// <summary>
        /// Returns the "Author" property from the "Summary Information" property set
        /// </summary>
        public Property Author
        {
            get
            {
                return this.GetInventorProperty(this.summaryInfoPropSet, 4);
            }
        }

        /// <summary>
        /// Returns the "Keywords" property from the "Summary Information" property set
        /// </summary>
        public Property Keywords
        {
            get { return this.GetInventorProperty(this.summaryInfoPropSet, 5); }
        }

        /// <summary>
        /// Returns the "Comments" property from the "Summary Information" property set
        /// </summary>
        public Property Comments
        {
            get { return this.GetInventorProperty(this.summaryInfoPropSet, 6); }
        }

        /// <summary>
        /// Returns the "Last Saved By" property from the "Summary Information" property set
        /// </summary>
        public Property LastSavedBy
        {
            get { return this.GetInventorProperty(this.summaryInfoPropSet, 8); }
        }

        /// <summary>
        /// Returns the "Revision Number" property from the "Summary Information" property set
        /// </summary>
        public Property RevisionNumber
        {
            get { return this.GetInventorProperty(this.summaryInfoPropSet, 9); }
        }

        /// <summary>
        /// Returns the "Thumnail" property from the "Summary Information" property set
        /// </summary>
        public Property Thumbnail
        {
            get { return this.GetInventorProperty(this.summaryInfoPropSet, 17); }
        }
        #endregion

        #region Document Summary Information Properties

        /// <summary>
        /// Returns the "Category" property from the "Document Summary Information" property set
        /// </summary>
        public Property Category
        {
            get { return this.GetInventorProperty(this.docSummaryInfoPropSet, 2); }
        }

        /// <summary>
        /// Returns the "Manager" property from the "Document Summary Information" property set
        /// </summary>
        public Property Manager
        {
            get { return this.GetInventorProperty(this.docSummaryInfoPropSet, 14); }
        }

        /// <summary>
        /// Returns the "Company" property from the "Document Summary Information" property set
        /// </summary>
        public Property Company
        {
            get { return this.GetInventorProperty(this.docSummaryInfoPropSet, 15); }
        }
        #endregion

        #region Design Tracking Properties

        /// <summary>
        /// Returns the "Creation Time" property from the "Design Tracking Properties" property set
        /// </summary>
        public Property CreationTime
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 4); }
        }

        /// <summary>
        /// Returns the "Part Number" property from the "Design Tracking Properties" property set
        /// </summary>
        public Property PartNumber
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 5); }
        }

        /// <summary>
        /// Returns the "Project" property from the "Design Tracking Properties" property set
        /// </summary>
        public Property Project
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 7); }
        }

        /// <summary>
        /// Returns the "Cost Center" property from the "Design Tracking Properties" property set
        /// </summary>
        public Property CostCenter
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 9); }
        }

        /// <summary>
        /// Returns the "Checked By" property from the "Design Tracking Properties" property set
        /// </summary>
        public Property CheckedBy
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 10); }
        }

        /// <summary>
        /// Returns the "Date Checked" property from the "Design Tracking Properties" property set
        /// </summary>
        public Property DateChecked
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 11); }
        }

        /// <summary>
        /// Returns the "Engineer Approved By" property from the "Design Tracking Properties" 
        /// property set
        /// </summary>
        public Property EngineerApprovedBy
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 12); }
        }

        /// <summary>
        /// Returns the "Engineer Date Approved" property from the "Design Tracking Properties" 
        /// property set
        /// </summary>
        public Property EngineerDateApproved
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 13); }
        }

        /// <summary>
        /// Returns the "User Status" property from the "Design Tracking Properties" property set
        /// </summary>
        public Property UserStatus
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 17); }
        }

        /// <summary>
        /// Returns the "Material" property from the "Design Tracking Properties" property set
        /// </summary>
        public Property Material
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 20); }
        }

        /// <summary>
        /// Returns the "Part Property Revision ID" property from the "Design Tracking Properties" 
        /// property set
        /// </summary>
        public Property PartPropertyRevisionID
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 21); }
        }

        /// <summary>
        /// Returns the "Catalog Web Link" property from the "Design Tracking Properties" 
        /// property set
        /// </summary>
        public Property CatalogWebLink
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 23); }
        }

        /// <summary>
        /// Returns the "Part Icon" property from the "Design Tracking Properties" property set
        /// </summary>
        public Property PartIcon
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 28); }
        }

        /// <summary>
        /// Returns the "Description" property from the "Design Tracking Properties" property set
        /// </summary>
        public Property Description
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 29); }
        }

        /// <summary>
        /// Returns the "Vendor" property from the "Design Tracking Properties" property set
        /// </summary>
        public Property Vendor
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 30); }
        }

        /// <summary>
        /// Returns the "Document Sub-Type" property from the "Design Tracking Properties" 
        /// property set
        /// </summary>
        public Property DocumentSubType
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 31); }
        }

        /// <summary>
        /// Returns the "Document Sub-Type Name" property from the "Design Tracking Properties" 
        /// property set
        /// </summary>
        public Property DocumentSubTypeName
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 32); }
        }

        /// <summary>
        /// Returns the "Proxy Refresh Date" property from the "Design Tracking Properties" 
        /// property set
        /// </summary>
        public Property ProxyRefreshDate
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 33); }
        }

        /// <summary>
        /// Returns the "Mfg Approved By" property from the "Design Tracking Properties" 
        /// property set
        /// </summary>
        public Property MfgApprovedBy
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 34); }
        }

        /// <summary>
        /// Returns the "Mfg Date Approved" property from the "Design Tracking Properties" 
        /// property set
        /// </summary>
        public Property MfgDateApproved
        { 
            get { return this.GetInventorProperty(this.designTrackingPropSet, 35); } 
        }

        /// <summary>
        /// Returns the "Cost" property from the "Design Tracking Properties" property set
        /// </summary>
        public Property Cost
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 36); }
        }

        /// <summary>
        /// Returns the "Standard" property from the "Design Tracking Properties" property set
        /// </summary>
        public Property Standard
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 37); }
        }

        /// <summary>
        /// Returns the "Design Status" property from the "Design Tracking Properties" property set
        /// </summary>
        public Property DesignStatus
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 40); }
        }

        /// <summary>
        /// Returns the "Designer" property from the "Design Tracking Properties" property set
        /// </summary>
        public Property Designer
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 41); }
        }

        /// <summary>
        /// Returns the "Engineer" property from the "Design Tracking Properties" property set
        /// </summary>
        public Property Engineer
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 42); }
        }

        /// <summary>
        /// Returns the "Authority" property from the "Design Tracking Properties" property set
        /// </summary>
        public Property Authority
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 43); }
        }

        /// <summary>
        /// Returns the "Parameterized Template" property from the "Design Tracking Properties" 
        /// property set
        /// </summary>
        public Property ParameterizedTemplate
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 44); }
        }

        /// <summary>
        /// Returns the "Template Row" property from the "Design Tracking Properties" property set
        /// </summary>
        public Property TemplateRow
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 45); }
        }

        /// <summary>
        /// Returns the "External Property Revision ID" property from the "Design Tracking 
        /// Properties" property set
        /// </summary>
        public Property ExternalPropertyRevisionID
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 46); }
        }

        /// <summary>
        /// Returns the "Standard Revision" property from the "Design Tracking Properties" property 
        /// set
        /// </summary>
        public Property StandardRevision
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 47); }
        }

        /// <summary>
        /// Returns the "Manufacturer" property from the "Design Tracking Properties" property set
        /// </summary>
        public Property Manufacturer
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 48); }
        }

        /// <summary>
        /// Returns the "Standards Organization" property from the "Design Tracking Properties" 
        /// property set
        /// </summary>
        public Property StandardsOrganization
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 49); }
        }

        /// <summary>
        /// Returns the "Language" property from the "Design Tracking Properties" property set
        /// </summary>
        public Property Language
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 50); }
        }

        /// <summary>
        /// Returns the "Defer Updates" property from the "Design Tracking Properties" property set
        /// </summary>
        public Property DeferUpdates
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 51); }
        }

        /// <summary>
        /// Returns the "Size Designation" property from the "Design Tracking Properties" property 
        /// set
        /// </summary>
        public Property SizeDesignation
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 52); }
        }

        /// <summary>
        /// Returns the "Categories" property from the "Design Tracking Properties" property set
        /// </summary>
        public Property Categories
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 56); }
        }

        /// <summary>
        /// Returns the "Stock Number" property from the "Design Tracking Properties" property set
        /// </summary>
        public Property StockNumber
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 55); }
        }

        /// <summary>
        /// Returns the "Weld Material" property from the "Design Tracking Properties" property set
        /// </summary>
        public Property WeldMaterial
        {
            get { return this.GetInventorProperty(this.designTrackingPropSet, 57); }
        }
        #endregion

        #region Property Sets

        /// <summary>
        /// Returns the Inventor PropertySets object for the Document object passed into the 
        /// constructor
        /// </summary>
        public PropertySets PropertySets
        {
            get { return this.propertySets; }
        }
        
        /// <summary>
        /// Returns the "Summary Information" property set
        /// </summary>
        public PropertySet SummaryInfoPropSet
        {
            get { return this.summaryInfoPropSet; }
        }

        /// <summary>
        /// Returns the "Document Summary Information" property set
        /// </summary>
        public PropertySet DocSummaryInfoPropSet
        {
            get { return this.docSummaryInfoPropSet; }
        }

        /// <summary>
        /// Returns the "Design Tracking" property set
        /// </summary>
        public PropertySet DesignTrackingPropSet
        {
            get { return this.designTrackingPropSet; }
        }

        /// <summary>
        /// Returns the "User Defined" property set
        /// </summary>
        public PropertySet UserDefinedPropSet
        {
            get { return this.userDefinedPropSet; }
        }
        #endregion

        #region Lists

        /// <summary>
        /// Returns a Generic List of all the Property Set collections.
        /// </summary>
        public List<PropertySet> PropertySetsList
        {
            get { return this.propertySetsList; }
        }

        /// <summary>
        /// Returns a Generic List that contains all the properties in the document
        /// </summary>
        public List<Property> AllPropertiesList
        {
            get { return this.allPropertiesList; }
        }

        /// <summary>
        /// Returns a Generic List that contains the properties under the Summary Information
        /// Properties property set.
        /// </summary>
        public List<Property> SummaryInfoPropertiesList
        {
            get { return this.summaryInfoPropertiesList; }
        }

        /// <summary>
        /// Returns a Generic List that contains the properties under the Document Summary 
        /// Information property set.
        /// </summary>
        public List<Property> DocSummaryInfoPropertiesList
        {
            get { return this.docSummaryInfoPropertiesList; }
        }

        /// <summary>
        /// Returns a Generic List that contains the properties under the Design Tracking 
        /// Properties property set.
        /// </summary>
        public List<Property> DesignTrackingPropertiesList
        {
            get { return this.designTrackingPropertiesList; }
        }

        /// <summary>
        /// Returns a Generic List that contains the user defined properties 
        /// (a.k.a. Custom iProperties)
        /// </summary>
        public List<Property> UserDefinedPropertiesList
        {
            get { return this.userDefinedPropertiesList; }
        }

        /// <summary>
        /// Returns a Generic List of all the PropertySet items that were created by third parties
        /// (a.k.a. the "client")
        /// </summary>
        public List<PropertySet> ClientPropertySetsList
        {
            get { return this.clientPropertySetsList; }
        }

        /// <summary>
        /// Returns a Generic List of all the properties that have been added by third parties
        /// </summary>
        public List<Property> ClientPropertiesList
        {
            get { return this.clientPropertiesList; }
        }
        #endregion
        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="document"></param>
        public InventorDocumentIProperties()
        {
            
        }

        #region Methods

        /// <summary>
        /// This checks to see if there is a property that already exists and then either returns
        /// that property (if it's a user custom property) or creates a new user property. Returns
        /// null if the property already exists as an Inventor property.
        /// The type of the "value" parameter implicitly determines the type for the Custom 
        /// iProperty. They are: String, Number, Date, boolean.  
        /// </summary>
        /// <param name="displayName"></param>
        public Property GetUserProperty(string displayName)
        {
            if (this.IsUserProperty(displayName))
            {
                var existingUserProp = this.userDefinedPropertiesList.Find
                    (up => up.DisplayName.Equals(displayName));
                return existingUserProp;
            }
            return null;
        }

        /// <summary>
        /// Overloaded || This overload will simply add a new user property to the user defined
        /// property set. If one exists, the method simply returns
        /// </summary>
        /// <param name="displayName"></param>
        /// <param name="value"></param>
        public void AddUserProperty(string displayName, object value = null)
        {
            if (this.IsUserProperty(displayName)) return;
            if (this.IsInventorProperty(displayName) || this.IsClientProperty(displayName)) return;
            var newUserProperty = this.userDefinedPropSet.Add(value, displayName);
            userDefinedPropertiesList.Add(newUserProperty);
            allPropertiesList.Add(newUserProperty);
        }

        /// <summary>
        /// Determines if there is already a user property that exists with the same name.
        /// </summary>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public Boolean IsUserProperty(string displayName)
        {
            var existingDocProp = this.allPropertiesList.Find
                (docProp => docProp.DisplayName.Equals(displayName));

            if (existingDocProp != null)
            {
                var existingUserProp = this.userDefinedPropertiesList.Find
                (userProp => userProp.DisplayName.Equals(displayName));

                return existingUserProp != null;
            }
            return false;   
        }

        /// <summary>
        /// Attempts to get an existing PropertySet equal to the "displayName" argument passed in.
        /// If one doesn't exist (or match) then a new property set is created and returned. 
        /// </summary>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public PropertySet GetClientPropertySet(string displayName)
        {
            if (this.IsClientPropertySet(displayName))
            {
                var existingClientPropSet = this.clientPropertySetsList.Find
                (pSet => pSet.DisplayName.Equals(displayName));

                var clientPropSet = existingClientPropSet;
                return clientPropSet;
            }
            return null;
        }

        /// <summary>
        /// Adds a new client PropertySet to the PropertySets collection. If a client property set
        /// of the same name exists, the method returns.
        /// </summary>
        /// <param name="displayName"></param>
        public void AddClientPropertySet(string displayName)
        {
            if (IsClientPropertySet(displayName)) return;
            var newPropSet = PropertySets.Add(displayName);
            propertySetsList.Add(newPropSet);
            clientPropertySetsList.Add(newPropSet);
        }

        /// <summary>
        /// Determines if a Client Property set with the same display name already exists
        /// </summary>
        /// <param name="clientPropSetDispName"></param>
        /// <returns></returns>
        public bool IsClientPropertySet(string clientPropSetDispName)
        {
            var existingPropSet = this.clientPropertySetsList.Find
                (pSet => pSet.DisplayName.Equals(clientPropSetDispName));

            return existingPropSet != null;
        }

        /// <summary>
        /// Adds or Gets a Client Property (Inventor Property added by a third party).
        /// </summary>
        /// <param name="clientPropSetDispName"></param>
        /// <param name="clientPropDispName"></param>
        /// <returns></returns>
        public Property GetClientProperty(string clientPropSetDispName, string clientPropDispName)
        {
            if(IsClientProperty(clientPropDispName))
            {
                var existingClientProperty = this.allPropertiesList.Find
                    (exCProp => exCProp.DisplayName.Equals(clientPropDispName));
                var clientProperty = existingClientProperty;
                return clientProperty;
            }
            return null;
        }

        /// <summary>
        /// Overloaded method to simply add a client property. If one exists the method returns.
        /// </summary>
        /// <param name="clientPropSetDispName"></param>
        /// <param name="clientPropDispName"></param>
        /// <param name="clientPropertyValue"></param>
        public void AddClientProperty(string clientPropSetDispName, string clientPropDispName, 
            object clientPropertyValue = null)
        {
            if (IsClientProperty(clientPropDispName)) return;
            if (this.IsInventorProperty(clientPropDispName)) return;
            var tempClientPropSet = GetClientPropertySet(clientPropSetDispName);

            var newClientProp = tempClientPropSet.Add(clientPropertyValue,
                                                           clientPropDispName);
            allPropertiesList.Add(newClientProp);
            clientPropertiesList.Add(newClientProp);
        }

        /// <summary>
        /// Determines if the Client property exists
        /// </summary>
        /// 
        /// <param name="displayName"></param>
        /// <returns></returns>
        public Boolean IsClientProperty(string displayName)
        {
            if (!this.IsInventorProperty(displayName))
            {
                var existingClientProperty = this.clientPropertiesList.Find
                    (exProp => exProp.DisplayName.Equals(displayName));

                    return existingClientProperty != null;
            }
            return false;
        }

        /// <summary>
        /// Determines if the property with the submitted Display Name is an Inventor Property.
        /// For example, a property that is under one of the Inventor Property Sets.
        /// </summary>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public Boolean IsInventorProperty(string displayName)
        {
            var invPropsList = new List<Property>
                                   {
                                       this.summaryInfoPropertiesList.Find
                                           (p => p.DisplayName.Equals(displayName)),
                                       this.docSummaryInfoPropertiesList.Find
                                           (p => p.DisplayName.Equals(displayName)),
                                       this.designTrackingPropertiesList.Find
                                           (p => p.DisplayName.Equals(displayName)),
                                       this.userDefinedPropertiesList.Find
                                           (p => p.DisplayName.Equals(displayName))
                                   };

            return invPropsList.Count > 0;
        }

        private Property GetInventorProperty(PropertySet propSet, int propID)
        {
            var propHolder =
                (from property in this.allPropertiesList
                where property.Parent.Equals(propSet) && property.PropId.Equals(propID)
                select property).Single<Property>();

            var retrievedProperty = propHolder;

            return retrievedProperty;
        }

        private void InitializeMembers()
        {
            this.propertySets = document.PropertySets;
            this.allPropertiesList = new List<Property>();
            this.propertySetsList = new List<PropertySet>();
            this.userDefinedPropertiesList = new List<Property>();
            this.summaryInfoPropertiesList = new List<Property>();
            this.docSummaryInfoPropertiesList = new List<Property>();
            this.designTrackingPropertiesList = new List<Property>();
            this.clientPropertySetsList = new List<PropertySet>();
            this.clientPropertiesList = new List<Property>();

            foreach(PropertySet propSet in this.propertySets)
            {
                foreach(Inventor.Property property in propSet)
                {
                    this.allPropertiesList.Add(property);
                }

                string propertySetInternalName = propSet.InternalName;

                switch(propertySetInternalName)
                {
                    case "{F29F85E0-4FF9-1068-AB91-08002B27B3D9}":
                        this.summaryInfoPropSet = propSet;
                        foreach(Property summInfoProp in propSet)
                        {
                            this.summaryInfoPropertiesList.Add(summInfoProp);
                        }
                        break;
                    case "{D5CDD502-2E9C-101B-9397-08002B2CF9AE}":
                        this.docSummaryInfoPropSet = propSet;
                        foreach(Property docSummInfoProp in propSet)
                        {
                            this.docSummaryInfoPropertiesList.Add(docSummInfoProp);
                        }
                        break;
                    case "{32853F0F-3444-11D1-9E93-0060B03C1CA6}":
                        this.designTrackingPropSet = propSet;
                        foreach(Property designTrkngProp in propSet)
                        {
                            this.designTrackingPropertiesList.Add(designTrkngProp);
                        }
                        break;
                    case "{D5CDD505-2E9C-101B-9397-08002B2CF9AE}":
                        this.userDefinedPropSet = propSet;
                        foreach(Property userProp in propSet)
                        {
                            this.userDefinedPropertiesList.Add(userProp);
                        }
                        break;
                    default:
                        this.clientPropertySetsList.Add(propSet);
                        foreach(Property clientProp in propSet)
                        {
                            this.clientPropertiesList.Add(clientProp);
                        }
                        break;
                }

                propertySetsList.Add(propSet);
            }
        }

        private void DocumentEvents_OnChange(CommandTypesEnum ReasonsForChange, 
            EventTimingEnum BeforeOrAfter, NameValueMap Context, out HandlingCodeEnum HandlingCode)
        {
            if(ReasonsForChange == CommandTypesEnum.kFilePropertyEditCmdType)
            {
                InitializeMembers();
            }
            HandlingCode = HandlingCodeEnum.kEventHandled;
        }
        #endregion
    }
}
