# Triggering

This section describes all triggers which can be generated in specific circumstances (depending on a trigger) and can call user defined process.

Each entry of this section is described with the following principles:

## Initial Arguments

These are the arguments needed for a trigger to be called before running the script. In order to set them, you need to open `Tools\Settings` and paste some xml code between `<Triggers>` … `</Triggers>`.

Note that some arguments are not required to be set, because they already have a default value.

### Example

```G1ANT
<Trigger Class="FileTrigger" Name="test" TaskName="C:\Users\a\Documents\G1ANT.Robot\test.robot">
	<Arguments>
		<Argument Key="Directory">C:\Users\a\Documents\G1ANT.Robot</Argument>
	</Arguments>
</Trigger> 
```

### Arguments to Define a Trigger

| Argument   | Description                                                  |
| ---------- | ------------------------------------------------------------ |
| `Class`    | Describes the type of a trigger: `FileTrigger`, `ScheduleTrigger` or `MailTrigger` |
| `Name`     | A unique name to distinguish triggers from the same `Class`  |
| `TaskName` | Either a name of a robot script that we want to launch (with or without the file extension) or a full path to this robot script |

### An Argument Defining Trigger Initial Arguments

`Key` is the name of a trigger initial argument. The value of that trigger argument should be put between `<Argument>` ... `</Argument>`.

## Task Arguments

Task arguments are generated while executing the script. In order to get them, use a special variable `♥task` and insert the name of an argument inside special double brackets `⟦⟧`,
e.g. `♥task⟦filepath⟧`.

For the list of possible task or initial arguments, see the description of a specific trigger.

Note that triggers are not active when G1ANT.Robot starts. Whenever you want to use them, you have to activate them before launching the script. You can do this by choosing `Triggers/Active` menu in Robot window.

