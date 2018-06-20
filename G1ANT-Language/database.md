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

*Standard Security*

```G1ANT
Server=myServerAddress;Database=myDataBase;User Id=myUsername;
Password=myPassword;
```

*Trusted Connection*

```G1ANT
Server=myServerAddress;Database=myDataBase;Trusted*Connection=True;
```

*Connection to a SQL Server instance*

```G1ANT
Server=myServerName\myInstanceName;Database=myDataBase;User Id=myUsername;
Password=myPassword;
```

*Trusted Connection from a CE device*

```G1ANT
Data Source=myServerAddress;Initial Catalog=myDataBase;Integrated Security=SSPI;
User ID=myDomain\myUsername;Password=myPassword;
```

*Connect via an IP address*

```G1ANT
Data Source=190.190.200.100,1433;Network Library=DBMSSOCN;
Initial Catalog=myDataBase;User ID=myUsername;Password=myPassword;
```

*Enable MARS*

```G1ANT
Server=myServerAddress;Database=myDataBase;Trusted*Connection=True;
MultipleActiveResultSets=true;
```

*Attach a database file on connect to a local SQL Server Express instance*

```G1ANT
Server=.\SQLExpress;AttachDbFilename=C:\MyFolder\MyDataFile.mdf;Database=dbname;
Trusted*Connection=Yes;
```

*Attach a database file, located in the data directory, on connect to a local SQL Server Express instance*

```G1ANT
Server=.\SQLExpress;AttachDbFilename=C:\MyFolder\MyDataFile.mdf;Database=dbname;
Trusted*Connection=Yes;
```

*Attach a database file, located in the data directory, on connect to a local SQL Server Express instance*

```G1ANT
Server=.\SQLExpress;AttachDbFilename=|DataDirectory|mydbfile.mdf;Database=dbname;
Trusted*Connection=Yes;
```

*LocalDB automatic instance*

```G1ANT
Server=(localdb)\v11.0;Integrated Security=true;
```

*LocalDB automatic instance with specific data file*

```G1ANT
Server=(localdb)\v11.0;Integrated Security=true;
AttachDbFileName=C:\MyFolder\MyData.mdf;
```

*LocalDB named instance*

```G1ANT
Server=(localdb)\MyInstance;Integrated Security=true;
```

*LocalDB named instance via the named pipes pipe name*

```G1ANT
Server=np:\\.\pipe\LOCALDB#F365A78E\tsql\query;
```

*LocalDB shared instance*

```G1ANT
Server=(localdb)\.\MyInstanceShare;Integrated Security=true;
```

*Database mirroring*

```G1ANT
Data Source=myServerAddress;Failover Partner=myMirrorServerAddress;
Initial Catalog=myDataBase;Integrated Security=True;
```

*Asynchronous processing*

```G1ANT
Server=myServerAddress;Database=myDataBase;Integrated Security=True;
Asynchronous Processing=True;
```

*Using an User Instance on a local SQL Server Express instance*

```G1ANT
Data Source=.\SQLExpress;Integrated Security=true;
AttachDbFilename=C:\MyFolder\MyDataFile.mdf;User Instance=true;
```

*Specifying packet size*

```G1ANT
Server=myServerAddress;Database=myDataBase;User ID=myUsername;
Password=myPassword;Trusted*Connection=False;Packet Size=4096;
```
