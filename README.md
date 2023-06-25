# Workflow Solution
ERP Workflow solution base on Windows Workflow Foundation.

# Workflow Designer
![Workflow Designer](https://github.com/EnterpriseSolution/Workflow/blob/master/Workflow%20Designer.jpg)

# Workflow Monitor
![Workflow Monitor](https://github.com/EnterpriseSolution/Workflow/blob/master/Workflow%20Monitor.jpg)

# Message Syntax
**Field Reference:**　</br>
Order No: <%SalesOrderEntity.OrderNo%>　<br />
Amount: <%SalesOrderEntity.NetBalAmt%> (<%SalesOrderEntity.Ccy%>)　<br />
Posted By: <%SalesOrderEntity.PostedBy%>　<br />
Posted Date: <%SalesOrderEntity.PostedDate%>　<br />

**Loop:**　</br>
<%RepeatEachRecord_Begin.SqlQuery2%>　</br>
Line No: <%SqlQuery2.Line_No%>　</br>
Item No: <%SqlQuery2.Item_No%>　</br>
Qty: <%SqlQuery2.Qty%> <%SqlQuery2.Uom%>　</br>
Unit Price: <%SqlQuery2.Price%>　</br>
<%RepeatEachRecord_End.SqlQuery2%>　</br>

**Runtime Variable:**　</br>
 <%SessionEntity.UserId%>　　</br>

**SQL Query:**　</br>
Select Line_No, Item_No, Qty, Uom, Price from SLORDD
Where Order_No = '<%SalesOrderEntity.OrderNo%>'
Order By Line_No

# Guide
- Run against with SQL Server to create a new workflow database
