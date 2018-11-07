# File Trigger

File Trigger monitors files in the specified folder and provides information whether they were changed, deleted, renamed or there are some new created files.

**Initial Arguments**

| Trigger Argument | Required | Default value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
| `Directory` | yes | - | path of the directory to monitor |
| `Filter` | no |  `**.**` | determines what files are monitored in a directory, all files are watched by default - `**.**` |
| `AddExistingFilesAtStart` | no | false | determines whether all initially existing files will be triggered or not |

**Task Arguments**

Arguments generated while executing the script for each of the file in the monitored folder.

| Trigger Argument | Description |
| -------- | ---- | -------- | ------------- | ----------- |
| `FilePath` | path to a file in the monitored folder |
| `FileName` | name of the file (with the extension format) |
| `FileNameWithoutExtension` | name of the file (without extension format) |
| `ChangeType` | information about the type of change that appeared in a file (created, changed, deleted or renamed) |
| `OldFilePath` | path to the file that has been changed somehow |

**Example of defining File Trigger in Settings**

```G1ANT
&lt;Trigger Class="FileTrigger" Name="test" TaskName="C:\Users\a\Documents\G1ANT.Robot\test.robot"&gt;
	&lt;Arguments&gt;
		&lt;Argument Key="Directory"&gt;C:\Users\a\Documents\G1ANT.Robot&lt;/Argument&gt;
	&lt;/Arguments&gt;
&lt;/Trigger&gt; 
```

**Example**

```G1ANT
dialog ♥taks⟦filepath⟧
dialog ♥taks⟦changetype⟧
```

  
