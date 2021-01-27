Inventory Management .Net C# MVC Application

The application provides an example code for an shopping inventory management system.

The fields include:-
StockItem, which is the name of the item.
Sellin, which is the number of days in which to sell the item.
Quality, which is the number value assigned to the item for it`s value.

The rules are:-
At the end of each day values are lowered for Sellin and Quality for every item.
The Quality value degrades twice as fast passed it`s sell by date.
The value range for Quality is between 0 and 50.
StockItem "Aged Brie" increases in Quality the older it gets.
StockItem “Frozen Item” decreases in Quality by 1.
StockItem "Soap" never has to be sold or decreases in Quality.
StockItem "Christmas Crackers", quality increases by 2 when there are 10 Sellin days or less and by 3 when there are 5 Sellin days or less, but quality drops to 0 after Sellin is 0.
StockItem "Fresh Item" degrade in Quality twice as fast as “Frozen Item”

Input: 
A list of items in the current inventory. 
Each line in the input represents an inventory item with Item name, its sell-in value and quality e.g. “ Christmas Crackers -1 2” => Christmas Crackers are past sellin value by 1 day with quality 2.

Output: 
Updated inventory after adjusting the quality and sellin days for each item after 1 day.

Test Input :
Aged Brie 1 1
Christmas Crackers -1 2
Christmas Crackers 9 2
Soap 2 2
Frozen Item -1 55
Frozen Item 2 2
INVALID ITEM 2 2
Fresh Item 2 2
Fresh Item -1 5

Expected Output :
Aged Brie 0 2
Christmas Crackers -2 0
Christmas Crackers 8 4
Soap 2 2
Frozen Item -2 50
Frozen Item 1 1
NO SUCH ITEM
Fresh Item 1 0
Fresh Item -2 1

Installation instructions 
Download onto a local machine from GitHub. Save the file in local file location. Eg \source\repo

Operating instructions:-
Open the application in Microsoft Visual Studio, and run the MVC application in a web browser.

Copyright and licensing information:-
Open source

Author:-
By Linda Jones 
