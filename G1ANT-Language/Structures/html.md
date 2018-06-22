# html



HTML format stores values of imported html files.
A html file can be imported into Robot using "text.read":{TOPIC-LINK+command-text-read} command. It is imported as a string by default. It can be then converted to the **html** format, to enable various operations on the data.


**Example 1:**
This example shows how htmls can be declared:

```G1ANT
text.read filename ‴C:\html.txt‴ result ‴htmlString‴
♥myhtml = (html)♥htmlString
```

**Example 2:**
Different parts of the html can be accessed as follows:

```G1ANT
text.read filename ‴C:\html.txt‴ result ‴htmlString‴
♥myhtml = (html)♥htmlString
dialog ♥myhtml
dialog ♥myhtml⟦//body/table⟧
```

    

Not only can these parts be read, but also written:

```G1ANT
-now let's clear whole body of html:
♥myhtml⟦//body⟧ = ‴cleared‴ 
dialog ♥myhtml
 
 
```

Please note, that the root of file has to be addressed with a `/`, so before the html path `//` must be added.
