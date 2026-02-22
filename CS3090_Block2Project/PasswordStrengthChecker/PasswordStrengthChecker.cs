// Written by Devin Ehlers for CS 3090, February 2026
// [Date: 2/20/2026]
namespace PasswordStrengthChecker;

/// <summary>
/// <para>
/// An instance of this class will take a password as a string parameter and store it as a private
/// instance variable. Using the CheckStrength method will set the Strength instance variable to either
/// "Sufficient" or "Insufficient" depending on the password. 
/// </para>
/// <para>
/// A password must have no whitespace and be at least ten characters long. For a password's strength
/// to be sufficient a quarter must be filled with numbers and another quarter must be made out of some
/// non-letter and non-number characters.
/// </para>
/// </summary>
public class PasswordStrengthChecker
{
    //Publicly read only.
    public string Strength { get; private set; }
    //For storing the given password, immutable.
    private string Password { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PasswordStrengthChecker"/> class.
    /// </summary>
    /// <param name="password">
    /// The password passed to and stored by the instance.
    /// </param>
    public PasswordStrengthChecker(string password)
    {
        Strength = "Unknown";
        Password = password;
    }

    /// <summary>
    /// Private helper method used in CheckStrength. Given a character, the method will assign
    /// and return a string description of the character's type. There are four types being:
    /// "NUMBER", "SYMBOL", "LETTER", and "UNUSUAL".
    /// </summary>
    /// <param name="character">
    /// The character to be analyzed.
    /// </param>
    /// <returns>
    /// A string representation of the object's type.
    /// </returns>
    /// <exception cref="WhiteSpaceException">
    /// If the character is whitespace, an exception will be thrown.
    /// </exception>
    private string GetType(char character)
    {
        if (Char.IsDigit(character))
            return "NUMBER";
        if (Char.IsPunctuation(character))
            return "SYMBOL";
        if (Char.IsLetter(character))
            return "LETTER";
        if (Char.IsWhiteSpace(character))
            throw new WhiteSpaceException("Whitespace is not allowed in the password!");

        return "UNUSUAL";
    }

    /// <summary>
    /// This method defines and enforces the class' password rules. When used on an instance of the class
    /// it will change the password's strength to be "Sufficient" or "Insufficient". The rules by which a
    /// password is judged are as follows: A password must be one continuous string. A password's length must
    /// be at least ten characters long. Other than letters, a password SHOULD be made out of at least a quarter
    /// numbers followed by another quarter of non-letter and non-number characters.
    /// </summary>
    /// <exception cref="MinimumPasswordLengthException"></exception>
    public void CheckStrength()
    {
        if (Password.Length < 10)
            throw new MinimumPasswordLengthException("Minimum required length for a password is 10 characters!");

        int numberCount = 0;
        int symbolCount = 0;
        int unusualCount = 0;
        
        foreach (char character in Password)
        {
            string charType =  GetType(character);
            
            if (charType is "NUMBER")
                numberCount++;
            if (charType is "SYMBOL")
                symbolCount++;
            if (charType is "UNUSUAL")
                unusualCount++;
        }

        if (numberCount >= Password.Length / 4 && (symbolCount >= Password.Length / 4 ||
                                                     unusualCount >= Password.Length / 4))
            Strength = "Sufficient";
        else
            Strength = "Insufficient";

    }
}


public class WhiteSpaceException : Exception
{
    /// <summary>
    ///   Initializes a new instance of the <see cref="WhiteSpaceException"/> class.
    ///   <para>
    ///      Constructs a WhiteSpaceException containing the explanatory message.
    ///   </para>
    /// </summary>
    /// <param name="message"> A developer defined message describing why the exception occured.</param>
    public WhiteSpaceException( string message )
        : base( message )
    {
        // All this does is call the base constructor. No extra code needed.
    }
}

public class MinimumPasswordLengthException : Exception
{
    /// <summary>
    ///   Initializes a new instance of the <see cref="MinimumPasswordLengthException"/> class.
    ///   <para>
    ///      Constructs a MinimumPasswordLengthException containing the explanatory message.
    ///   </para>
    /// </summary>
    /// <param name="message"> A developer defined message describing why the exception occured.</param>
    public MinimumPasswordLengthException(string message)
        : base(message)
    {
        // All this does is call the base constructor. No extra code needed.
    }
}