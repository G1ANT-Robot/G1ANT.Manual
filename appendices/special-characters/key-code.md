# Key Code

## Syntax

```G1ANT
⋘key name⋙
```

## Description

The key code special character `⋘⋙` includes a single key code (e.g. `⋘enter⋙`), repeated key code (e.g. `⋘tab 4⋙`) or a key combination (e.g. `⋘ctrl+a⋙`). It is for a specific use with the `keyboard` command. You can also mix key codes with regular keys  (without a special purpose).

You can insert this character from `Insert/Key Code` menu or with **Ctrl+,** (comma) keyboard shortcut.

### Example

```G1ANT
♥text = ‴text to be placed in Notepad‴
program name ‴notepad‴
keyboard ♥text
keyboard ⋘enter 2⋙
keyboard ♥text
keyboard ⋘shift+up⋙
```

![img](../../-assets/text.png)