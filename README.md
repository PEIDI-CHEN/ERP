# ERP
The project is based on the Winform, and I tried to change that into a MVVM patern, 
but this project is too huge and I need to seek an intern as well as focus on my study in school, so I gave up.
sooooooooooooooooooooooooo sry.
Extensions used in the project:
1. The Print Fuction in the project uses the RMReport extionsion
2. The Capture Function uses the Aforge.NET
3. The skin of the user interface uses the SkeinforgeEngine
4. The form uses the Devexpress

System folder description:
1. Data (database file)
2. BaseClass (system base class storage area)
3. Common (system template class storage area)
4. CommonData (system general window and class inventory area)
5. DataLib (Data Manipulation Repository)
6. Base (System Basic Data Storage Area)
7. myControl (homemade control storage area)
8. Stock (Purchasing Management Document Depository)
9. Sell (Sales Management File Repository)
10. Storage (Warehouse Management File Storage Area)
11. Product (Production Management File Storage Area)
12. OutProduct (Outsourced Processing File Storage Area)
13. Sys (System File Repository)
14. UserReport
15. Account
16. JXC (System Master File Outlet)
17. Custom Printing (3.67) (delphi Report Design Component)

The following are the various library windows and class explanations:
1) BaseClass (the most basic class of the system, all forms are inherited by this class)
1. frmBase (all form base classes)
2. frmFlag (system wait flag)
2) Common (system template class, including document templates, document list templates, dialog box templates, report templates, etc.)
1. frmBaseList (basic information list template)
2. frmBill (document template)
3. frmBillList (document list template)
4. frmDialog (dialog template)
5. frmMDIChild (MDI Subform Template)
6. frmReport (report template)
7. frmSelItem (general window for material selection)
8. frmSQL (SQL Statement Editing Window)
3) CommonData (system common window library, including select materials, select employees, etc. forms)
1. frmSelDept (select department window)
2. frmSelEmp (select employee window)
3. frmSelGroup (select the group window)
4. frmStorageInfo (material inventory window)
4) Base (Basic Database)
1. frmAssist (supporting information)
2. frmCarry Company
3. frmClient (client)
4. frmCraftwork
5. frmEmp (Staff)
6. frmItem (raw material)
7. frmOutSupplier (outsourced vendor)
8. frmPic (product image)
9. frmProcess
10. frmProduct (Product Literature)
11. frmProductProcess
12. frmStockPrice
13. frmStorage (repository information)
14. frmSupplier (Supplier Information)
15. frmWorkGroup
5) DataLib (Data Manipulation Library)
6) myControl (homemade control library)
7) Stock (Procurement Management Library)
1. frmApplyStock (subscription order)
2. frmMRP (MRP operation)
3. frmStockOrder (purchase order)
4. frmStockIn (purchase purchase)
5. frmStockBack (purchase return)
6. frmStockPay (purchase payment)
8) Sell (Sales Management Library)
1. frmAskPrice (Inquiry Form)
2. frmClientHistoryRepor (customer sales history)
3. frmEmpHistoryReport (sales history of salesman)
4. frmReSellPrice (sales pricing)
5. frmSellAccept (sales receipt)
6. frmSellBack (sales return)
7. frmSellOrder (customer order)
8. frmSellOut (sales and shipment)
9. frmSellPre (Shipping Notice)
10. frmSellPrice (quotation)
9) Storage (Warehouse Management Library)
1. frmCheck (inventory list)
2. frmCheckList (inventory list)
3. frmExchange (unpluging list)
4. frmExchangeList
5. frmInstall (disassembly list)
6. frmInstallList (disassembly list)
7. frmOtherIn (other warehouse receipts)
8. frmOtherOut (other warehouse orders)
9. frmOtherInOutList (in and out of the warehouse receipt list)
10. frmOtherStorageQty (business inventory)
11. frmStorageQty (real-time inventory list)
10) OutProduct
1. frmOutBill (outsourcing processing order)
2. frmOutBackGoods (outsourced processing return)
3. frmOutBackStore (outsourced processing return)
4. frmOutDrawGoods (outsourced processing picking list)
5. frmOutInStore (outsourced processing into the warehouse list)
6. frmOutPay (outsourced processing payment slip)
13) Wage (Payroll Management Library)
1. frmEditWage (piece pay editor)
2. frmFormula (formula)
3. frmGiffWage (Payroll Form)
4. frmMonthWage (monthly salary generation)
5. frmWageCheckOut
6. frmWageInput (salary entry)
7. frmWageItem (salary item)




