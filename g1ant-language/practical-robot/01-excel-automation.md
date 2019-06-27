# Excel, Procedures and Loops

Let’s start with automating Excel spreadsheets. Imagine you want to get data from one file and enter them into another, newly created file. For the purposes of this tutorial, create a folder called Data in your Documents (Windows 10) or My Documents (earlier Windows versions) folder and put this excel data file [data.xlsx](../../-assets/data.xlsx) into it.

Since using the whole path to a file every time you want to refer to it is a bit tedious, robotizing this repetitive task would be a good starting point. All you have to do is to declare a new variable — named  `♥datafile1`, for example — with its value equal to the filepath.

The easiest way to find the path to a file is simply to open the file explorer (Windows Explorer), navigate to the folder where your file is stored, and copy the address of the folder from the Explorer’s address bar (to make Explorer display the path in a “classic” way, click folders icon to the left of the bar) followed by the name of the file with extension. The correct filepath should look like this:

C:\Users\\*Username*\Documents\Data\data.xlsx

where *Username* is the name of the current Windows user — that is you — so you should have your user name shown there, like *Mary*, *John Smith*, or whatever your Windows user name is. (Note that in versions of Windows prior to 10, the *Documents* folder will be named *My Documents*.)

This is how your filename variable would be declared in the script:

```G1ANT
♥datafile1 = C:\Users\Username\Documents\Data\data.xlsx
```

## Protect the Environment

Can you spot a problem in the code above? Yes: it’s your user name! When you use such expression on your machine — your account, to be precise — everything is fine. Things get tough when you try to port this robot script somewhere else: you would have to change the filepath to include a correct Windows user name. Imagine doing this on many PCs…

We predicted this scenario and provided a special variable `♥environment⟦⟧`, which reads specified environment variables of the host system (environment variables store system information of different type; read more on the `♥environment⟦⟧` variable [here](https://manual.g1ant.com/link/G1ANT.Manual/appendices/environment.md)). One of them, `USERPROFILE`, provides the full path to current user files. See what yours is:

```G1ANT
dialog ♥environment⟦USERPROFILE⟧
```

Alright, now you are able to use the script independently of the user account — just insert the special variable into your previous filepath, replacing the fixed user name:

```G1ANT
♥datafile1 = ‴♥environment⟦USERPROFILE⟧\Documents\Data\data.xlsx‴
```

You have the path to your first Excel file specified in a variable. The second Excel file will be named *data2.xlsx*. Even if it doesn't exist at the moment, you can already set its future path in a new variable `♥datafile2`:

```G1ANT
♥datafile2 = ♥environment⟦USERPROFILE⟧\Documents\Data\data2.xlsx
```

## Excel-lent Commands

Your robot should do the following steps in order to copy all cells with values from one spreadsheet to another:

1. Open the source Excel file.
2. Read the first cell containing data (row 1, column A) and store its value in a variable.
3. Move to the next cell in the row and repeat step 2.
4. When the last filled cell in the row is reached and its value is read, move to the first cell in the next row and repeat steps 2-3.
5. When the last filled cell’s value is read, open the target Excel file.
6. Repeat steps 2-4, but with inserting the data from the variables into cells.
7. When the last variable’s value is inserted, save the target Excel file.

Let’s start with a bit simplified version of the algorithm above limited to the first row only (step 4 skipped).

> **Note:** In order to use `excel.` commands, the MSOffice addon needs to be enabled. Just click the check box next to `msoffice` entry in the Addons panel (by default, on the left of the workspace).

It’s time to tell your robot to open the *data.xlsx* file. Of course, there’s a command for that: `excel.open`. Just pass the filepath to it, using your `♥datafile1` variable:

```G1ANT
excel.open ♥datafile1
```

The robot will open a file specified in the variable. Now you would want the robot to read the values from this spreadsheet. Surprise: we got another command for that! It’s called `excel.getvalue` and you use it with `row` and `colname` arguments. The `row` argument is followed with the name or the number of the cell's row that you want to get value from. Similarly, the value for the `colname` argument specifies the number or the name of the cell's column. The `result` argument lets you choose the name of the variable,  which will store the value of the desired cell.

So, if you want to get the value of the cell in column A, row 1 and store it in the `♥cell1` variable, you enter:

```G1ANT
excel.getvalue row 1 colname a result ♥cell1
```

In the example xlsx file there are six columns (A to F) and five rows filled with data. Since for now you want to read all cells containing information in the first row, you have to repeat the above line five more times, changing the column name in the `colname` argument and the name of the variable to store the read data:

```G1ANT
excel.getvalue row 1 colname b result ♥cell2
excel.getvalue row 1 colname c result ♥cell3
excel.getvalue row 1 colname d result ♥cell4
excel.getvalue row 1 colname e result ♥cell5
excel.getvalue row 1 colname f result ♥cell6
```

Now the robot should open a new, blank Excel document, so type:

```G1ANT
excel.open
```

You are ready to insert the values stored in six variables into the cells in the blank spreadsheet. Just take another command from the `excel.` family: `excel.setvalue` will enter data provided with the `value` argument (a value of one of the `♥cell` variables in this case) in a cell specified by `row` and `colname` arguments you know from the `excel.getvalue` command. The script for that is simple:

```G1ANT
excel.setvalue value ♥cell1 row 1 colname a  
excel.setvalue value ♥cell2 row 1 colname b  
excel.setvalue value ♥cell3 row 1 colname c  
excel.setvalue value ♥cell4 row 1 colname d  
excel.setvalue value ♥cell5 row 1 colname e  
excel.setvalue value ♥cell6 row 1 colname f  
```

The last step for your robot is to save this new spreadsheet as *data2.xlsx* file, using `excel.save` command and the filepath stored in the `♥datafile2` variable:

```G1ANT
excel.save ♥datafile2
```

Let’s save this script and check if in the specified location *data2.xlsx* file exist. It does! And it contains all the values from the first row.

Your whole robot script should be as below:

```G1ANT
♥datafile1 = ‴♥environment⟦USERPROFILE⟧\Documents\Data\data.xlsx‴
♥datafile2 = ‴♥environment⟦USERPROFILE⟧\Documents\Data\data2.xlsx‴
excel.open ♥datafile1
excel.getvalue row 1 colname a result ♥cell1
excel.getvalue row 1 colname b result ♥cell2
excel.getvalue row 1 colname c result ♥cell3
excel.getvalue row 1 colname d result ♥cell4
excel.getvalue row 1 colname e result ♥cell5
excel.getvalue row 1 colname f result ♥cell6
excel.open
excel.setvalue value ♥cell1 row 1 colname a  
excel.setvalue value ♥cell2 row 1 colname b  
excel.setvalue value ♥cell3 row 1 colname c  
excel.setvalue value ♥cell4 row 1 colname d  
excel.setvalue value ♥cell5 row 1 colname e  
excel.setvalue value ♥cell6 row 1 colname f  
excel.save ♥datafile2
```

Now save the script and run it with **F9** key. Check your Data folder if the *data2.xlsx* file exists. It does! And it contains all the values from the first row of the source Excel spreadsheet.

## More Rows, More Trouble

The code you created in the previous section is quite long. You can see that it’s very repetitive in most of its part: 12 lines out of 17 are practically the same and differ only in incremental arguments. Imagine how this script would look like if you were to execute the full algorithm and copy all rows, not just one: this 12 lines repeated 5 times.

Luckily, there’s a way to avoid this repetitions. You can take parts of code that can be used again elsewhere in the script and make a block known as a procedure, which is called when needed. Procedures are not only a great solution for repeated actions, but they also make your code more ordered and structured. It’s a good practice to use procedures for every piece of your code, so that you know which parts of a script are responsible for what actions.

Start with deleting the file *data2.xlsx* created with G1ANT.Robot. Then open a new script window or clear existing one. You can leave first two lines with filepath `♥datafile` variables.

## Procedures Solve Everything

Procedures are sets of commands in our programming language. Sometimes the robot scripts are so long and complicated that splitting them into small, named pieces is almost inevitable. Look at the algorithm again: these seven steps are in fact three job sets: file operations (open/save), copying cell values, entering  these values.

First, create main procedure, which will refer to other procedures that you will add soon:

```G1ANT
procedure CopyToNewExcelFile

end
```

There are two rules for procedures:

- Every procedure ends with the word `end`.
- Using tabs (line indents) within a procedure makes it clearer and more convenient to read.

Whenever you want to refer to a procedure, use the `call` command followed by the procedure name:

```G1ANT
call CopyToNewExcelFile
```

Alright, you know how to create procedures, so start actually doing it. The first thing that this procedure will do is to open the source file *data.xlsx*:

```G1ANT
    excel.open ♥datafile1 result ♥excelid1
```

Note that the same `excel.open` command is used, but this time with an optional argument `result`. Why? When G1ANT.Robot opens an Excel file, it assigns an ID to this document. The `result` argument will read the ID and store it in a variable you specify — `♥excelid1` in this case. The ID will prove useful when you want to switch among many different Excel files. And this is what you are going to do later on.

In the next line, tell the robot to open a new, blank Excel file and remember its ID in another variable:

```G1ANT
   excel.open result ♥excelid2
```

You will need two more procedures: one to get the data from the source file and one to enter the data into the target file. Let’s name the first one `GetValues` and the second one `SetValues`:

```G1ANT
procedure GetValues


end

procedure SetValues


end
```

You have the outline of your new script. It’s time add some functionality to your procedures.

As we mentioned before, there’s the `excel.switch` command, which allows switching through Excel files opened by G1ANT.Robot. You will need this command, because you want to switch repeatedly between *data.xlsx* and *data2.xlsx* files to get data, enter data, get data, enter data etc... Now you can use the `excelid1` variable that you created earlier to open a file with the ID stored there:

```G1ANT
procedure GetValues 
    excel.switch ♥excelid1
    
    
end
```

Excel files often are filled with lots of data — they tend to have many rows and it would take the programmer too many hours to write the code that would process the spreadsheet row by row. Besides, the script would be too long.

## Killer Loops

But these repetitive actions can be automated with loops. As its name implies, a loop is a set of actions that are repeated specified or indefinite (infinite) number of times. In case of this example, a loop could solve the problem of calling your get/set values procedures again for the next row to be processed.

The basic loop starts with the `for` command and ends with — you guessed — `end`. The `for` command needs at least three arguments, which specify the basic parameters of a loop:

- `counter` argument followed by the name of a variable, which will store a number that changes with every execution of a loop (if it’s not an infinite one),
- `from` argument with the initial value of the variable specified by the `counter` argument,
- `to` argument with the end value of the variable specified by the `counter` argument; when the variable exceeds the this value, the loop ends.

In this example you need a loop that calls procedures five times, starting from row 1 and ending at row 5 of your Excel files. Name a counter variable `♥rownumber` and type the first line of your loop:

```G1ANT
for counter ♥rownumber from 1 to 5
```

The next lines of this loop should call procedures for reading and entering data from the cells in the current row:

```G1ANT
    call GetValues
    call SetValues
end
```

Since you already have a variable, which stores current row number (`♥rownumber`), you can use it in the procedures called from within the loop:

```G1ANT
procedure GetValues
    excel.switch ♥excelid1
    excel.getvalue row ♥rownumber colname a result ♥cell1
    excel.getvalue row ♥rownumber colname b result ♥cell2
    excel.getvalue row ♥rownumber colname c result ♥cell3
    excel.getvalue row ♥rownumber colname d result ♥cell4
    excel.getvalue row ♥rownumber colname e result ♥cell5
    excel.getvalue row ♥rownumber colname f result ♥cell6
end
```

```G1ANT
procedure SetValues
    excel.switch ♥excelid2
    excel.setvalue value ♥cell1 row ♥rownumber colname a 
    excel.setvalue value ♥cell2 row ♥rownumber colname b 
    excel.setvalue value ♥cell3 row ♥rownumber colname c 
    excel.setvalue value ♥cell4 row ♥rownumber colname d 
    excel.setvalue value ♥cell5 row ♥rownumber colname e 
    excel.setvalue value ♥cell6 row ♥rownumber colname f 
end
```

It’s time to go back to the main `CopyToNewExcelFile` procedure and update it with commands that open Excel files, call the procedures that get/set cell values for each row and then save the target file:

```G1ANT
procedure CopyToNewExcelFile
    excel.open path ♥datafile1 result ♥excelid1
    excel.open result ♥excelid2
    for counter ♥rownumber from 1 to 5
        call GetValues
        call SetValues
    end
    excel.save path ♥datafile2
end
```

Now that you have all necessary bricks for your robot, put them together and make the working script:

```G1ANT
♥datafile1 = ‴♥environment⟦USERPROFILE⟧\Documents\Data\data.xlsx‴
♥datafile2 = ‴♥environment⟦USERPROFILE⟧\Documents\Data\data2.xlsx‴
call NewExcelFile
procedure CopyToNewExcelFile
    excel.open path ♥datafile1 result ♥excelid1
    excel.open result ♥excelid2
    for counter ♥rownumber from 1 to 5
        call GetValues
        call SetValues
    end
    excel.save path ♥datafile2
end
procedure GetValues
    excel.switch ♥excelid1
    excel.getvalue row ♥rownumber colname a result ♥cell1
    excel.getvalue row ♥rownumber colname b result ♥cell2
    excel.getvalue row ♥rownumber colname c result ♥cell3
    excel.getvalue row ♥rownumber colname d result ♥cell4
    excel.getvalue row ♥rownumber colname e result ♥cell5
    excel.getvalue row ♥rownumber colname f result ♥cell6
end
procedure SetValues
    excel.switch ♥excelid2
    excel.setvalue value ♥cell1 row ♥rownumber colname a 
    excel.setvalue value ♥cell2 row ♥rownumber colname b 
    excel.setvalue value ♥cell3 row ♥rownumber colname c 
    excel.setvalue value ♥cell4 row ♥rownumber colname d 
    excel.setvalue value ♥cell5 row ♥rownumber colname e 
    excel.setvalue value ♥cell6 row ♥rownumber colname f 
end
```
