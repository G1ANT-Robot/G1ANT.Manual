# Triggering

This section describes all triggers which can be generated in specific circumstances (depending on a trigger) and can call user defined process.

Each entry of this section is described with the following principles:

## Initial Arguments

These are the parameters and arguments needed for a trigger to be called before running the script. In order to set them, you need to add trigger and set the arguments in the program's Settings window:

1. Select `Settings` from `Tools` menu.
2. In the resulting Settings window, navigate to `Triggers` item, right-click it and click `Add` in the context menu.
3. Now expand Triggers by clicking the arrow to its left. There will be a new item called `trigger1`. When you expand it, you will see its parameters and arguments explained below.

### Trigger Parameters

| Parameter  | Description                                                  |
| ---------- | ------------------------------------------------------------ |
| `Class`    | Describes the type of a trigger: `FileTrigger`, `ScheduleTrigger` or `MailTrigger` |
| `Name`     | A unique name to distinguish triggers from the same `Class`  |
| `TaskName` | Either a name of a robot script that we want to launch (with or without the file extension) or a full path to this robot script |

### An Argument Defining Trigger Initial Arguments

When you right-click `Arguments` item and select `Add`, a new initial argument appears. `Key` is the name of a trigger initial argument. The value of that trigger argument should be put in the `Value` field.

Note that some arguments are not required to be set, because they already have a default value.

### Alternative Approach

You can define triggers directly in program's `config` file, pasting xml code between `<Triggers>` … `</Triggers>`. For example:

```G1ANT
<Trigger Class="FileTrigger" Name="test" TaskName="C:\Users\a\Documents\G1ANT.Robot\test.robot">
	<Arguments>
		<Argument Key="Directory">C:\Users\a\Documents\G1ANT.Robot</Argument>
	</Arguments>
</Trigger> 
```

The location of the `config` file is displayed in the `File name:` box of the Settings window.

## Task Arguments

Task arguments are generated while executing the script. In order to get them, use a special variable `♥task` and insert the name of an argument inside special double brackets `⟦⟧`,
e.g. `♥task⟦filepath⟧`.

For the list of possible task or initial arguments, see the description of a specific trigger.

Note that in the Developer version of G1ANT.Robot triggers are not active when the program starts. If you want to use them, you have to activate them before launching the script. You can do this by choosing `Triggers/Active` menu in Robot window.

The Production version of G1ANT.Robot has triggers activated by default.

