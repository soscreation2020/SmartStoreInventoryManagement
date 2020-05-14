<script >

 

        function ShowLPO(y) {

            var link = '<%=ResolveClientUrl("~/Customer/LPO.aspx?acc=")%>' + y;

            var oWnd = radopen(link, null);

            oWnd.set_visibleStatusbar(false);

            oWnd.moveTo(300, 200);

            // oWnd.setSize(650, 600);

            // oWnd.autoSize(true);

            oWnd.maximize();

        }

 

     

        // get the id of the table

        // var dataTable = 'ctl06_Purchase-Orders_ctl07_dataTable';

        var dataTable = document.getElementById('dataTable');

     

 

        function addRowToTable() {

             // get the radcombo text and value(price)

            var combo = $find("<%= RcbItem.ClientID %>");

            //var combo = document.getElementById('RcbItem');

            var itemName = combo.get_text();

            var comboVal = combo.get_value();

            if (comboVal == '') {

                alert('OMISSION: Please select a valid Item');

                return false;

            }

            var wac = comboVal.substring(17);

            //-----new cost method

            var uP = $find("<%= rntbUnitCost.ClientID %>");

            var unitPrice = uP.get_value();

            if (q == '') {

                alert('OMISSION: Please select a Quantity');

                return false;

            }

            //var unitPrice = uP;

            var destinationCombo = $find("<%= rcbStore.ClientID %>");

            var department = destinationCombo.get_text();

            //ensure a valid dept is selected

            var deptId = destinationCombo.get_value();

            if (deptId == '') {

alert('OMISSION: Please select a Valid Destination');

return false;

            }

 

            var quantity = $find("<%= rntbQauntity.ClientID %>");

            var q = quantity.get_value();

            if (q == '') {

alert('OMISSION: Please select a Quantity');

return false;

            }

 

           // set focus back

            var input = combo.get_inputDomElement();

            input.focus();

 

            combo.set_text("");

            // add a new row

            // var tbl = document.getElementById(dataTable);

            var tbl = document.getElementById('dataTable');;

            var lastRow = tbl.rows.length;

            // if there's no header row in the table, then iteration = lastRow + 1

            var iteration = lastRow;

            var row = tbl.insertRow(lastRow);

 

            // left cell

            var cellRight = row.insertCell(0);

            //var el = document.createElement('input');

            //el.type = 'checkbox';

            ////el.setAttribute('onselect', 'deleteRow()');

            //cellRight.appendChild(el);

            cellRight.innerHTML = department + '  **' + deptId;

 

            // Item name column

            var cellName = row.insertCell(1);

            cellName.innerHTML = itemName;

             // Unit price column

            var cellPrice = row.insertCell(2);

            cellPrice.innerHTML = unitPrice;

            // Quantity column

            var cellQ = row.insertCell(3);

           

            cellQ.innerHTML = q;

             // subtotal column

            var cellSub = row.insertCell(4);

            cellSub.innerHTML = q * unitPrice;

 

            // remove column

            var cellDelete = row.insertCell(5);

            var buttonnode = document.createElement('input');

            buttonnode.setAttribute('type', 'button');

            //buttonnode.setAttribute('name', 'sal');

            buttonnode.setAttribute('value', 'Remove item');

            //buttonnode.setAttribute("onClick", 'deleteRow()')

            //buttonnode.attachEvent('onclick', 'deleteRow');

            buttonnode.onclick = function () {

var i = this.parentNode.parentNode.rowIndex;

document.getElementById('dataTable').deleteRow(i);

GrandTotal();

            };

            cellDelete.appendChild(buttonnode);

         

            //guard against misspell items

            if (unitPrice == 0) {

var table1 = document.getElementById('dataTable');

var rowCount = table1.rows.length;

table1.deleteRow(rowCount - 1);

 

alert('Item without prices and invalid Items are not allowed');

            }

            GrandTotal();

        }

 

        function deleteRow() {

            try {

var table = document.getElementById('dataTable');

var rowCount = table.rows.length;

 

for (var i = 0; i < rowCount; i++) {

     var row = table.rows[i];

     var chkbox = row.cells[5].childNodes[0];

     if (null != chkbox && true == chkbox.checked) {

         if (rowCount <= 1) {

             alert("Cannot delete all the header rows");

             break;

         }

         table.deleteRow(i);

         rowCount--;

         i--;

     }

 

}

            } catch (e) {

alert(e);

            }

            GrandTotal();

        }

 

        function GrandTotal() {

            var table = document.getElementById('dataTable');

            var rowCount = table.rows.length;

            var sum = 0

            // var newrow = table.insertRow(rowCount);

            // reference the all subtotal cells

            for (var i = 1; i < rowCount; i++) {

var drow = table.rows[i];

sum = sum + parseFloat(drow.cells[4].innerHTML);

            }

            var total = document.getElementById('total');

            total.innerHTML = 'N' + sum;

            //var cellSum = newrow.insertCell(0);

            //cellSum.innerHTML = sum;       

        }

 

        function CreateText() {

            var minsize = 10;

            var maxsize = 15;

            var startvalid = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz123456789';

            var validchars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz123456789';

            var actualsize = Math.floor(Math.random() * (maxsize - minsize + 1)) + minsize;

            var guid = startvalid.charAt(Math.floor(Math.random() * startvalid.length));

            for (count = 1; count < actualsize; count++)

guid += validchars.charAt(Math.floor(Math.random() * validchars.length));

            return guid;

       }

 

        function PostOrder() {

            var table = document.getElementById('dataTable');

            //generate UID to serve as Order identifier

            var guid = CreateText();

 

            // get the due date and order date

            var order = $find("<%=rdpOrderDate.ClientID %>");

            // var orderDate = order.get_value;

            var orderDate = order.get_selectedDate();

            if (!orderDate) {

alert('OMISSION: Select a valid Order Date');

return false;

            }

 

            var due = $find("<%=rdpDueDate.ClientID %>");

            var dueDate = due.get_selectedDate();

            if (!dueDate) {

alert('OMISSION: Select a valid Due Date');

return false;

            }

 

            // ensure duedate>orderdate

            var diff = (dueDate - orderDate);

            if (diff < 0) {

alert('TRANSACTION HALTED: Due Date must be later than Order Date');

return false;

            }

            var combo = $find("<%= rcbVendor.ClientID %>");

            var itemName = combo.get_text();

            var person = combo.get_value();

            if (person == '') {

alert('OMISSION: Select a valid Vendor Account');

return false;

            }

 

            //var combo = document.getElementById('rcbrequisition');

            var combo2 = $find("<%= rcbRequisition.ClientID %>");

            // var itemName = combo.get_text();

            var reqId = combo2.get_value();

            //check that reqId is valid

            if (reqId == '')

            {

alert('OMISSION: Valid and Approved Requisition needed');

return false;

            }

 

              for (var i = 1, row; row = table.rows[i]; i++) {

//iterate through rows

//rows would be accessed using the "row" variable assigned in the for loop

var name = row.cells[1].innerHTML;

var price = row.cells[2].innerHTML;

var quantity = row.cells[3].innerHTML;

var deptId = row.cells[0].innerHTML.split("**")[1];

 

//call the webservice

             Inventory.RecordOrder(orderDate.format("MM/dd/yyyy"), dueDate.format("MM/dd/yyyy"), guid, name, price, quantity, person, reqId, deptId, Callback);

 

 

//for (var j = 0, col; col = row.cells[j]; j++) {

// the above will iterate through columns

//columns would be accessed using the "col" variable assigned in the for loop

//  }

            }

            //****** Note this prevent incomplete receipt printing ******

            setTimeout("__doPostBack('BtHid', '')", 6000);

        }

 

        function Callback(result) {

            var outDiv = document.getElementById("record");

            var x = 0;

            outDiv.innerHTML += result;

        }

    </script>