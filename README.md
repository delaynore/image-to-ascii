# AsciiImage
This is a library that allows you to easily convert any image into an image containing only ascii characters from an alphabet you can define.

## How to convert
```csharp
var path = "your path here";
var image = new Bitmap(path); // first we need to create a bitmap
// now we need to create an instance of the AsciiImageConverter class, for converting
// for now we use default ascii alphabet (gradient)
var converter = new AsciiImageConverter(bitmap, Gradient.Default);
// Now we just need to call the GetAsciiImage() method and get the char[][] containing the image
var image = converter.GetAsciiImage();
```
## How to create Gradient
To control the creation of your own gradient there is the `IGradient` interface
```csharp
public interface IGradient
{
    public string Alphabet { get;  }

    public Range GetRange()
    {
        return new Range(0, Alphabet.Length - 1);
    }

    public char this[int i]
    {
        get { return Alphabet[i]; }
    }
}
```
And now let's just create a class that implements this interface
```csharp
public class MyGradient : IGradient
{
    public string Alphabet => "my characters here";
}
```
For simplicity of gradient creation there is a class, with follows static methods:
```csharp
public class Gradient : IGradient
{
    private const string _default = @" .:!/r(l1Z4H9W8$@\";
    private static readonly string _defaultReversed = string.Join("", _default.Reverse());
    
    public static Gradient Default => new(_default);
    
    public static Gradient WhiteTheme => new(_defaultReversed);
    
    public static Gradient BlackTheme => Default;

    public static Gradient Make(string aplhabet) => new Gradient(aplhabet);
}
```
Also for simplicity of creating pictures in the AsciiImageConverter class there are the following static methods:
```csharp
public class AsciiImageConverter
{
    ...

    public static char[][] Convert(Bitmap bitmap, IGradient gradient)
    {
        return new AsciiImageConverter(bitmap, gradient).GetAsciiImage();
    }

    public static char[][] Convert(Bitmap bitmap)
    {
        return new AsciiImageConverter(bitmap, AsciiImage.Gradient.Default).GetAsciiImage();
    }
}
```
