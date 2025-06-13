using MyRecipeBook.Application.Services.Cryptography;

namespace CommonTestUtilities.Cryptography;
public class PasswordEncripterBuilder
{
    public static PassswordEncripter Build() => new PassswordEncripter("abc1234");
}
