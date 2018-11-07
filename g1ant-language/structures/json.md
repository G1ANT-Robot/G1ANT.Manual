# json

Json format stores values of imported json files.
A json file can be imported into G1ANT.Robot using "text.read":{TOPIC-LINK+command-text-read} command. It is imported as a string by default. It can be then converted to the **json** format, to enable various operations on the data.

**Example 1:**
This example shows how jsons can be declared:

```G1ANT
text.read filename ‴C:\json.txt‴ result ‴jsonString‴
♥myjson = ⟦json⟧♥jsonString
```

**Example 2:**
Different parts of the json can be accessed as follows:

```G1ANT
text.read filename ‴C:\json.txt‴ result ‴jsonString‴
dialog ♥jsonString
♥myjson = ⟦json⟧♥jsonString
dialog ♥myjson⟦widget.image.name⟧
```  

Not only can these parts be read, but also written:

```G1ANT
♥myjson⟦widget.image.name⟧ = ‴moon1‴
dialog ♥myjson⟦widget.image.name⟧
```

Please note, that there is no way to write directly to the core (here: widget.). The core is allowed to be read only.
