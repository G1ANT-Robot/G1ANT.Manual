# Schedule Trigger 

Schedule trigger launches tasks at some specified time. 

## Initial Arguments

| Trigger Argument | Required | Default value | Description |
| ---------------- | -------- | ------------- | ----------- |
| `CrontabExpression` | yes | - | time specified for the trigger to be called at (for more information about setting this crontab argument, please visit [Crontab](https://crontab.guru/) website) |

## Task Arguments

| Trigger Argument | Description |
| ---------------- | ----------- |
| `Time` | time within the trigger performed some action |


**Example of defining Schedule Trigger in Settings**

```G1ANT
<Trigger Class="ScheduleTrigger" Name="test" TaskName="C:\Users\a\Documents\G1ANT.Robot\test.robot">
	<Arguments>
		<Argument Key="CrontabExpression">5 4 * * *</Argument>
	</Arguments>
</Trigger>
```
