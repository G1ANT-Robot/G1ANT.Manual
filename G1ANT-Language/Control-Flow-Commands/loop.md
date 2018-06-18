This section describes how to create and implement different types of loops using G1ANT.Language.

## FOR loop

A for loop enables to run chosen tasks as many times as specified.

**Example 1:**

```G1ANT
♥i=0 
➜forloop
♥i=♥i+1
dialog message ‴here are the tasks to be done in a loop: ♥i time‴
jump label ➜forloop if ♥i<3
```

In this loop the message is dialogued 3 times. It is initiated as long as the ♥i variable is smaller than number of iterations (here: 3).
Note: this loop can also be implemented using procedures.

## DO WHILE/DO UNTIL loop

A loop which runs chosen tasks as long as the condition is true.

**Example 2:**

```G1ANT
➜dowhileloop
-start of loop
dialog message ‴do you want to see this again?‴
dialog.ask message ‴type your answer:(yes/no)‴
♥answer=‴yes‴
-end of loop
jump label ➜dowhileloop if ♥result==♥answer
```

This loop runs as long as 'yes' is typed in the dialog window.
NOTE: This loop will be executed for the first time, even if the condition is false. To perform a loop, which checks the condition at the start see below: WHILE loop:

## WHILE loop

A loop which runs chosen tasks as long as the condition is true (condition tested at the beginning of the loop).

**Example 3:**

```G1ANT
➜whileloop
♥answer=‴yes‴
♥result=‴no‴
jump label ‴➜whileloop‴ if ♥result==♥answer
jump label ‴➜end‴ if ♥result!=♥answer
➜whileloop
-start of loop
dialog message ‴do you want to see this again?‴
dialog.ask message ‴type your answer:(yes/no)‴
-end of loop
jump label ‴➜whileloop‴ if ♥result==♥answer errorjump ‴➜end‴
➜end
```

In this example the tasks are performed for the first time only if the condition is true before the first iteration (here, the variables bc.♥answer and bc.♥result are not equal). In case of the condition being false, the robot proceeds to the end of the loop (➜end label).

## NESTED FOR loop

A FOR loop with another FOR loop nested inside.

**Example 4:**

```G1ANT
➜forloop
♥x=♥x+1
♥y=0 
➜nestedloop
♥y=♥y+1
-start loop
dialog message ‴here is the row ♥x column ♥y of our imaginary matrix‴
-end loop
jump label ‴➜nestedloop‴ if ♥y<2
jump label ‴➜forloop‴ if ♥x<3
```

This example is especially useful when used with matrixes or spreadsheets - imagine the x and y iterators as coordinates.
