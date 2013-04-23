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
        
      
  Turkish grammar
  
  Turkish is a highly agglutinative language, i.e., Turkish words have many grammatical suffixes or endings that determine meaning. Turkish vowels undergo vowel harmony. When a suffix is attached to a stem, the vowel in the suffix agrees in frontness or backness and in roundedness with the last vowel in the stem. Turkish has no gender.
  
  Suffixes
  A suffix (ek) is attached to a stem (gövde). A stem may be a root (kök) or further analyzable. The suffixes used in Turkish fall roughly into two classes: constructive suffixes (yapım ekleri) and inflectional suffixes (çekim ekleri). A constructive suffix makes a new word from an old one, that is, it is a derivational suffix. An inflectional suffix indicates how a word is used in a sentence. The article on Turkish grammar pertains chiefly to inflectional suffixes. The article on Turkish vocabulary treats the constructive suffixes.
  A Turkish suffix can be called enclitic if its vowel undergoes vowel harmony, agreeing with the last vowel of the stem the suffix is attached to.
  
  Parts of speech
  
  There are nine parts of speech (söz türleri "word-kinds") in Turkish.
  noun (isim or ad "name");
  pronoun (zamir "inner being", or adıl from ad);
  adjective (sıfat "role, quality", or önad "front-noun");
  verb (fiil "act, deed", or eylem "action" from eyle- "make, do").
  adverb (zarf "envelope", or belirteç from belir- "determine");
  postposition (ilgeç from ilgi "interest, relation");
  conjunction (râbıt [obsolete], or bağlaç from bağ "bond");
  particle (edat, or ilgeç);
  interjection (nidâ [obsolete], or ünlem from 'ün "fame, repute, sound").
  
  http://en.wikipedia.org/wiki/Turkish_grammar      
    
      
      
      
      Python Version
      https://github.com/miklagard/Turkish-Suffix-Library
