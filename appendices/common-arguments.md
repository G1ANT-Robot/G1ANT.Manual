# Common Arguments

Here is the list and explanation of several arguments, which can be used with most commands.

## if

The `if` argument followed by a condition, defines whether a command will be executed or skipped. The condition is a C# macro and if the expression contains some spaces, you have to embrace it with `⊂⊃` special characters.

| Argument Name | Argument Value | Command Execution |
| ------------- | -------------- | ----------------- |
| `if` | true | yes |
| `if` | false | no |

### Example 1

```G1ANT
♥x = 3
program notepad if ♥x==3
```

In the example above, number 3 is assigned to the `♥x` variable.  This part of the script: `program notepad if ♥x==3` will only be executed, if the condition is true. In this case, it is, therefore G1ANT.Robot **will open** Notepad.

### Example 2

```G1ANT
♥x = theater
program notepad if ♥x=="movie"
```

In the example above, the word “theater” is assigned to the `♥x` variable.  The second line of the script — `program notepad if ♥x=="movie"` — will only be executed, if the condition is true. In this case it is false (`theater` is not equal to `movie`), therefore G1ANT.Robot **will not** open Notepad.

Please note that the word `movie` has to be in double quotes, because this is how strings have to be declared in C#.

### Example 3

```G1ANT
♥x = 3
♥y = theater
program notepad if ⊂♥x==3 && ♥y=="theater"⊃
```

G1ANT.Robot **will open** Notepad.

## errorcall

With the `errorcall` argument you can specify the procedure name to call in case an error occurs or a timeout expires.

### Example

```G1ANT
window blah errorcall ErrorOccurred
dialog OK!

procedure ErrorOccurred
    dialog ‴Could not find the specified window‴
end
```

In the first line of this example the robot tries to focus on the window titled *blah*. If it can’t find this window, the `ErrorOccurred` procedure is called, which shows an appropriate message.

Note that when a user clicks OK in the dialog, the procedure ends, but the script continues: the robot goes back to where the procedure was called and displays another dialog box. This return to the place of a call in the script is the main difference between `errorcall` and `errorjump` arguments.

## errorjump 

The `errorjump` argument specifies name of a label to jump to when an error occurs during command’s execution or a timeout expires. It allows G1ANT.Robot to skip some part of the script and jump to the other.

### Example 1

In the example below some text is assigned to the `♥text` variable.

The condition `⊂♥text == "Chris likes bananas"⊃` is false, so, because the `errorjump` argument was specified,  G1ANT.Robot jumps to `label banana` — the value for the `errorjump` argument. G1ANT.Robot will not show dialog with “*Yes! Chris likes bananas!*” message, because the `errorjump` argument is executed before any other command. Therefore, anything within the `banana` label will be executed. In this particular case a dialog message “*Sorry, Chris doesn't like bananas!*” is shown.

```G1ANT
♥text = ‴Chris likes apples‴
test condition ⊂♥text == "Chris likes bananas"⊃ errorjump banana
dialog ‴Yes! Chris likes bananas!‴
stop silentmode true
label banana
dialog ‴Sorry, Chris doesn't like bananas!‴
```

### Example 2

```G1ANT
color.expected position 616⫽384 color 1E1E1F errorjump wrong result ♥name
dialog ♥name
jump end
label wrong 
dialog message ‴no expected color in this position‴
label end
```

In this example, if the specified color 1E1E1F is found in the specified position 616⫽384 on the screen, G1ANT.Robot will show a dialog with the contents of the `♥name` variable and then will jump to the `end` label. If the given color is not there, the robot will jump to the `wrong` label, displaying a dialog message: “*no expected color in this position*”.

## errormessage

The `errormessage` argument is a message that will be shown in case an error occurs and no `errorjump` argument is specified. If `errorjump` is specified, G1ANT.Robot will skip the `errormessage` argument while executing the script.

### Example

```G1ANT
color.expected position 616⫽384 color 1E1E1F errormessage ‴no expected color in this position‴
```

If a given color is not found, a message “*no expected color in this position*” will be displayed.

## errorresult

This argument allows assigning a variable, which will store the information about the exception that occurred when a command was executed. The variable name should be preceded by `♥`.

The error information is contained in an [error structure](G1ANT.Language/G1ANT.Language/Structures/ErrorStructure.md) with `type` and `message` indexes.

### Example

```G1ANT
window blah errorresult ♥someError errorcall ErrorOccurred
keyboard OK!

procedure ErrorOccurred
    dialog ‴♥someError⟦type⟧ error occurred: ♥someError⟦message⟧‴
end
```

This extended version of the `errorcall` argument example shows a dialog message with a detailed information about the error.

## timeout

The `timeout` argument allows to choose the amount of time (in milliseconds) for the robot to wait for a command to be executed before throwing an error about time expiration.

#### Example

```G1ANT
chrome google.com timeout 10
```

Obviously, the computer won’t perform this action within 10ms, so a timeout error occurs.
