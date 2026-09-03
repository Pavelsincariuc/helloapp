using System;

public class Person
{
    private string _firstName;
    private string _lastName;
    private int _age;

    public string FirstName
    {
        get => _firstName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Имя не может быть null, пустым или состоять из пробелов.", nameof(FirstName));
            }
            _firstName = value;
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Фамилия не может быть null, пустой или состоять из пробелов.", nameof(LastName));
            }
            _lastName = value;
        }
    }

    public int Age
    {
        get => _age;
        set
        {
            if (value < 0 || value > 150)
            {
                throw new ArgumentOutOfRangeException(nameof(Age), "Возраст должен быть в диапазоне от 0 до 150.");
            }
            _age = value;
        }
    }

    
    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
}