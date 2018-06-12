# xml

Xml format stores values of imported xmlfiles. An xml file can be imported into Robot using "text.read":{TOPIC-LINK+command-text-read} command. It is imported as a string by default. It can be then converted to the **xml** format, to enable various operations on the data.


**Example 1:**

This example shows how xmls can be declared:

```G1ANT
text.read filename ‴C:\Users\zuzan\Desktop\xml\xml.txt‴ result ‴xmlString‴
♥myxml = (xml)♥xmlString

```

**Example 2:**

Different parts of the xml can be accessed as follows:

```G1ANT
text.read filename ‴C:\xml.txt‴ result ‴xmlString‴
dialog ♥xmlString
♥myxml = (xml)♥xmlString
dialog ♥myxml⟦/CATALOG/PLANT[3]/PRICE⟧

```

Not only can these parts be read, but also written:

```G1ANT
♥myxml⟦/CATALOG/PLANT[3]/COST⟧ = ‴$9‴
dialog ♥myxml

```

Please note, that conversion to xml disturbs formatting for display purposes.
