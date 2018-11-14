# checkversion

**Syntax:**

```G1ANT
checkversion path ‴‴ result ‴‴ assembly ‴‴ if ‴‴ errorjump ‴‴ errormessage ‴‴
```

**Description:**

Command `checkversion` allows to check product, file and assembly versions of the file.
| Name | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`path`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | yes | |specifies file's path|
|`result`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md)  | no | ♥result |name of variable where product, file versions (and some file info) will be stored|
|`assembly`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md)  | no | ♥assembly| name of variable where assembly version will be stored|
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md)  | no | true |runs the command only if "if" condition is true|
|`errorjump`| [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md)  | no | | name of the label to jump to if given timeout expires|
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md)  | no | | message that will be shown in case error occurs and no `errorjump` argument is specified|

:

In this example custom path is created to one of G1ANT .dll files (be sure that this file exists). Then using command `checkversion` we get product and file version (and some more info) to result variable. Finally, using `dialog` command this information is displayed.

```G1ANT
♥p = ‴C:\\‴ + ♥homepath + ‴\\Documents\\G1ANT.Robot\\G1ANT.Engine\\bin\\Debug\\G1ANT.Sdk.dll‴
checkversion path ♥p
dialog ♥result
```

 
