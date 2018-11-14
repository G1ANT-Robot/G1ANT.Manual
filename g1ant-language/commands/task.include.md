# task.include

**Syntax:**

```G1ANT
task.include filepath ‴‴
```

**Description:**

Command `task.include` allows to include a script from different task located on disk. The script will be populated in the place where command task.include is called. The full directory path can be passed or just the filename - the command by default tries to find the filename in the folder %currentuser%/My Documents/G1ANT.Robot. Please note that all lines from the script will be imported, so if there is something more than just procedures it will be executed in the current script.

| Name | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`filepath`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | yes |  | file path or filename if it's in G1ANT.Robot folder |

**Example 1:**
Procedure from different file can be added to use in current script.

```G1ANT
task.include ‴_aforprocedure.robot‴
dialog ‴Do something using the procedure from external robot file‴
jump ⏭forloop start 0 end 3
```

Content of the file _aforprocedure.robot

```G1ANT
procedure ⏭forloop start 0 end 1
    ♥loopindex = ♥start
    jump ‴➜startforloop‴
    ➜startforloop
    dialog ♥loopindex
    ♥loopindex = ♥loopindex + 1
    jump ‴➜startforloop‴ if ⊂♥loopindex &lt; ♥end⊃
end
```
