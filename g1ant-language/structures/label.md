# Label

### Syntax

```G1ANT
➜label
```

### Description

`➜labelname` defines a label element. A label is the place where the script will start executing from, when it is instructed to jump to `➜labelname`. You can insert a label by selecting it from `Insert/Label` menu, clicking `➜` icon on the toolbar or pressing **Ctrl+2**.

See also: [Jump](../control-flow-commands/jump.md)

### Example

```G1ANT
jump ➜start
dialog ‴Jump over this text‴
➜start
dialog ‴Congratulations! You've made a jump to start label!‴
```

