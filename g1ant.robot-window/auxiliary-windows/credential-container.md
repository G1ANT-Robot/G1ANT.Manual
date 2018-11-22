# Credential Container

The Credential Container stores keys (eg. user IDs, logins etc.) and their corresponding values such as passwords. It is available from `Tools | Credential Container` menu.

To add a new credential, click Add in the Credential Container window and enter key and its value in the resulting Credential window. The key must be provided in the `ContainerName:key` format:

![](/G1ANT.Manual/.gitbook/assets/credential-container.png)

To read the value of a key, enter the name of this key within the `♥credential` special variable brackets:

```G1ANT
♥credential⟦wiktoria:mail⟧
```

