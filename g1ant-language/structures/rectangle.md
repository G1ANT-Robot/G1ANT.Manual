# rectangle

A rectangle format is designed to store co-ordinates of two rectangle's corners. It has to be specified as top left and bottom right corners' co-ordinates (in pixels): x1⫽y1⫽x2⫽y2. Where x1⫽y1 are the co-ordinates of top left corner and x2⫽y2 are the coordinates of bottom right corner.

**Example:**

This example shows how rectangles can be declared:

```G1ANT
♥rect = 2⫽4⫽12⫽40
```

Rectangles can also be easily inserted from Robot's Menu Insert -&gt; rectangle, or using shortcut `ctrl+r`
Rectangles' width, height and x,y coordinates of their top left corners can be accessed as follows:

```G1ANT
♥rect = 2⫽4⫽12⫽40
dialog ♥rect⟦width⟧
dialog ♥rect⟦height⟧
dialog ♥rect⟦left⟧
dialog ♥rect⟦top⟧
```

      

Width and height are lengths of rectangle's sides. G1ANT.Robot calculates the lengths on the basis of given points x1⫽y1 and x2⫽y2.
In order to get to the x1, y1, x2, y2, you need to use the formulas:

```G1ANT
x1 - ⟦left⟧
y1 - ⟦top⟧
x2 - ⟦right⟧
y2 - ⟦bottom⟧
```
