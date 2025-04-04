
using Humanizer;

[UseCulture("pl")]

public class PgTests
{
    [Theory]
    [InlineData("ó ż ź ą ę ł ń ć ś", "ó-ż-ź-ą-ę-ł-ń-ć-ś")]
    [InlineData("Żżżżż źźźźź ąąąąą ęęęęę łłłłł óóóóó ńńńńń ććććć śśśśś", "ŻżżżżŹźźźźĄąąąąĘęęęęŁłłłłÓóóóóŃńńńńĆććććŚśśśś")]
    [InlineData("Aaaa bbbb cccc", "AaaaBbbbCccc")]
    [InlineData("Żżżżż Źźźźź Ąąąąą Ęęęęę Łłłłł Óóóóó Ńńńńń Ććććć Śśśśś", "Żżżżż_Źźźźź_Ąąąąą_Ęęęęę_Łłłłł_Óóóóó_Ńńńńń_Ććććć_Śśśśś")]
    [InlineData("Aaaa Bbbb Cccc", "Aaaa_Bbbb_Cccc")]
    public void PolishHumanize(string expected, string tested)
        => Assert.Equal(expected, tested.Humanize());

    [Theory]
    [InlineData("óżźąęłńćś", "ÓŻŹĄĘŁŃĆŚ")]
    [InlineData("abcdef", "ABCDEF")]
    public void PolishHumanizeLowerCase(string expected, string tested)
        => Assert.Equal(expected, tested.Humanize(LetterCasing.LowerCase));

    [Theory]
    [InlineData("ÓŻŹĄĘŁŃĆŚ", "óżźąęłńćś")]
    [InlineData("ABCDEF", "abcdef")]
    public void PolishHumanizeAllCaps(string expected, string tested)
    => Assert.Equal(expected, tested.Humanize(LetterCasing.AllCaps));

    [Theory]
    [InlineData("żółw_śledzi", "żółw śledzi")]
    [InlineData("politechnika_gdańska", "politechnika gdańska")]
    [InlineData("pyszny_śledź", "pyszny śledź")]
    [InlineData("pyszny_żółw", "pyszny żółw")]
    public void PolishUnderscore(string expected, string tested)
        => Assert.Equal(expected, tested.Underscore());

    [Theory]
    [InlineData("żółwŚledzi", "żółw śledzi")]
    [InlineData("politechnikaGdańska", "politechnika gdańska")]
    [InlineData("pysznyŚledź", "pyszny śledź")]
    [InlineData("pysznyŹółw", "pyszny żółw")]
    public void PolishCamelize(string expected, string tested)
        => Assert.Equal(expected, tested.Camelize());

    [Theory]
    [InlineData("ŻółwŚledzi", "żółw śledzi")]
    [InlineData("PolitechnikaGdańska", "politechnika gdańska")]
    [InlineData("PysznyŚledź", "pyszny śledź")]
    [InlineData("PysznyŹółw", "pyszny żółw")]
    public void PolishPascalize(string expected, string tested)
        => Assert.Equal(expected, tested.Pascalize());
}
