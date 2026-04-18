interface INotification
{
    void Send();
}

interface INotificationFactory
{
    INotification CreateFirstType();
    INotification CreateSecondType();
}


//создание отдельного уведомления

class PushNotification : INotification
{
    public void Send() => Console.WriteLine("Push отправлен");
}

class SMSNotification : INotification
{
    public void Send() => Console.WriteLine("SMS отправлен");
}

class BrowserNotification : INotification
{
    public void Send() => Console.WriteLine("Browser notification отправлен");
}

class EmailNotification : INotification
{
    public void Send() => Console.WriteLine("Email отправлен");
}


class SystemTrayNotification : INotification
{
    public void Send() => Console.WriteLine("System tray отправлен");
}

class ToastNotification : INotification
{
    public void Send() => Console.WriteLine("Toast отправлен");
}

//для каждой фабрики свои уведомления
class MobileFactory : INotificationFactory
{
    public INotification CreateFirstType() => new PushNotification();
    public INotification CreateSecondType() => new SMSNotification();
}

class WebFactory : INotificationFactory
{
    public INotification CreateFirstType() => new BrowserNotification();
    public INotification CreateSecondType() => new EmailNotification();
}

class DesktopFactory : INotificationFactory
{
    public INotification CreateFirstType() => new SystemTrayNotification();
    public INotification CreateSecondType() => new ToastNotification();
}


//абстрактная фабрика
INotificationFactory creator = new MobileFactory(); // мобильные уведы
INotification push = creator.CreateFirstType();
INotification sms = creator.CreateSecondType();

creator = new WebFactory(); // веб уведы
INotification browser = creator.CreateFirstType();
INotification email = creator.CreateSecondType();

creator = new DesktopFactory(); //десктоп уведы
INotification systemTray = creator.CreateFirstType();
INotification toast = creator.CreateSecondType();

push.Send();
sms.Send();
browser.Send();
email.Send();
systemTray.Send();
toast.Send();










