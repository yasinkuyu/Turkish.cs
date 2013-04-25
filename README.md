
# NET Turkish Suffix Library (C#)


## Using
  
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
  
# Output
  
    Öykü'nün
    Fatma'ya
    Ali'den
    Kaliningrad'ı
    ağacın
    eriği
    Erik'i
    kavanozum
    kavanozun
    kavanozu
    halterimiz
    halteriniz
    halterleri
    Kenyaları

## Turkish Grammar
 * Turkish is a highly agglutinative language, i.e., Turkish words have many grammatical suffixes or endings that determine meaning. Turkish vowels undergo vowel harmony. When a suffix is attached to a stem, the vowel in the suffix agrees in frontness or backness and in roundedness with the last vowel in the stem. Turkish has no gender.
 * [More Info](http://en.wikipedia.org/wiki/Turkish_grammar)

## Author
 * Yasin Kuyu
 * [Follow me at Twitter](http://twitter.com/#!/yasinkuyu)

  
  
      Python Version
      https://github.com/miklagard/Turkish-Suffix-Library
