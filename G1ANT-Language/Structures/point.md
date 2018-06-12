# point

**point (point)**

A point format stores values of position. It is specified in pixels: x,y.

**Examples:**

This example shows how points can be declared:

```G1ANT
♥pnt = 935⫽580
```

Mouse position is also stored in point format. It can be easily inserted from G1ANT.Robot's Menu Insert -&gt; mouse position, or using shortcut `ctrl+e`.

Point's coordinates can be accessed as follows:

```G1ANT
♥pnt = 935⫽580
dialog ♥pnt⟦x⟧
dialog ♥pnt⟦y⟧
```

!{IMAGE-LINK+point-1}!   !{IMAGE-LINK+point-2}! 

```G1ANT
♥pnt = 935⫽580
♥pnt⟦x⟧=800
dialog ♥pnt
```

!{IMAGE-LINK+point-3}!