InventorDocumentPropertiesLibrary
=================================

Library which makes working with the Autodesk Inventor iProperties API much easier.

This provides a wrapper around interacting with the Autodesk Inventor "iProperties" which are essentially data attributes (or properties, as it were) that holds various meta-data about an Inventor Document object.

This library references another library that I wrote called InventorEvents2011.dll which is in my other Github repo named Adsk-Inv-Evts-Wrapper. If you're missing a reference check that library and download it if neccessary. 

Also, you will have to bring in your own reference to the Autodesk.Inventor.Interop assembly since it's outside the allowances of the licensing to redistribute that assembly.
