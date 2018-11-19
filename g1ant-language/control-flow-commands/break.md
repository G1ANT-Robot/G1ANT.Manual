# break

## Syntax

```G1ANT
break
```

## Description

The `break` command immediately exits current block and continues task execution.

| Argument | Type                       | Required | Default Value | Description                                |
| -------- | -------------------------- | -------- | ------------- | ------------------------------------------ |
| `if`     | [bool](g1ant-language/structures/bool) | no       | true          | Runs the command only if condition is true |

For more information about `if`, see [Common Arguments](g1ant-language/common-arguments.md) page.

## Example

```G1ANT
for counter ♥cnt from 1 to 20
  if ⊂♥cnt==10⊃
    dialog ‴break‴    
    break
  end if 
end for
```

This example shows that even when the `♥cnt` variable reaches the value of 10 and a dialog box with “break” text is displayed, clicking OK button doesn't stop the process, and the `for` block continues execution. It's because the `break` command stops only the current block — `if`.
