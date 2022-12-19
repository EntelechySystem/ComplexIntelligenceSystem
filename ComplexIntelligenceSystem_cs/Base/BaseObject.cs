namespace CIS.Base;

using System;

public class BaseObject
{
    ///
    /// 基本对象类
    /// 
    string TypeName { get; set; }

    Guid Id { get; set; }
    string UidString { get; set; }

    public BaseObject()
    {
        TypeName = "base object type";
        Id = Guid.NewGuid();
        UidString = "str: " + Id.ToString();
    }
}