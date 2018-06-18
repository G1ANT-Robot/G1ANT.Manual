# Creating New Variables

We can declare a variable any time we want to store some data inside of it. It is very useful to assign information, like text, numbers, list elements to a variable while using G1ANT.Robot, because variables- once declared can be reused in the script while being referred to with *♥variablename*. It saves a lot of space while writing a script.

**Syntax:**

`♥variablename = .........`

`♥age = 123`

`♥mybday = ⟦date⟧‴8/07/1995‴`


**Naming variables:**

Variable name must begin with variable symbol `♥` followed by the name of a variable, it must consist of letters or letters and digits.

Anti- example 

@♥2 = ‴123‴@

You could declare a variable by just typing ♥2 - giving it a very short name - '2'. But better not do it this way. Please note that a variable is supposed to make your workflow faster, easier and clearer. Therefore always try to give some meaningful names for variables, so that later you know what it signifies.


*Declaring variables:*

The way of declaring a variable depends on value that it will store. 
The possible types of values can be simple variables: 
number ("integer":{TOPIC-LINK+integer} , "double":{TOPIC-LINK+decimal}, "point":{TOPIC-LINK+point}, "rectangle":{TOPIC-LINK+rectangle}) ,
"string":{TOPIC-LINK+string}, 
"boolean":{TOPIC-LINK+boolean} 


or complex types that expect special way of declaring:
"date":{TOPIC-LINK+date}, 
"datetime":{TOPIC-LINK+datetime}, 
"time":{TOPIC-LINK+time},
"json":{TOPIC-LINK+json},
"html":{TOPIC-LINK+html},
"xml":{TOPIC-LINK+xml}

*Examples:*

*Example 1*

Declaring a variable, which stores a *number*. 

"integer":{TOPIC-LINK+integer} 

bc. ♥age = 123

bc. ♥sum = 12 + 3
dialog ♥sum

"float":{TOPIC-LINK+decimal} 

bc. ♥length = 12.55

"point":{TOPIC-LINK+point}

bc. ♥pnt = 935⫽580

"rectangle":{TOPIC-LINK+rectangle}

bc. ♥rectangle = 8⫽12⫽12⫽8 


Please, do not use ‴ ‴ if you are assigning any number (integer, float, decimal, point, rectangle)  to a variable. 
‴ ‴ are reserved for strings and are not necessary while assigning numbers to variables.

*Example 2*

Declaring a variable, which stores a *date*, *time* or *datetime* expects that you declare a type. Please, see examples below.

"date":{TOPIC-LINK+date}

bc. ♥mybday = ⟦date⟧‴8/07/1995‴

"datetime":{TOPIC-LINK+datetime}

bc. ♥exam_start = ⟦datetime⟧‴10/05/2017 12:4:8‴

"time":{TOPIC-LINK+time}

bc. ♥mytime2 = ⟦time⟧‴10:30:11‴

*Example 3*

Declaring a variable, which stores a *json*, *html* or *xml* expects that you declare a type. Please, see examples below.

"json":{TOPIC-LINK+json}

In this example while we are importing json from some external file using @text.read@ command and assigning the file to a variable- ♥jsonString, it is a string. In order to convert the string into a json element, we need to use this fragment of script: @♥myjson = ⟦json⟧♥jsonString@ where we are forcing the type of the variable's ♥jsonString content using @⟦json⟧@ formula in the beginning.

bc. text.read filename ‴C:\json.txt‴ result ♥jsonString
♥myjson = ⟦json⟧♥jsonString

In the case below we are assigning a json into a variable. Then  we need to remember about ‴ ‴: 
@♥json =  ⟦json⟧‴ ‴@  

bc. ♥json =  ⟦json⟧‴{'channel': {'title': 'Star Wars', 'link': 'http://www.starwars.com','description': 'Star Wars blog.','obsolete': 'Obsolete value','item': []}}‴


"html":{TOPIC-LINK+html}

The same rules as in json apply here in html.

bc. text.read filename ‴C:\html.txt‴ result ♥htmlString
♥newhtml = ⟦json⟧♥htmlString

bc. ♥html = ⟦html⟧‴<html><head>This is the title<div>The content of a div</div></head><body></body></html>‴

"xml":{TOPIC-LINK+xml}

And also in xml.

bc. text.read filename ‴C:\Users\zuzan\Desktop\xml\xml.txt‴ result ♥xmlString
♥myxml = ⟦xml⟧♥xmlString

bc. ♥xml = ⟦xml⟧‴ ‴

*Example 4*

Declaring a variable, which stores a "string":{TOPIC-LINK+string}. Always use ‴ ‴ when assigning strings to variables. 

bc. ♥name = ‴forrest‴

*Example 5*

Declaring a variable, which stores a "boolean":{TOPIC-LINK+boolean} - true/false value.

bc. ♥var = true

*Example 6*

Declaring "lists":{TOPIC-LINK+list} 

In G1ANT.Robot lists can be of one type only.  If you are dealing with any list, you need to remember about forcing the type of the list in the beginning, like ⟦list:date⟧, ⟦list:datetime⟧, ⟦list:time⟧. It will determine whether it will be a list of strings, numbers, bools, etc. Depending on what type of values the list consists of, we either have to or do not have to use ‴ ‴. 

@♥shopping_list = ⟦list:text⟧‴lemon‴❚‴banana‴❚‴milk‴❚‴almonds‴@ Simple list of strings.

@♥mailing_list = ⟦list:text⟧‴Victor‴❚‴Diana‴❚‴Anna‴❚‴Ahmed‴❚123@ In this example the number at the end of the list will be understood as string, because we are forcing the type of the list in the beginning of the list using @⟦list:text⟧@ formula.

@♥timing_list = ⟦list:float⟧767.32❚356❚291.555❚433❚123@ List with numbers, if any of them are "float":{TOPIC-LINK+decimal}, you need to declare the list as a list of floats - @⟦list:float⟧@

@♥list_of_dates = ⟦list:date⟧‴3/12/2911‴❚‴4/2/1988‴❚‴12/12/2012‴@ List of dates

@♥children_birthdays = ⟦list:datetime⟧‴13/01/2017 11:44:8‴❚‴02/11/2018 15:20:15‴❚‴23/12/1993 11:20:15‴@ List of datetimes

@♥my_times = ⟦list:time⟧‴10:30:11‴❚‴2:24:19‴❚‴1:23:55‴@ List of times






