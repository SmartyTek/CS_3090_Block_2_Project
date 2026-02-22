// Written by Devin Ehlers for CS 3090, February 2026
// [Date: 2/20/2026]
namespace PasswordInputer;

using System;
using PasswordStrengthChecker;

/// <summary>
/// <para>
/// This class prompts the user to enter a password, upon doing so it will run it through an instance of
/// a custom PasswordStrengthChecker and inform the user of their password's strength.
/// </para>
/// </summary>
public class PasswordInputer
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Password Inputer");
        Console.WriteLine();
        Console.WriteLine("A password must have no white space and must be at least ten characters long.");
        Console.WriteLine();
        Console.WriteLine("Please input a Password:");

        string? password = Console.ReadLine();
        if (password == null) throw new ArgumentNullException(nameof(password));

        PasswordStrengthChecker passwordChecker = new PasswordStrengthChecker(password.Trim());
        
        passwordChecker.CheckStrength();
        Console.WriteLine($"Password strength: {passwordChecker.Strength}");
    }
}