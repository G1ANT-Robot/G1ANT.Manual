# error

This structure contains information about an error that occurred while the script was executed. A variable declared with `errorresult` argument will have an error structure.

There are two elements, which can be accessed with variable indices:

| Index       | Description                                                  |
| ----------- | ------------------------------------------------------------ |
| `⟦type⟧`    | Provides the type of an error in a text form derived from C# exceptions |
| `⟦message⟧` | Returns the human friendly description of an error           |

### Example

```G1ANT
window sometitle errorresult ♥error errorjump ➜dothis

➜dothis
dialog ‴♥error⟦type⟧, ♥error⟦message⟧‴
```

In the script above the robot tries to select a *Sometitle* window. Since there's no such window, the error information is passed to the `♥error` variable and the robot starts executing the part of the script labeled `➜dothis`. A dialog box is displayed with the type of the error and a message explaining what happened:

![](.gitbook/assets/error-structure.jpg)

