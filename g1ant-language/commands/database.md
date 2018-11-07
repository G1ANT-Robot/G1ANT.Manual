# database

**Syntax:**

```G1ANT
database  connection ‴‴
```

**Description:**

Command `database` allows to establish connection with SQL database. If command succeeds, all `sql` commands will be executed on established database connection. See also: "sql":{TOPIC-LINK+command-sql}}.

| Argument | Type | Required | Default Value | Description |
| -------- | ---- | -------- | ------------- | ----------- |
|`connection`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | yes |  | connection string to establish database connection (see below) |
|`if`| [bool](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/bool.md) | no | true | runs the command only if condition is true |
|`timeout`| [variable](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Special-Characters/variable.md) | no | [♥timeoutdb](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Variables/Special-Variables.md) | specifies number of milliseconds to wait for a connection|
|`errormessage`| [string](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/string.md) | no | | message that will be shown in case error occurs and no `errorjump` argument is specified |
|`errorjump`| [label](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Structures/label.md) | no |  | name of the label to jump to if given `timeout` expires |

For more information about `if`, `timeout`, `errorjump` and `errormessage` arguments, please visit [Common Arguments](https://github.com/G1ANT-Robot/G1ANT.Manual/blob/master/G1ANT-Language/Common-Arguments.md)  manual page.

This command is contained in **G1ANT.Language.dll.**

**Example:**

```G1ANT
database ‴Server=myServerAddress;Database=myDataBase;User Id=myUsername;
Password=myPassword;‴
```

**Connection strings description:**

_Standard Security_

```G1ANT
Server=myServerAddress;Database=myDataBase;User Id=myUsername;
Password=myPassword;
```

_Trusted Connection_

```G1ANT
Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;
```

_Connection to a SQL Server instance_

```G1ANT
Server=myServerName\myInstanceName;Database=myDataBase;User Id=myUsername;
Password=myPassword;
```

_Trusted Connection from a CE device_

```G1ANT
Data Source=myServerAddress;Initial Catalog=myDataBase;Integrated Security=SSPI;
User ID=myDomain\myUsername;Password=myPassword;
```

_Connect via an IP address_

```G1ANT
Data Source=190.190.200.100,1433;Network Library=DBMSSOCN;
Initial Catalog=myDataBase;User ID=myUsername;Password=myPassword;
```

_Enable MARS_

```G1ANT
Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;
MultipleActiveResultSets=true;
```

_Attach a database file on connect to a local SQL Server Express instance_

```G1ANT
Server=.\SQLExpress;AttachDbFilename=C:\MyFolder\MyDataFile.mdf;Database=dbname;
Trusted_Connection=Yes;
```

_Attach a database file, located in the data directory, on connect to a local SQL Server Express instance_

```G1ANT
Server=.\SQLExpress;AttachDbFilename=C:\MyFolder\MyDataFile.mdf;Database=dbname;
Trusted_Connection=Yes;
```

_Attach a database file, located in the data directory, on connect to a local SQL Server Express instance_

```G1ANT
Server=.\SQLExpress;AttachDbFilename=|DataDirectory|mydbfile.mdf;Database=dbname;
Trusted_Connection=Yes;
```

_LocalDB automatic instance_

```G1ANT
Server=(localdb)\v11.0;Integrated Security=true;
```

_LocalDB automatic instance with specific data file_

```G1ANT
Server=(localdb)\v11.0;Integrated Security=true;
AttachDbFileName=C:\MyFolder\MyData.mdf;
```

_LocalDB named instance_

```G1ANT
Server=(localdb)\MyInstance;Integrated Security=true;
```

_LocalDB named instance via the named pipes pipe name_

```G1ANT
Server=np:\\.\pipe\LOCALDB#F365A78E\tsql\query;
```

_LocalDB shared instance_

```G1ANT
Server=(localdb)\.\MyInstanceShare;Integrated Security=true;
```

_Database mirroring_

```G1ANT
Data Source=myServerAddress;Failover Partner=myMirrorServerAddress;
Initial Catalog=myDataBase;Integrated Security=True;
```

_Asynchronous processing_

```G1ANT
Server=myServerAddress;Database=myDataBase;Integrated Security=True;
Asynchronous Processing=True;
```

_Using an User Instance on a local SQL Server Express instance_

```G1ANT
Data Source=.\SQLExpress;Integrated Security=true;
AttachDbFilename=C:\MyFolder\MyDataFile.mdf;User Instance=true;
```

_Specifying packet size_

```G1ANT
Server=myServerAddress;Database=myDataBase;User ID=myUsername;
Password=myPassword;Trusted_Connection=False;Packet Size=4096;
```
