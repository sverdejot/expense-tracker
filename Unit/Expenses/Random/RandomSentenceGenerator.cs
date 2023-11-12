namespace Unit.Random;

public class RandomSentenceGenerator
{
    public static string One() =>
        new Bogus.DataSets.Lorem(locale: "es").Sentence(5);

    public static string Paragraph() =>
        new Bogus.DataSets.Lorem(locale: "es").Paragraph(5);
}