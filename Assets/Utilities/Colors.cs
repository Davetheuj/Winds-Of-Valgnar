
using UnityEngine;

public class Colors 
{
    public static string cyan = "#40f5a6";
    public static string tan = "#ffeb91";
    public static string red = "#FF0000FF";
    public static string magenta = "#FF00FFFF";
    public static string gold = "#edda07FF";
    public static string UIGold = "#F5C33DFF";
    public static string UIGreen = "#4DD254FF";
    public static string UIRed = "#E01815FF";

    private static Color color; 

    public static Color AsUnityColor(string colorString) {
        ColorUtility.TryParseHtmlString(colorString, out color);
         return color;
    }
 }
