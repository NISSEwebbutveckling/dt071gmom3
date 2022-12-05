/*
Dt071g, Moment3, Nils
nibo1005@student.miun.se

//////BAKGRUND////////////////////

Denna skoluppgift i C# består i att skapa en konsolapplikation som fungerar som en gästbok.

Syftet med uppgiften är att studenten efter genomförd laboration ska:
    -Kunna skapa enklare ojektorienterade program i programmeringspråket C#.
    -Kunna använda klasser och objekt för att skapa program i C#.
    -Ha erhållit en förståelse för objektorienterad programmering och dess terminologi.

Lösningen innehåller felhantering, som bl.a. kontrollerar om alla inmatningsfält innehåller data. 
Classes som förekommer i egna filer är, Guset.cs samt GuestStore.cs.

//
//Grunden till denna uppgift är inspirerad av programmet Carstore,  vilket är upparbetat/utvecklat av Mikael Hasselmalm vid Mittuniversitetet.
(Jag har förstått det som att det är ok att nyttja/jobba vidare på ovannämnda grund, för att exempelvis fullfölja den här berörda uppgiften.)
*/

//TEORI//
/*
Lite teori som inspirerat/underlättat till lösning av den här uppgiften:
https://play.miun.se/media/DT071G_OOP_Introduktion_H22/0_r7uuyur4
https://play.miun.se/media/DT071G_C_OOP_uppf%C3%B6ljning/0_z8tu5drv
https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/classes
https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/oop
https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.keys?view=windowsdesktop-7.0
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings#possible-null-assigned-to-a-nonnullable-reference
*/

//////PROGRAMMET/////////////////////////////////////////////////////////////////////

//C#, Gästboken//

//using System, innebär att du använder "System library" i projektet/programmet. 
using System;

//Namespaces används i C# för att organisera och ge en nivå av separerade koder.
namespace guestbook
{
//Huvudprogrammet, class Program.
class Program
{
//Statisk metod, Main, denna körs.
static void Main(string[] args)
{
//Ändrar lite färger, inspiration från nedan källa.
//https://www.geeksforgeeks.org/c-sharp-how-to-change-foreground-color-of-text-in-console/   
Console.BackgroundColor
= ConsoleColor.Black;   

//Instansiera, "mgm-class", GuestStore => Tillgånt till addGuest, delGuest, etc.
GuestStore gueststore = new GuestStore();
//Nollar.
int i=0;
//Slinga, meny och val.
while(true){
        // Clear console (tömmer konsolen).
    Console.Clear();Console.CursorVisible = false;
//Färg.
Console.ForegroundColor
= ConsoleColor.Yellow;
Console.BackgroundColor
= ConsoleColor.DarkMagenta;
//Felhantering. try/catch. Inspiration från nedan källa.
//https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-catch
try
{
//Ändra bakrungdfsfärg.
Console.BackgroundColor
= ConsoleColor.Black;
//Skriv ut rubrik
Console.WriteLine("________________________________________________________");
Console.WriteLine("\nGÄSTBOKEN (dt071g, moment3)");
Console.WriteLine("________________________________________________________");
//Delay, inspiration från, https://learn.microsoft.com/en-us/dotnet/api/system.threading.thread.sleep?view=net-7.0
int milliseconds = 500;
Thread.Sleep(milliseconds);
//Instruktioner.
Console.WriteLine("\nINSTRUKTIONER\n");
//Delay
Thread.Sleep(milliseconds);

//Skriver ut meny, alternativ
Console.WriteLine("[<-]-tangent | Skriv i gästboken.\n");
Console.WriteLine("[->]-tangent | Ta bort ett inlägg i gästboken.\n");
Console.WriteLine("[esc]-tangent | Avsluta.\n");
Console.WriteLine("________________________________________________________\n");
//Delay
Thread.Sleep(milliseconds);  
//Ändra bakrungdfsfärg.
Console.ForegroundColor
= ConsoleColor.White;

 Console.WriteLine("\nPUBLICERADE INLÄGG\n");   
//Skriver ut gästboksinlägg.
//index, (vart befinner sig), nollställs.
i=0;
//För varje element, flytta över obj. till var. guest, så att det går att jobba med dennna, skriv sedan ut i++ guest.User, resp. guest.Post.
foreach(Guest guest in gueststore.getGuests()){
//Lagrat skrivs ut, samtliga poster.
    Console.WriteLine("[" + i++ + "] " + "Författare: "  + guest.User + " \n " + "Inlägg: " + guest.Post + "\n");
}

//Ändrar textfärg.
Console.ForegroundColor
= ConsoleColor.Yellow;
//Ändrar bakrungdfsfärg.
Console.BackgroundColor
= ConsoleColor.Black;

//Datumhantering, inspiration från nedan länk.
//https://learn.microsoft.com/en-us/dotnet/api/system.datetime.today?view=net-7.0
   {
    // Bef datum..
      DateTime thisDay = DateTime.Today;
       // Visar datum.   
  Console.WriteLine("________________________________________________________\n");
         Console.WriteLine("Dagens datum är: " + thisDay.ToString("d"));
   }

Console.WriteLine("________________________________________________________\n");   
//ReadKey, inväntar tangenttryck.
    int inp = (int) Console.ReadKey(true).Key;
    
//Case-switch, för menyval-tangenter. <- RESP -> samt esc.
switch (inp) {
//37= <-tangent.
case 37:
Console.CursorVisible = true; 

//Ändrar bakrungdfsfärg.
Console.BackgroundColor
= ConsoleColor.DarkGreen;
    
//Skriver ut meddelanden.
Console.WriteLine("\nNu kan du skriva ett gästboksinlägg.");
Console.WriteLine("\nInlägget ska innehålla BÅDE författare till inlägget samt texten för inlägget. \n");
Console.Write("Vem är du?: ");
//Input från användare.
string user = Console.ReadLine()!;
//SKriv ut meddelande.
Console.Write("\nHej" + " " + user + ", " + "skriv ett inlägg: ");
string post = Console.ReadLine()!;   

//Instansiera nytt obj.,
Guest obj = new Guest();
//"Sätter" värdena.
obj.User = user;
obj.Post = post;

//Felhantering vid tom inmatning.
{           
// If-sats för att kolla input value.
//Kollar om tomma fält, annars lägg till.
if(!String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(post)) {gueststore.addGuest(obj);

//Meddelande ang. sparat inlägg, samt delay.
Console.WriteLine("\nInlägget har sparats.");
//Delay
int milliseconds2 = 3000;
Thread.Sleep(milliseconds2);
}
else {
//Felmeddelande, m.m.
//Ändra bakrungdfsfärg.
Console.BackgroundColor
= ConsoleColor.Red;
//Delay
int milliseconds22 = 3000;
Console.WriteLine("\nDu följde inte instruktionerna. \n Du behöver mata in både författare och inlägg nästa gång du kör programmet.\n");
Thread.Sleep(milliseconds22);
Console.WriteLine("Programmet kommer att avslutas.\n");        
Thread.Sleep(milliseconds22);
//Avslutar programmet, samt meddelande.
Console.WriteLine("Hejdå!\n");  
//Avslutar
Environment.Exit(0);
break;
}
 }
//Ändra bakrungdfsfärg.
Console.BackgroundColor
= ConsoleColor.Black;
break;           

//Nästa switch
//39 = -> 
case 39: 
//Ändra bakrungdfsfärg.
Console.BackgroundColor
= ConsoleColor.DarkRed;
Console.CursorVisible = true;
Console.Write("Ange inlägg [index] att radera (går ej att ångra), följt av [enter]: ");

//Ändra bakrungdfsfärg.
Console.BackgroundColor
= ConsoleColor.Black;                  
//Läser inmatning.
string index = Console.ReadLine()!;
//Tar bort, gör om till heltal.
gueststore.delGuest(Convert.ToInt32(index));

//Meddelande ang. borttaget inlägg.            
Console.WriteLine("\nInlägget har raderats.");
//Delay
int milliseconds222 = 3000;
Thread.Sleep(milliseconds222);
break;

//Sista switch
//27 = esq
case 27: 
//Avslutar programmet, samt meddelande.
Console.WriteLine("Hejdå!\n");
Environment.Exit(0);
break;
}
}

//Felhantering. catch/try, inspiration från nedan länk.
//https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-catch
catch(ArgumentOutOfRangeException )
//catch(ArgumentOutOfRangeException  e)
{
//Färg.
Console.BackgroundColor
= ConsoleColor.Red;
//Meddelande lagras i string.
string Message = "\nAngivet nummer finns ej. \nVänligen, testa med ett nytt nummer nästa gång du kör programmet.";
//Skriver ut meddelande.
Console.Write(Message);
//Delay
int milliseconds3 = 3000;
Thread.Sleep(milliseconds3);
//Avslutar programmet.
Console.WriteLine("\n\nProgrammet kommer att avslutas.\n");
//Delay
Thread.Sleep(milliseconds3);
//Avslutar programmet, samt meddelande.
Console.WriteLine("Hejdå!\n");
//Avslutar programmet.
Environment.Exit(0);
break;
}

//Nästa catch
catch
{
//Färg.
Console.BackgroundColor
= ConsoleColor.Red;
//Delay
int milliseconds4 = 3000;
//Meddelande skrivs ut direkt, ej lagrat i string.
Console.Write("\nEtt fel uppstod eftersom att du har matat in annat än en siffra eller har lämnat fältet tomt. \nVänligen, ange en korrekt inmatning nästa gång du kör programmet.");
//Delay
Thread.Sleep(milliseconds4);
Console.WriteLine("\n\nProgrammet kommer att avslutas.\n");
Thread.Sleep(milliseconds4);
//Avslutar programmet, samt meddelande.
Console.WriteLine("Hejdå!\n");
//Avslutar programmet.
Environment.Exit(0);
break;
            }
}
}
}
}
