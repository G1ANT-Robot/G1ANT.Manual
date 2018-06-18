**Syntax:**

Defining a procedure:

```G1ANT
procedure  ➤procedurename  inputparam 0  secondparam 1
end
```

Calling a procedure:

```G1ANT
call ➤forloop  starti 0  endi 5
```

**Description:**

`➤` **Procedure** allows to define procedure with input parameters (or without) anywhere in the script code. You can later call the procedure with specific parameters where you need it. Designed to use for set of repeatable commands which can be used multiple times with different parameters. The special ➤ character is available in the G1ANT Developer Studio -> Insert -> Procedure
When defining, be sure to:
1.  Put default value after parameter name - it is needed to define the TYPE of input parameter.
2.  Finish defining with "end" command

**Example 1:**

Defining a procedure that we will later refer to. The content of the procedure is `dialog ‴this is a procedure‴`. Even though we define procedure in the beginning of the script, `dialog Hi!` will pop up first, because the procedure is being executed no sooner then we call it using `call ➤test` (**test* is the name of the procedure in our case)

```G1ANT
procedure ➤test
              dialog message ‴this is a procedure‴
end
dialog message ‴Hi!‴
call ➤test
```

**Example 2:**

This is an example of quite a complex script, so let's divide it into smaller parts. The aim of the following script is to inject some data from the list inside of Excel document.

Let us first create a list and inject values inside of it. The first value is a string, so the rest of the values will be understood as strings too.

```G1ANT
♥dataList = OrderDate❚Region❚Rep❚Item❚Units❚UnitCost❚Total❚(date)1/6/2016❚East❚Jones❚Pencil❚95❚1.99❚189.05❚1/23/2016❚Central❚Kivell❚Binder❚50❚19.99❚999.50❚2/9/2016❚Central❚Jardine❚Pencil❚36❚4.99❚179.64❚2/26/2016❚Central❚Gill❚Pen❚27❚19.99❚539.73❚3/15/2016❚West❚Sorvino❚Pencil❚56❚2.99❚167.44❚4/1/2016❚East❚Jones❚Binder❚60❚4.99❚299.40❚4/18/2016❚Central❚Andrews❚Pencil❚75❚1.99❚149.25❚5/5/2016❚Central❚Jardine❚Pencil❚90❚4.99❚449.10❚5/22/2016❚West❚Thompson❚Pencil❚32❚1.99❚63.68❚6/8/2016❚East❚Jones❚Binder❚60❚8.99❚539.40❚6/25/2016❚Central❚Morgan❚Pencil❚90❚4.99❚449.10❚7/12/2016❚East❚Howard❚Binder❚29❚1.99❚57.71

Defining procedures: while writing the script for the procedure, we are creating variables with values assigned to them in the beginning, it is a good practice to assign values inside of variables, because they are reusable. 


```G1ANT
procedure ➤populateExcel
        ♥i=1
        ♥rowIndex = 1
        ♥columIndex  = 1
```

The part of the script below is where the magic happens, we are defining a **loop**, that is some fragment of the script that G1ANT.Robot will execute all over again as long as the condition is true. 

The following script will insert values from the list **♥dataList⟦♥i⟧** starting from the value with index=1 (in our case it is 'OrderDate') into columns, we specified it in variables above. The execution of the script will only fill 7 columns, because of the condition we specified: 
`if ⊂♥columIndex <= 7⊃`
The line @jump ➜columns if ⊂♥columIndex <= 7⊃@ means that G1ANT.Robot will move to the top of the script where we started defining the loop if the *♥columIndex* is 1,2,3,4,5,6 or 7, when it is 8, G1ANT.Robot will go further. 
The 'key' of the loop is a number that gets incremented every time G1ANT.Robot reads the script inside of the loop. 
`♥i=♥i+1` - it increments the index of the values from our list. 
`♥columIndex = ♥columIndex + 1` - it increments the columns number.

```G1ANT
➜columnsandrows
    excel.setvalue value ♥dataList⟦♥i⟧ row ♥rowIndex colindex ♥columIndex errorjump ➜done
    ♥i=♥i+1
    ♥columIndex = ♥columIndex + 1
    jump ➜columnsandrows if ⊂♥columIndex <= 7⊃
```

This part of the script is responsible for inserting values inside of rows as long as the number of rows does not exceed 91 (it can equal 91). It is important to set  @♥columIndex  = 1@ again, because we were incrementing it before and it was 7.   
    
```G1ANT
    ♥columIndex  = 1
    ♥rowIndex = ♥rowIndex + 1
    jump ➜columnsandrows if ⊂♥i<=91⊃
    ➜done
end
excel.open 
excel.addsheet name ‴TestSheet‴
excel.activatesheet name ‴TestSheet‴
call ➤populateExcel
```

Please remember that G1ANT.Robot will not execute the precedure without this very important line: `call ➤populateExcel`
