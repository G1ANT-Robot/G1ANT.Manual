# Mail Trigger 

Mail Trigger provides information about incoming emails.

## Initial Arguments

| Trigger Argument | Required | Default value | Description |
| ---------------- | -------- | ------------- | ----------- |
| `Host` | yes | - | imap server address |
| `Login` | yes | - | login (e.g. email address) from which there will be sent emails |
| `Password` | yes | - | password for this email address |
| `FrequencY` | no | 30000 | time set between updating information about incoming emails (in milliseconds) |
| `Port` | yes | - | incoming mail server port |

## Task Arguments

Arguments generated while executing the script for each of the incoming email.

| Trigger Argument | Description |
| ---------------- | ----------- |
| `Title` | title of an incoming mail |
| `AttachmentNames` | list of attachments in an incoming mail |
| `Content` | incoming mail content (text) |
| `From` | sender email address |
| `To` | recipient email address |
| `HtmlBody` | incoming email content (html) |
| `Uid` | unique identifier of a mail given by a server |
| `Date` | date sent |
| `Priority` | priority set by a sender |

**Example of defining File Trigger in Settings**

```G1ANT
<Trigger Class="MailTrigger" Name="test" TaskName="C:\Users\a\Documents\G1ANT.Robot\test.robot">
	<Arguments>
		<Argument Key="Host">imap.gmail.com</Argument>
		<Argument Key="Login">example@example.com</Argument>
		<Argument Key="Password">example123</Argument>
		<Argument Key="Frequency">300000</Argument>
		<Argument Key="Port">993</Argument>
	</Arguments>
</Trigger>
```

**Example:**

```G1ANT
dialog ♥taks⟦title⟧
dialog ♥taks⟦to⟧
```
