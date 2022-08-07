using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
class CustomLogAttribute : Attribute
{
    public string[] tags;
    public string switcherVariableName;
    private FieldInfo switcherFieldInfo;
    
    public bool IsSwitcherOn(object obj)
    {
        if (switcherFieldInfo == null && !string.IsNullOrEmpty(switcherVariableName))
        {
            switcherFieldInfo = obj.GetType().GetField(switcherVariableName);
        }

        if (switcherFieldInfo != null && (!(switcherFieldInfo.GetValue(obj) is bool value) || value == false))
        {
            return false;
        }
        return true;
    }

    public CustomLogAttribute()
    {
    }

    public CustomLogAttribute(string tag)
    {
        tags = new string[] { tag };
    }

    public CustomLogAttribute(string tag1, string tag2)
    {
        tags = new string[] { tag1, tag2 };
    }
    public CustomLogAttribute(string tag1, string tag2, string tag3)
    {
        tags = new string[] { tag1, tag2, tag3 };
    }
}
