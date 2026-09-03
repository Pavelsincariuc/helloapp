abstract class Notification

{
    public abstract void Send(string message);
    public string user;
}
class EmailNotification: Notification
{
    
    public EmailNotification(string user)
    {
        this.user = user;
    }

    public override void Send(string message)
    {
        Console.WriteLine($"Отправка Email на {user}: {message} ");
    }
    
}
class SmsNotification: Notification
{
    public SmsNotification(string user)
    {
        this.user = user;
    }

    public override void Send(string message)
    {
        if (message.Length > 100)
        {
            Console.WriteLine("Сообщение не может быть больше 100 символов");
            
            
        }
        else
        {
            Console.WriteLine($"Сообщение {message} отправлено на номер: {user}");
        }

    }
}

