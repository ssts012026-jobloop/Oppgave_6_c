using Xunit;
using System;
using System.Linq;
using Testapp;

public class MyStackTest
{
    [Fact] // Test 1
    public void Push_og_Pop_ReturnererRettRekkefølge()
    {
        var stack = new TestStack<string>(); // sier at dett er data som stacken skal hontere
    
        stack.Push("Først");
        stack.Push("Siste"); // sender inn 2 datapunkt som stacken skal lagre

        var resultat = stack.Pop();
        Assert.Equal("Siste", resultat); // skjekker at siste inn kommer ut først
        Assert.Equal(1, stack.AntallItems); // sjekker at det er 1 igjen i stacken
    }

    [Fact] // Test 2
    public void Items_BareLesbar_UforandreligFraUtsiden()
    {
        var stack = new TestStack<string>(); // sier at dett er data som stacken skal hontere

        stack.Push("Data"); // Informasjonen som blir sendt til stacken

        var items = stack.Items; // Ser om vi kan sende informasjo direkte til Items enumerable i stackTesting

        Assert.IsNotType<List<string>>(items); // ser at det ikkje skal være mulig å legge til noe i stacken fra utsiden
    }

    [Fact] // Test 3
    public void Pop_TomStack_SenderError()
    {
        var stack = new TestStack<string>(); // sier at dette er data som stacken skal hontere

        Assert.Throws<InvalidOperationException>(() => stack.Pop()); // Sier at vi skal se etter ein opprasjon som ikkje skal skje, med at stack skal ikkje kunne pope noe
    }

    [Fact] // Test 4
    public void Push_ErUlovligopprasjon_MedNullverdi()
    {
        var stack = new TestStack<string>(); // sier at dette er data som stacken skal hontere
        Assert.Throws<ArgumentNullException>(() => stack.Push(null!)); // vi prøver å legge til ein null verdi som ikkje skal fungere
    }
    
    [Theory] // Test 5
    [InlineData("A","B","B")] // pusjer a og så b og forventer b på toppen
    [InlineData("1","2","2")] // pusher 1 og så 2 og forventer 2 på toppen
    public void Peek_returnererTopElementet_UtenåFjerne(String first, String second, String expected) // tar i mot a og 1 og så b og 2 så forventes b og 2
    {
        var stack = new TestStack<string>();
        stack.Push(first); // sender a og så b
        stack.Push(second); // sender 1 og så 2

        var resultat = stack.Peek(); // skjekker med får resultatet fra toppen om det er riktig

        Assert.Equal(expected, resultat); // test resultatet tar argumentet fra toppen og forventer et resultat som skal være "B"
        Assert.Equal(2, stack.AntallItems); // kor mange ting som er i stacken skal være "2" i denne testen
    }
}