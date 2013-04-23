  NET Turkish Suffix Library (C#)
  
  =======
  
      Turkish tr = new Turkish();
  
      Console.WriteLine(tr.makeGenitive("Öykü", new { proper_noun = true }));
      Console.WriteLine(tr.makeDative("Fatma", new { proper_noun = true }));
      Console.WriteLine(tr.makeAblative("Ali", new { proper_noun = true }));
      Console.WriteLine(tr.makeAccusative("Kaliningrad", new { proper_noun = true }));
  
      Console.WriteLine(tr.makeGenitive("ağaç", new { proper_noun = false }));
      Console.WriteLine(tr.makeAccusative("erik", new { proper_noun = false }));
      Console.WriteLine(tr.makeAccusative("Erik", new { proper_noun = true }));
  
      Console.WriteLine(tr.possessiveAffix("kavanoz", new { person = "1", quantity = "singular" }));
      Console.WriteLine(tr.possessiveAffix("kavanoz", new { person = "2", quantity = "singular"}));
      Console.WriteLine(tr.possessiveAffix("kavanoz", new { person = "3", quantity = "singular"}));
  
      Console.WriteLine(tr.possessiveAffix("halter", new { person = "1", quantity = "plural"}));
      Console.WriteLine(tr.possessiveAffix("halter", new { person = "2", quantity = "plural"}));
      Console.WriteLine(tr.possessiveAffix("halter", new { person = "3", quantity = "plural"}));
  
      Console.WriteLine(tr.possessiveAffix("Kenya", new { person = "3", quantity = "plural"}));
      Console.ReadLine();
  
      //>>> Sample Output
      //Öykü'nün
      //Fatma'ya
      //Ali'den
      //Kaliningrad'ı
      //ağacın
      //eriği
      //Erik'i
      //kavanozum
      //kavanozun
      //kavanozu
      //halterimiz
      //halteriniz
      //halterleri
      //Kenyaları
      
      
      Python Version
      https://github.com/miklagard/Turkish-Suffix-Library
