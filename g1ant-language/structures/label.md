# Label

**Syntax:**

```G1ANT
➜label
```

**Description:**

`➜` **labelname** defines a label element. This is the place where the script will start executing if you ask them to jump ➜labelname. It is available at G1ANT Developer Studio -> Insert -> Label

See also : "Commands - label":{TOPIC-LINK+command-labels}
See also : "Commands - jump":{TOPIC-LINK+command-jump}

Example:

```G1ANT
jump ‴➜start‴
dialog ‴Jump over this text‴
➜start
dialog ‴Congratulations! You've made a jump to start label!‴
```

