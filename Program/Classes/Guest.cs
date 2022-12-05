/*
Dt071g, Moment3, Nils
nibo1005@student.miun.se
*/

//Här finns class, Guest.

/////////////////////
//Få bort s.k. null ref-meddelanden, inspiration av nedan länk.
//Another alternative is to add the null forgiving operator, ! to the right-hand side.
//https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings#possible-null-assigned-to-a-nonnullable-reference
/////////////////

//using System, innebär att du använder "System library" i projektet. 
using System;

//Namespaces används i C# för att organisera och ge en nivå av separerade koder.
namespace guestbook
{
//Nedan används bl.a. vid ny post.
//Denna class, Guest, är publik och då nåbar överallt.
//Innehåller user och post, vilka är private, innebär då att att
//endast Guest kan nå denna, dessa i sin tur innehåller s.k. setters, och getters.
public class Guest
{
//Obj.
private string user = null!;        
public string User
{
//Get/set är "åtkomstmodifierare" till property. Get läser fältet. Set anger property-värdet.
set {this.user = value;}
get {return this.user;}
}

//Se ovan.
private string post = null!;  
public string Post
{
set {this.post = value;}
get {return this.post;}
}
}
}
