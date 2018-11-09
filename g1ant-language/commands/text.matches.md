# text.matches

## Syntax

```G1ANT
text.matches  text ‴‴  regexes ‴‴
```

## Description

The `text.matches` command gives a percentage value [0,100] of how much a specified text matches with provided regexes.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`text`| [text](../Structures/text.md) | yes |  | Text or a variable with the content to be written |
|`regexes`| [text](../Structures/text.md)                 | yes |  | List of regexes to be matched against text input |
|`result`| [variable](../Special-Characters/variable.md) | no | [♥result](../Common-Arguments.md) | Name of a variable where the command's result will be stored |
|`if`| [bool](../Structures/bool.md) | no | true | Executes the command only if specified condition is true |
|`timeout`| [variable](../Special-Characters/variable.md) | no | [♥timeoutcommand](../Variables/Special-Variables.md) | Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed |
|`errorcall`| [procedure](../Structures/procedure.md) | no |  | Name of a procedure to call when the command throws an exception or when a given `timeout` expires |
|`errorjump` | [label](../Structures/label.md) | no | | Name of the label to jump to when the command throws an exception or when a given `timeout` expires |
|`errormessage`| [text](../Structures/text.md) | no |  | A message that will be shown in case the command throws an exception or when a given `timeout` expires, and no `errorjump` argument is specified |
|`errorresult`| [error](../Structures/error.md) | no | | Name of a variable that will store the returned exception |

For more information about `if`, `timeout`, `errorcall`, `errorjump`, `errormessage` and `errorresult` arguments, see [Common Arguments](../Common-Arguments.md) page.

For more on regular expressions (regexes), see our [Regex Appendix](../../appendices/regex) or [Wikipedia entry](https://en.wikipedia.org/wiki/Regular_expression).

## Example

```G1ANT
text.matches text ‴A text to be searched in‴ regexes ‴\bt\w*\b‴
dialog ♥result
```

This example searches in “A text to be searched in” for all words starting with “t”. The regular expression provided in `regexes` searches for the beginning of a word \(`\b`\), then the letter “t”, then any number of repetitions of alphanumeric characters \(`\w*`\), then the end of a word \(`\b`\). Since there are two words in the text matching the criteria, the command returns 100 in the `♥result` variable, which is then displayed in a dialog box.