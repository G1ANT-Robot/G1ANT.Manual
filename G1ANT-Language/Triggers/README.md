# Triggering

Section triggering describes all the triggers which can be generated in specific circumstances (depending on the trigger) and can call user defined process.
Each entry of this section should be defined as below.

## Initial Arguments

Arguments needed for a trigger to be called before running the script. In order to set them, you need to open `Tools\Settings` and paste some xml code between @<Triggers>@ … @</Triggers>@.
Note that some possible arguments are not required to be set because they already have a default value. 

!{IMAGE-LINK+g1ant-robot-2018-03-14-10-07-55}! 

**Example:**

bc. <Trigger Class="FileTrigger" Name="test" TaskName="C:\Users\a\Documents\G1ANT.Robot\test.robot">
	<Arguments>
		<Argument Key="Directory">C:\Users\a\Documents\G1ANT.Robot</Argument>
	</Arguments>
</Trigger>  

*Arguments to define a trigger:*
@Class@ - describes what type of trigger it is (possible: FileTrigger, ScheduleTrigger, MailTrigger)
@Name@ - unique name declared to distinguish triggers from the same Class
@TaskName@ - either a name of a robot script without extension that we want to launch, name of it with extension or just a path to this robot script

*Argument to define trigger initial arguments:*
@Key@ - name of a trigger initial argument, value of that trigger argument should be put between @<Argument>@ ... @</Argument>@.


h3. Task Arguments

Arguments generated while executing the script. In order to get them, use special variable @♥task@ and inside these special rectangle characters @⟦⟧@ insert the name of an argument.
e.g. @♥task⟦filepath⟧@

For the list of possible task or initial arguments, please visit manual page regarding a specific trigger.

Note that triggers are not active at the start of G1ANT.Robot. Whenever we want to use them, the triggersactive option must be switched on before launching the script. You can do this by choosing @Triggers/Active@ from the Menu in Robot.

!{IMAGE-LINK+g1ant-robot-withaddons-3-125-18060-1600-2018-03-14-16-34-13}! 
