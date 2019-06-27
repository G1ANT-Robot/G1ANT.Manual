# Point Separator

## Syntax

```G1ANT
♥coordinates = 200⫽300
```

## Description

This character is used as a separator between x and y values in coordinates.

A point separator `⫽` is available from `Insert/Point Separator` menu or with **Ctrl+/** keyboard shortcut.

## Example

```G1ANT
♥xyStart = 200⫽300
♥xyEnd = 600⫽900
mouse.click ♥xyStart relative false type down
mouse.click ♥xyEnd relative false type up
```

In the example above the mouse pointer is set to the starting coordinates stored in the `♥xyStart` variable, then the default left mouse button is clicked and hold pressed with the [mouse.click](https://manual.g1ant.com/link/G1ANT.Language/G1ANT.Addon.Core/Commands/MouseClickCommand.md) command and its `type down` argument. Mouse moves to the coordinates specified by the `♥xyEnd` variable and its left button is depressed there (`type up` argument), thus selecting all objects within this region.