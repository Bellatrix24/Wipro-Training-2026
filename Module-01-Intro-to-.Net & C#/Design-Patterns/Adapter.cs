using System;

// 1. The Target Interface (What the client expects)
public interface ITypeCDevice
{
    void ConnectViaTypeC();
}

// 2. The Adaptee (The old/existing device that doesn't fit)
public class UsbPendrive
{
    public void ConnectViaUsbA()
    {
        Console.WriteLine("USB-A Pendrive connected successfully via legacy port.");
    }
}

// 3. The Adapter (The bridge that converts USB-A to Type-C)
public class OtgAdapter : ITypeCDevice
{
    private readonly UsbPendrive _pendrive;

    public OtgAdapter(UsbPendrive pendrive)
    {
        _pendrive = pendrive;
    }

    public void ConnectViaTypeC()
    {
        Console.WriteLine("OTG Adapter is converting Type-C signal to USB-A...");
        _pendrive.ConnectViaUsbA();
    }
}

// 4. The Client (How you use it in your Program)
class Program
{
    static void Main()
    {
        // We have an old USB-A Pendrive
        UsbPendrive myOldPendrive = new UsbPendrive();

        // We can't plug it into a Type-C port directly.
        // So, we wrap it in the Adapter.
        ITypeCDevice myOtgAdapter = new OtgAdapter(myOldPendrive);

        // Now we can call the Type-C method, and it works!
        myOtgAdapter.ConnectViaTypeC();
    }
}
