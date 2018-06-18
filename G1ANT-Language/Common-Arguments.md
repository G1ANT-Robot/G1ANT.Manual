# Common Arguments

Here is the list and explanation of arguments which can be used within most commands.

## if

Argument `if` followed by a condition, defines whether the command will be executed or skipped. The condition is a C# macro and if the expression contain some spaces, we advise you to paste it within ⊂⊃ for a clearer readability.

### Syntax

| Argument Name | Argument Value | Command Execution |
| if | true | yes |
| if | false | no |

**Example 1:**

```G1ANT
♥x = 3
program notepad if ♥x==3
```

In the example above, number 3 is assigned to a variable ♥x.  This part of the script: `program notepad if ♥x==3` will only be executed, if the condition is true. In this case it is. G1ANT.Robot **will open** notepad.

**Example 2:**

```G1ANT
♥x = theatre
program notepad if ♥x=="movie"
```

In the example above, word "theatre" is assigned to a variable ♥x.  This part of the script: `program notepad if ♥x=="movie"` will only be executed, if the condition is true. In this case it is false (theatre is not equal to movie). G1ANT.Robot **will not** open notepad.

Please, note that movie has to be in double quotes because that is how strings have to be declared in C#.

**Example 3:**

```G1ANT
♥x = 3
♥y = theatre
program notepad if ⊂♥x==3 &amp;&amp; ♥y=="theatre"⊃
```

G1ANT.Robot **will open** notepad.
 
## result

### Syntax:

Argument `result` lets us choose the name of a variable which will store the command's output. Variable name should be preceded by ♥.

**Example 1:**

```G1ANT
text.find text ♥clipboard search ♥web result ♥test
```

**Example 2:**

```G1ANT
excel.getvalue row 3 colindex 2 result ♥cellcontent
```

Please, note that you do not have to declare result variable in order to get a command's output.
If you leave this line of code as below, you can access the result using ♥result variable that is created automatically by G1ANT.Robot.

```G1ANT
excel.getvalue row 3 colindex 2
```

Please, try it using dialog command that should display the command output like this:

```G1ANT
dialog ♥result
```

## errorjump 

Argument `errorjump` specifies name of a label to jump to when an error occur in the command. It allows G1ANT.Robot to omit some part of the script and jump to other part of the script. Label name should be preceded by ➜.

**Example 1:**

In the example below we are assigning some text to a variable **♥text**.
Our condition `⊂♥text == "Chris likes bananas"⊃` is false, so thanks to `errorjump` argument specified,  G1ANT.Robot jumps to label **➜banana** which is a value for `errorjump` argument. G1ANT.Robot will not dialog ‴Yes! Chris likes bananas!‴, because it will perform `errorjump` before he sees another command. Anything that is inside of  **➜banana**  label, will be executed. In our case: ‴Sorry, Chris doesn't like bananas!‴

```G1ANT
♥text = ‴Chris likes apples‴
test condition ⊂♥text == "Chris likes bananas"⊃ errorjump ➜banana
dialog ‴Yes! Chris likes bananas!‴
➜banana
dialog ‴Sorry, Chris doesn't like bananas!‴
```

**Example 2:**

```G1ANT
color.expected position ‴616⫽384‴ color ‴1E1E1F‴ errorjump ➜wrong result ♥name
dialog ♥name
jump ➜end
➜wrong 
dialog message ‴no expected color in this position‴
➜end
```

In this example, if the specified color "1E1E1F" is in the specified position "616⫽384" on the screen. G1ANT.Robot will dialog what is inside ♥name and jump to ➜end label, if the color is not found, program will jump to  ➜wrong label and dialog "no expected color in this position".

## errormessage

argument `errormessage` is a message that will be shown in case an error occurs and no `errorjump` argument is specified. If `errorjump` is specified, G1ANT.Robot will omit `errormessage` while executing the script.

**Example 1:**

```G1ANT
color.expected position ‴616⫽384‴ color ‴1E1E1F‴ errormessage ‴no expected color in this position‴
```

If color not found, such dialog displays:
 
## timeout

argument `timeout` lets us choose the amount of time (in milliseconds) of robot waiting for a command to be executed before throwing an error about time expiration. 

**Example 1:**

```G1ANT
chrome ‴google.com‴ timeout 100
```

Obviously, it is way too unexpected that within 100 ms our computer would perform such action so timeout error occurred as in the image below.
