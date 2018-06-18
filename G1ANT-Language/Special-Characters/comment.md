# Comment

**Syntax:**

```G1ANT
-keyboard ‴text2‴⋘enter⋙
```

**Description:**

`-` **Comment** [Use to add a comment]

G1ANT.Robot has a built-in comments feature, meaning we can comment out certain lines of code and G1ANT.Robot will not execute them while reading the srcipt line by line. Or we can simply "turn off" chosen script line. Please see the example below.

Example:

```G1ANT
program name ‴notepad‴
keyboard ‴text1‴⋘enter⋙
-The line below will not be executed.
-keyboard ‴text2‴⋘enter⋙
keyboard ‴text3‴⋘enter⋙
```

In this example you can see what happens in G1ANT.Robot window when lines of comments are typed starting with "-". 
The first commented out line of script is a simple text: `-The line below will not be executed.`.
The other commented out script line is some command `-keyboard ‴text2‴⋘enter⋙` that would perform an action if it wasn't commented out.


