# Label

**Syntax:**

```G1ANT
➜label

```

**Description:**

`➜` **labelname** defines a label element. This is the place where the script will start executing if you ask them to jump ➜labelname. It is available at G1ANT Developer Studio -&gt; Insert -&gt; Label


**Example 1:**

```G1ANT
jump ‴➜start‴
dialog ‴Jump over this text‴
➜start 
dialog ‴Congratulations! You've made a jump to start label!‴ 

```
