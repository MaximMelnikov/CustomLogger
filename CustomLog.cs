using System;
using System.Reflection;

public static class CustomLog
{
    public static void Log(this Object obj, string message) 
    {
        var attribute = obj.GetType().GetCustomAttribute<CustomLogAttribute>();
        if (attribute == null)
        {
            UnityEngine.Debug.Log(message);
            return;
        }

        if (!string.IsNullOrEmpty(attribute.switcherVariableName)
            && attribute.IsSwitcherOn(obj))
        {
            UnityEngine.Debug.Log(message);
            return;
        }

        foreach (var item in attribute.tags)
        {
            if (CustomLoggerSettings.GetTagValue(item))
            {
                UnityEngine.Debug.Log(message);
                break;
            }
        }
    }
}
