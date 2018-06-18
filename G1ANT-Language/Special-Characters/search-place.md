# Search place

**Syntax:**

```G1ANT
✱part of text✱
```

**Description:**

`✱` **Search place** is used within the text.find command to specify location for text search. If only part of the text to find is known, or you wish to find ANYTHING in the text, this special character shall highlight the ANYTHING. 
Example use in commands "Text find":{TOPIC-LINK+command-text-find} , window "window":{TOPIC-LINK+command-window} or "waitfor.window":{TOPIC-LINK+command-waitfor-window}



**Example 1:**

```G1ANT
♥source = ‴Name: John Surname: Smith‴
text.find ♥source search Name:✱Surname: result ♥name
dialog ♥name
```

 

**Example 2:**

```G1ANT
♥source = ‴Name: John Surname: Smith Name: Alfred Surname: Smith‴
text.find ♥source search Name:✱Surname: result ♥name
dialog ♥name
```

Here result is an array of names. More info of arrays at "this topic":{TOPIC-LINK+array-separator}. 

 

**Example 3:**

```G1ANT
♥source = ‴Name: John Surname: Smith Name: Alfred Surname: Smith‴
text.find ♥source search Name:✱Surname: result ♥name
dialog ♥name[2]
```


